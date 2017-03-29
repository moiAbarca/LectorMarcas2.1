using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using zkemkeeper;

using ZKSauroAPI;

namespace ZKSauroAPI
{
    public class ZKSauro
    {
        private string _error;

        private int resultConsulta;

        private List<UsuarioInformacion> lstListaUsuarios;

        private UsuarioInformacion DatosUsuarios;

        private List<UsuarioMarcaje> lstMarcajes;

        private UsuarioInformacion f;

        private bool EstadoConexion;

        private int dwErrorCode;

        private CZKEMClass zkemkeeper;

        private Modelo dispositivo;

        private string Ip = string.Empty;

        private int numeroIntentosMaximo;

        private int intentosConexion;

        public string ERROR
        {
            get
            {
                return this._error;
            }
        }

        public List<UsuarioMarcaje> ListaMarcajes
        {
            get
            {
                return this.lstMarcajes;
            }
        }

        public List<UsuarioInformacion> ListaUsuarios
        {
            get
            {
                return this.lstListaUsuarios;
            }
        }

        public int ResultadoConsulta
        {
            get
            {
                return this.resultConsulta;
            }
        }

        public UsuarioInformacion Usuario
        {
            get
            {
                return this.DatosUsuarios;
            }
        }

        public ZKSauro(Modelo device)
        {
            this.dispositivo = device;
        }

        private string Error(int A_0)
        {
            this._error = string.Empty;
            int a0 = A_0;
            if (a0 == -100)
            {
                this._error = "Operación fallida o el dato no existe.";
            }
            else
            {
                switch (a0)
                {
                    case -10:
                        {
                            this._error = "La longitud del dato transmitido no es correcto.";
                            break;
                        }
                    case -9:
                    case -8:
                    case -6:
                    case 2:
                    case 3:
                        {
                            break;
                        }
                    case -7:
                        {
                            this._error = "No se encontró conexión con el dispositivo.";
                            break;
                        }
                    case -5:
                        {
                            this._error = "El dato ya existe.";
                            break;
                        }
                    case -4:
                        {
                            this._error = "El espacio no es suficiente.";
                            break;
                        }
                    case -3:
                        {
                            this._error = "Error de tamaño.";
                            break;
                        }
                    case -2:
                        {
                            this._error = "Error en el archivo (read/write).";
                            break;
                        }
                    case -1:
                        {
                            this._error = "El SDK no está inicializado.";
                            break;
                        }
                    case 0:
                        {
                            this._error = "El dato no se encuentra o está repetido.";
                            break;
                        }
                    case 1:
                        {
                            this._error = "Operación correcta.";
                            break;
                        }
                    case 4:
                        {
                            this._error = "Parámetro incorrecto.";
                            break;
                        }
                    default:
                        {
                            if (a0 == 101)
                            {
                                this._error = "Error en la asignación del bufer.";
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                }
            }
            return this._error;
        }

        private bool DispositivoEnviarImagen()
        {
            if (!this.DispositivoConectar())
            {
                return false;
            }
            this._error = string.Empty;
            this.EstadoConexion = false;
            if (!this.zkemkeeper.SendFile(1, "C:\\Users\\Gabriel\\Desktop\\ad_1.jpg"))
            {
                this.zkemkeeper.GetLastError(ref this.dwErrorCode);
                this._error = string.Concat("(Método: DispositivoEnviarImagen) - Error al eliminar los registros operativos. Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode));
            }
            return this.EstadoConexion;
        }

        private bool DispositivoConectar()
        {
            this.numeroIntentosMaximo = 0;
            this.intentosConexion = 0;
            Ping ping = new Ping();
            if (string.IsNullOrEmpty(this.Ip))
            {
                this._error = "Es necesario ejecutar DispositivoConectar() antes de ejecutar este método.";
                return false;
            }
            for (int i = 0; i < 3; i++)
            {
                if (ping.Send(this.Ip).Status != IPStatus.Success)
                {
                    ZKSauro zKSoftware = this;
                    zKSoftware.intentosConexion = zKSoftware.intentosConexion + 1;
                }
                else
                {
                    ZKSauro zKSoftware1 = this;
                    zKSoftware1.numeroIntentosMaximo = zKSoftware1.numeroIntentosMaximo + 1;
                }
            }
            if (this.intentosConexion <= this.numeroIntentosMaximo)
            {
                return true;
            }
            this._error = "No se encontró el dispositivo.";
            return false;
        }

        private string ObtebetTipoMarca(TipoMarcas tipo)
        {
            string sReturn = String.Empty;
            switch (tipo)
            {
                case TipoMarcas.CheckIn:
                    sReturn = "Entrada";
                    break;
                case TipoMarcas.CheckOut:
                    sReturn = "Salida";
                    break;
                case TipoMarcas.BreakIn:
                    sReturn = "";
                    break;
                case TipoMarcas.BreakOut:
                    sReturn = "";
                    break;
                case TipoMarcas.Ot_In:
                    sReturn = "";
                    break;
                case TipoMarcas.Ot_Out:
                    sReturn = "";
                    break;
            }
            return sReturn;

        }

        public bool Beep()
        {
            this._error = string.Empty;
            this.EstadoConexion = false;
            if (!this.zkemkeeper.Beep(100))
            {
                this.zkemkeeper.GetLastError(ref this.dwErrorCode);
                this._error = string.Concat("(Método: Beep) - Error al enviar Beep. Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode));
            }
            else
            {
                this.EstadoConexion = true;
            }
            return this.EstadoConexion;
        }

        public bool DispositivoBorrarRegistrosAsistencias()
        {
            if (!this.DispositivoConectar())
            {
                return false;
            }
            this._error = string.Empty;
            this.EstadoConexion = false;
            if (!this.zkemkeeper.ClearGLog(1))
            {
                this.zkemkeeper.GetLastError(ref this.dwErrorCode);
                this._error = string.Concat("(Método: DispositivoBorrarRegistrosAsistencias) - Error al borrar los registros de asistencias. Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode));
            }
            else
            {
                this.EstadoConexion = true;
            }
            return this.EstadoConexion;
        }

        public bool DispositivoBorrarRegistrosOperativos()
        {
            if (!this.DispositivoConectar())
            {
                return false;
            }
            this._error = string.Empty;
            this.EstadoConexion = false;
            if (!this.zkemkeeper.ClearSLog(1))
            {
                this.zkemkeeper.GetLastError(ref this.dwErrorCode);
                this._error = string.Concat("(Método: DispositivoBorrarRegistrosOperativos) - Error al eliminar los registros operativos. Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode));
            }
            else
            {
                this.EstadoConexion = true;
            }
            return this.EstadoConexion;
        }

        public bool DispositivoCambiarEstatus(ZKSauroAPI.Estatus Estatus)
        {
            if (!this.DispositivoConectar())
            {
                return false;
            }
            this._error = string.Empty;
            this.EstadoConexion = false;
            if (!this.zkemkeeper.EnableDevice(1, (Estatus == ZKSauroAPI.Estatus.Deshabilitar ? false : true)))
            {
                this.zkemkeeper.GetLastError(ref this.dwErrorCode);
                string[] str = new string[] { "(Método: CambiarEstatus) - Error al ", Estatus.ToString(), " el dispositivo.  Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode) };
                this._error = string.Concat(str);
            }
            else
            {
                this.EstadoConexion = true;
            }
            return this.EstadoConexion;
        }

        public bool DispositivoCambiarHoraAutomatico()
        {
            if (!this.DispositivoConectar())
            {
                return false;
            }
            this._error = string.Empty;
            this.EstadoConexion = false;
            if (!this.DispositivoCambiarEstatus(Estatus.Deshabilitar))
            {
                return this.EstadoConexion;
            }
            if (!this.zkemkeeper.SetDeviceTime(1))
            {
                this._error = string.Concat("(Método: DispositivoCambiarHoraAutomatico) - Error al cambiar la hora del dispositivo. Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode));
            }
            else if (this.DispositivoCambiarEstatus(Estatus.Habilitar))
            {
                this.EstadoConexion = true;
            }
            return this.EstadoConexion;
        }

        public bool DispositivoCambiarHoraManual(int iDia, int iMes, int iAnio, int iHora, int iMinuto, int iSegundo)
        {
            if (!this.DispositivoConectar())
            {
                return false;
            }
            this._error = string.Empty;
            this.EstadoConexion = false;
            if (!this.DispositivoCambiarEstatus(Estatus.Deshabilitar))
            {
                return this.EstadoConexion;
            }
            if (!this.zkemkeeper.SetDeviceTime2(1, iAnio, iMes, iDia, iHora, iMinuto, iSegundo))
            {
                this.zkemkeeper.GetLastError(ref this.dwErrorCode);
                this._error = string.Concat("(Método: DispositivoCambiarHoraManual) - Error al cambiar la hora del dispositivo de forma manual. Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode));
            }
            else if (this.DispositivoCambiarEstatus(Estatus.Habilitar))
            {
                this.EstadoConexion = true;
            }
            return this.EstadoConexion;
        }

        public bool DispositivoConectar(string IP, int IntentosConexion, bool bBeep)
        {
            this.Ip = IP;
            if (!this.DispositivoConectar())
            {
                return false;
            }
            if (IntentosConexion == 0)
            {
                IntentosConexion = 1;
            }
            int intentosConexion = 1;
            this._error = string.Empty;
            this.EstadoConexion = false;
            this.zkemkeeper = new CZKEMClass();
            while (intentosConexion <= IntentosConexion)
            {
                if (!this.zkemkeeper.Connect_Net(IP, 4370))
                {
                    this.Ip = string.Empty;
                    intentosConexion++;
                    this.zkemkeeper.GetLastError(ref this.dwErrorCode);
                    this._error = string.Concat("(Método: Conectar) - Error al conectar el dispositivo. Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode));
                    this.DispositivoDesconectar();
                    this.zkemkeeper = new CZKEMClass();
                }
                else
                {
                    this.EstadoConexion = true;
                    if (bBeep)
                    {
                        Thread.Sleep(300);
                        this.Beep();
                        Thread.Sleep(300);
                        this.Beep();
                        Thread.Sleep(300);
                        this.Beep();
                    }
                    intentosConexion = IntentosConexion + 1;
                    this.Ip = IP;
                }
            }
            return this.EstadoConexion;
        }

        public bool DispositivoConsultar(NumeroDe DatoConsultar)
        {
            if (!this.DispositivoConectar())
            {
                return false;
            }
            this._error = string.Empty;
            this.EstadoConexion = false;
            this.resultConsulta = 0;
            if (!this.zkemkeeper.GetDeviceStatus(1, (int)DatoConsultar, ref this.resultConsulta))
            {
                this.zkemkeeper.GetLastError(ref this.dwErrorCode);
                string[] str = new string[] { "(Método: Consultar) - Error al Consultar: ", DatoConsultar.ToString(), ". Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode) };
                this._error = string.Concat(str);
            }
            else
            {
                this.EstadoConexion = true;
            }
            return this.EstadoConexion;
        }

        public void DispositivoDesconectar()
        {
            if (this.zkemkeeper == null)
            {
                return;
            }
            this.zkemkeeper.Disconnect();
        }

        public bool DispositivoObtenerRegistrosAsistencias()
        {
            bool flag;
            try
            {
                if (this.DispositivoConectar())
                {
                    this._error = string.Empty;
                    this.EstadoConexion = false;
                    this.lstMarcajes = new List<UsuarioMarcaje>();
                    if (this.zkemkeeper.ReadGeneralLogData(1))
                    {
                        string empty = string.Empty;
                        int num = 0;
                        int num1 = 0;
                        int num2 = 0;
                        int num3 = 0;
                        int num4 = 0;
                        int num5 = 0;
                        int num6 = 0;
                        int num7 = 0;
                        int num8 = 0;
                        while (this.zkemkeeper.SSR_GetGeneralLogData(1, out empty, out num, out num1, out num2, out num3, out num4, out num5, out num6, out num7, ref num8))
                        {
                            UsuarioMarcaje userData = new UsuarioMarcaje()
                            {
                                NumeroCredencial = int.Parse(empty),
                                Anio = num2,
                                Mes = num3,
                                Dia = num4,
                                Hora = num5,
                                Minuto = num6,
                                Segundo = num7,
<<<<<<< .merge_file_bPR6ky
                                TipoMarca = (TipoMarcas) num1,
=======
                                TipoMarca = num1,
>>>>>>> .merge_file_DHceBT
                                MetodoMarca = (MetodoMarcas)num
                            };
                            this.lstMarcajes.Add(userData);
                        }
                        this.EstadoConexion = true;
                        return this.EstadoConexion;
                    }
                    else
                    {
                        this.zkemkeeper.GetLastError(ref this.dwErrorCode);
                        this._error = string.Concat("(Método: DispositivoObtenerRegistrosAsistencias) - Error al leer el log de marcajes. Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode));
                        flag = this.EstadoConexion;
                    }
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception ex)
            {
                this._error = string.Concat("(Método: DispositivoObtenerRegistrosAsistencias) - Error al leer el log de marcajes. Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode));
                return this.EstadoConexion;
            }
            return flag;
        }

        public bool DispositivoObtenerRegistrosOperativos()
        {
            if (!this.DispositivoConectar())
            {
                return false;
            }
            this._error = string.Empty;
            this.EstadoConexion = false;
            this.lstMarcajes = new List<UsuarioMarcaje>();
            if (!this.zkemkeeper.ReadSuperLogData(1))
            {
                this.zkemkeeper.GetLastError(ref this.dwErrorCode);
                this._error = string.Concat("(Método: DispositivoObtenerRegistrosOperativos) - Error al leer el log de marcajes operativos. Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode));
                return this.EstadoConexion;
            }
            int num = 0;
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            int num10 = 0;
            int num11 = 0;
            while (this.zkemkeeper.GetSuperLogData(1, ref num1, ref num, ref num11, ref num8, ref num9, ref num7, ref num10, ref num2, ref num3, ref num4, ref num5, ref num6))
            {
                UsuarioMarcaje usuarioMarcaje = new UsuarioMarcaje()
                {
                    NumeroCredencial = num,
                    Anio = num2,
                    Mes = num3,
                    Dia = num4,
                    Hora = num5,
                    Minuto = num6,
                    MarcajeOperativo = new MarcajeOperativo()
                    {
                        NumeroDispositivo = num1,
                        Operacion = num7,
                        Parametro1 = num8,
                        Parametro2 = num9,
                        Parametro3 = num10,
                        Parametro4 = num11
                    }
                };
                this.lstMarcajes.Add(usuarioMarcaje);
            }
            this.EstadoConexion = true;
            return this.EstadoConexion;
        }

        public bool UsuarioAgregar(int NumeroCredencial, string UsuarioNombre, Permiso TipoPermiso, int indexHuella, string b64Huella)
        {
            if (!this.DispositivoConectar())
            {
                return false;
            }
            this._error = string.Empty;
            this.EstadoConexion = false;
            if (!this.zkemkeeper.SSR_SetUserInfo(1, NumeroCredencial.ToString(), UsuarioNombre, string.Empty, (int)TipoPermiso, true))
            {
                this.zkemkeeper.GetLastError(ref this.dwErrorCode);
                this._error = string.Concat("(Método: UsuarioEnrolar) - Error al enrolar el usuario. Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode));
            }
            else if (!this.zkemkeeper.SetUserTmpExStr(1, NumeroCredencial.ToString(), indexHuella, 1, b64Huella))
            {
                this.zkemkeeper.GetLastError(ref this.dwErrorCode);
                this._error = string.Concat("(Método: UsuarioEnrolar) - Error al guardar la huella. Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode));
            }
            else
            {
                this.EstadoConexion = true;
            }
            return this.EstadoConexion;
        }

        public bool UsuarioBorrar(int NumeroCredencial)
        {
            if (!this.DispositivoConectar())
            {
                return false;
            }
            this._error = string.Empty;
            this.EstadoConexion = false;
            if (!this.zkemkeeper.SSR_DeleteEnrollDataExt(1, NumeroCredencial.ToString(), 12))
            {
                this._error = string.Concat("(Método: UsuarioBorrar) - Error al eliminar el usuario. Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode));
            }
            else
            {
                this.EstadoConexion = true;
            }
            return this.EstadoConexion;
        }

        public bool UsuarioBuscar(int NumeroCredencial)
        {
            if (!this.DispositivoConectar())
            {
                return false;
            }
            this._error = string.Empty;
            this.EstadoConexion = false;
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            int num = 0;
            int num1 = 0;
            bool flag = false;
            if (!this.zkemkeeper.SSR_GetUserInfo(1, NumeroCredencial.ToString(), out empty, out str, out num, out flag))
            {
                this._error = string.Concat("(Método: UsuarioBuscar) - Error al buscar el usuario. Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode));
            }
            else
            {
                this.DatosUsuarios = new UsuarioInformacion()
                {
                    NumeroCredencial = NumeroCredencial,
                    Nombre = empty,
                    Contrasenia = str,
                    Permiso = (Permiso)num,
                    Activo = flag,
                    Huellas = new List<UsuarioHuella>()
                };
                for (int i = 0; i < 10; i++)
                {
                    if (this.zkemkeeper.SSR_GetUserTmpStr(1, NumeroCredencial.ToString(), i, out empty1, out num1))
                    {
                        UsuarioHuella usuarioHuella = new UsuarioHuella()
                        {
                            IndexHuella = i,
                            B64Huella = empty1,
                            LongitudHuella = num1
                        };
                        this.DatosUsuarios.Huellas.Add(usuarioHuella);
                    }
                }
                this.EstadoConexion = true;
            }
            return this.EstadoConexion;
        }

        public bool UsuarioBuscarTodos(bool DeshabilitarDispositivo)
        {
            if (!this.DispositivoConectar())
            {
                return false;
            }
            this._error = string.Empty;
            this.EstadoConexion = false;
            if (DeshabilitarDispositivo && !this.DispositivoCambiarEstatus(Estatus.Deshabilitar))
            {
                this._error = string.Concat("(Método: UsuarioBuscarTodos) - Error al cambiar estatus de dispositivo. Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode));
                return this.EstadoConexion;
            }
            if (!this.zkemkeeper.ReadAllUserID(1))
            {
                this._error = string.Concat("(Método: UsuarioBuscarTodos) - Error al obtener la información de los usuarios. Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode));
                return this.EstadoConexion;
            }
            if (!this.zkemkeeper.ReadAllTemplate(1))
            {
                this._error = string.Concat("(Método: UsuarioBuscarTodos) - Error al obtener las huellas de los usuarios. Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode));
                return this.EstadoConexion;
            }
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            int num = 0;
            bool flag = false;
            string str1 = string.Empty;
            int num1 = 0;
            int num2 = 0;
            if (!this.zkemkeeper.ReadAllUserID(1))
            {
                this._error = string.Concat("(Método: UsuarioBuscarTodos) - No se pudo obtener la información de la memoria. Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode));
                return this.EstadoConexion;
            }
            if (!this.zkemkeeper.ReadAllTemplate(1))
            {
                this._error = string.Concat("(Método: UsuarioBuscarTodos) - No se pudieron obtener las huellas de la memoria. Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode));
                return this.EstadoConexion;
            }
            this.lstListaUsuarios = new List<UsuarioInformacion>();
            while (this.zkemkeeper.SSR_GetAllUserInfo(1, out empty, out str, out empty1, out num, out flag))
            {
                this.f = new UsuarioInformacion()
                {
                    NumeroCredencial = int.Parse(empty),
                    Nombre = str,
                    Permiso = (Permiso)num,
                    Contrasenia = empty1,
                    Activo = flag,
                    Huellas = new List<UsuarioHuella>()
                };
                for (int i = 0; i < 10; i++)
                {
                    if (this.zkemkeeper.GetUserTmpExStr(1, empty, i, out num2, out str1, out num1))
                    {
                        UsuarioHuella usuarioHuella = new UsuarioHuella()
                        {
                            IndexHuella = i,
                            B64Huella = str1,
                            LongitudHuella = num1
                        };
                        this.f.Huellas.Add(usuarioHuella);
                    }
                }
                this.lstListaUsuarios.Add(this.f);
            }
            if (!DeshabilitarDispositivo || this.DispositivoCambiarEstatus(Estatus.Habilitar))
            {
                this.EstadoConexion = true;
                return this.EstadoConexion;
            }
            this._error = string.Concat("(Método: UsuarioBuscarTodos) - Error al habilitar el dispositivo. Código de error: ", this.dwErrorCode.ToString(), " - ", this.Error(this.dwErrorCode));
            return this.EstadoConexion;
        }
    }

}
