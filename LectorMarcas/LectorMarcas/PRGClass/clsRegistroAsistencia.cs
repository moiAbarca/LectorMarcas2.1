using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectorMarcas.DBClass;
using SGFDataLayer;
using System.Data.Common;
using System.Data;

using ZKSauroAPI;
<<<<<<< .merge_file_imHlpw
using System.Globalization;
=======
>>>>>>> .merge_file_rxGbtu

namespace LectorMarcas.PRGClass
{
    public class clsRegistroAsistencia : registroasistencia
    {
        BaseDatos BD;

<<<<<<< .merge_file_imHlpw
=======

>>>>>>> .merge_file_rxGbtu
        public clsRegistroAsistencia()
        {
            BD = new BaseDatos();
        }

        #region propiedades
        int count;

        public int Count
        {
            get { return count; }
        }
        #endregion

        #region metodos públicos
        /// <summary>
        /// Limpia las propiedades de la clase
        /// </summary>
        public void Clear()
        { 
            this.Idenroll = 0;
            this.Fechahoramarca = Convert.ToDateTime("19000101");
            this.Fechahoraregistro = Convert.ToDateTime("19000101");
            this.Ipdispositivo = "0.0.0.0";
            this.Metodoregistro = -1;
            this.Tipoacceso = -1;
        }


        /// <summary>
        /// Obtiene colección con la asistecia de un IdEnrol
        /// </summary>
        /// <param name="IdEnroll">Id de la persona enrolada</param>
        /// <returns>Retorna una colección del tipo <code>List/<registroasistencia/></code></returns>
        public List<registroasistencia> Get(int IdEnroll)
        { 
            var list = new List<registroasistencia>();
            BD.Conectar();

<<<<<<< .merge_file_imHlpw
            BD.CrearComando("call spGetRegistroAsistencia(@IdEnroll)");
=======
            BD.CrearComando("call spGetEnrolados(@IdEnroll)");
>>>>>>> .merge_file_rxGbtu
            BD.AsignarParametroEntero("@IdEnroll", IdEnroll);
            DbDataReader dr = BD.EjecutarConsulta();

            DataTable dt = new DataTable();
            dt.Load(dr);
            this.count = dt.Rows.Count;
            DataTableReader reader = new DataTableReader(dt);

            if (this.count <= 0)
                return list;

            while (reader.Read())
            {
                registroasistencia e = new registroasistencia()
                {
                    
                    Idenroll          = reader.IsDBNull(reader.GetOrdinal("IdEnroll")) ? 0 : reader.GetInt32(reader.GetOrdinal("IdEnroll")),
                    Fechahoramarca    = reader.IsDBNull(reader.GetOrdinal("Fechahoramarca")) ? Convert.ToDateTime("19000101") : reader.GetDateTime(reader.GetOrdinal("Fechahoramarca")),
                    Fechahoraregistro = reader.IsDBNull(reader.GetOrdinal("Fechahoraregistro")) ? Convert.ToDateTime("19000101") : reader.GetDateTime(reader.GetOrdinal("Fechahoraregistro")),
                    Ipdispositivo     = reader.IsDBNull(reader.GetOrdinal("Ipdispositivo")) ? "" : reader.GetString(reader.GetOrdinal("Ipdispositivo")),
<<<<<<< .merge_file_imHlpw
                    Metodoregistro    = reader.IsDBNull(reader.GetOrdinal("Metodoregistro")) ? 0 : reader.GetInt32(reader.GetOrdinal("MetodoRegistro")),
                    Tipoacceso        = reader.IsDBNull(reader.GetOrdinal("Tipoacceso")) ? 0 : reader.GetInt32(reader.GetOrdinal("TipoAcceso")),

                };
                list.Add(e);
            }
            reader.Close();
            BD.Desconectar();
            return list;

        }

        public List<registroasistencia> Get(int IdEnroll, string FecIni, string FecEnd)
        {
            var list = new List<registroasistencia>();
            BD.Conectar();

            BD.CrearComando("call spGetRegistroAsistenciaByFechas(@IdEnroll, @FecIni, @FecFin)");
            BD.AsignarParametroEntero("@IdEnroll", IdEnroll);
            BD.AsignarParametroCadena("@FecIni", FecIni);
            BD.AsignarParametroCadena("@FecFin", FecEnd);
            DbDataReader dr = BD.EjecutarConsulta();

            DataTable dt = new DataTable();
            dt.Load(dr);
            this.count = dt.Rows.Count;
            DataTableReader reader = new DataTableReader(dt);

            if (this.count <= 0)
                return list;

            while (reader.Read())
            {
                registroasistencia e = new registroasistencia()
                {
                    Idenroll = reader.IsDBNull(reader.GetOrdinal("IdEnroll")) ? 0 : reader.GetInt32(reader.GetOrdinal("IdEnroll")),
                    Fechahoramarca = reader.IsDBNull(reader.GetOrdinal("Fechahoramarca")) ? Convert.ToDateTime("19000101") : reader.GetDateTime(reader.GetOrdinal("Fechahoramarca")),
                    Fechahoraregistro = reader.IsDBNull(reader.GetOrdinal("Fechahoraregistro")) ? Convert.ToDateTime("19000101") : reader.GetDateTime(reader.GetOrdinal("Fechahoraregistro")),
                    Ipdispositivo = reader.IsDBNull(reader.GetOrdinal("Ipdispositivo")) ? "" : reader.GetString(reader.GetOrdinal("Ipdispositivo")),
                    Metodoregistro = reader.IsDBNull(reader.GetOrdinal("Metodoregistro")) ? 0 : reader.GetInt32(reader.GetOrdinal("MetodoRegistro")),
                    Tipoacceso = reader.IsDBNull(reader.GetOrdinal("Tipoacceso")) ? 0 : reader.GetInt32(reader.GetOrdinal("TipoAcceso")),
=======
                    Metodoregistro    = reader.IsDBNull(reader.GetOrdinal("Metodoregistro")) ? 0 : reader.GetInt32(reader.GetOrdinal("Metodoregistro")),
                    Tipoacceso        = reader.IsDBNull(reader.GetOrdinal("Tipoacceso")) ? 0 : reader.GetInt32(reader.GetOrdinal("Tipoacceso")),
>>>>>>> .merge_file_rxGbtu

                };
                list.Add(e);
            }
            reader.Close();
            BD.Desconectar();
            return list;

        }


<<<<<<< .merge_file_imHlpw

=======
>>>>>>> .merge_file_rxGbtu
        /// <summary>
        /// Obtiene colección con la asistecia de un IdEnrol
        /// </summary>
        /// <param name="IdEnroll">Id de la persona enrolada</param>
        /// <returns>Retorna una colección del tipo <code>List/<registroasistencia/></code></returns>
        public List<registroasistencia> Get(int Rut, char Dv)
        { 
            var list = new List<registroasistencia>();
            BD.Conectar();

            BD.CrearComando("call spGetRegistroAsistenciaByRut(@Rut)");
            BD.AsignarParametroEntero("@Rut", Rut);
            DbDataReader dr = BD.EjecutarConsulta();

            DataTable dt = new DataTable();
            dt.Load(dr);
            this.count = dt.Rows.Count;
            DataTableReader reader = new DataTableReader(dt);

            if (this.count <= 0)
                return list;

            while (reader.Read())
            {
                registroasistencia e = new registroasistencia()
                {
                    
                    Idenroll          = reader.IsDBNull(reader.GetOrdinal("IdEnroll")) ? 0 : reader.GetInt32(reader.GetOrdinal("IdEnroll")),
                    Fechahoramarca    = reader.IsDBNull(reader.GetOrdinal("Fechahoramarca")) ? Convert.ToDateTime("19000101") : reader.GetDateTime(reader.GetOrdinal("Fechahoramarca")),
                    Fechahoraregistro = reader.IsDBNull(reader.GetOrdinal("Fechahoraregistro")) ? Convert.ToDateTime("19000101") : reader.GetDateTime(reader.GetOrdinal("Fechahoraregistro")),
                    Ipdispositivo     = reader.IsDBNull(reader.GetOrdinal("Ipdispositivo")) ? "" : reader.GetString(reader.GetOrdinal("Ipdispositivo")),
                    Metodoregistro    = reader.IsDBNull(reader.GetOrdinal("Metodoregistro")) ? 0 : reader.GetInt32(reader.GetOrdinal("Metodoregistro")),
                    Tipoacceso        = reader.IsDBNull(reader.GetOrdinal("Tipoacceso")) ? 0 : reader.GetInt32(reader.GetOrdinal("Tipoacceso")),

                };
                list.Add(e);
            }
            reader.Close();
            BD.Desconectar();
            return list;

        }


        /// <summary>
<<<<<<< .merge_file_imHlpw
        /// 
=======
        /// Graba el registro de asistencia
>>>>>>> .merge_file_rxGbtu
        /// </summary>
        /// <returns>Retorna true en caso de almacenar correctamente los datos en otro caso false</returns>
        public bool Save()
        {
            bool lret = false;

<<<<<<< .merge_file_imHlpw

            return lret;
        }

        /// <summary>
        /// Graba el registro de asistencia
        /// </summary>
        /// <param name="lstMarcas">Colección del tipo <code>List<UsuarioMarcaje></code></param>
        /// <returns>Retorna true en caso de almacenar correctamente los datos en otro caso false</returns>
        public bool Save( List<UsuarioMarcaje> lstMarcas )
        {
            bool lret = false;
            BaseDatos db = new BaseDatos();


            try
            {
                db.Conectar();
                db.ComenzarTransaccion();
                string FechaRegistro = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");

                foreach( UsuarioMarcaje o in lstMarcas)
                {
                    string stmpFecha = o.Anio + "-" +
                                    o.Mes.ToString().PadLeft(2, '0') + "-" +
                                    o.Dia.ToString().PadLeft(2, '0') + " " + 
                                    o.Hora.ToString().PadLeft(2, '0') + ":" + 
                                    o.Minuto.ToString().PadLeft(2, '0') + ":" + 
                                    o.Segundo.ToString().PadLeft(2, '0');

                    //DateTime dFecha = DateTime.ParseExact(stmpFecha, "yyyyMMdd HH:mm:ss", CultureInfo.InvariantCulture);

                    db.CrearComando("call spUpdRegistroAsistencia(@IdEnroll, @FechaRegistro, @FechaMarca, @IpDispositivo, @MetodoMarca, @TipoAcceso)");
                    db.AsignarParametroEntero("@IdEnroll", o.NumeroCredencial);
                    db.AsignarParametroCadena("@FechaRegistro", FechaRegistro);
                    db.AsignarParametroCadena("@FechaMarca", stmpFecha );
                    db.AsignarParametroCadena("@IpDispositivo", GlobalVars.Ip);
                    db.AsignarParametroEntero("@MetodoMarca", (int) o.MetodoMarca);
                    db.AsignarParametroEntero("@TipoAcceso", (int) o.TipoMarca);

                    db.EjecutarComando();              
                    
                }
                lret = true;
            }
            catch (Exception ex )
            {
               db.CancelarTransaccion();
               return lret;
            }
            db.ConfirmarTransaccion();
=======
            return lret;
        }

        public bool Save( List<UsuarioMarcaje> lstMarcas )
        {
            bool lret = false;

            clsRegistroAsistencia obj = new clsRegistroAsistencia();

            // BD.ComenzarTransaccion();
            try
            {
                foreach( UsuarioMarcaje o in lstMarcas)
                {
                    obj.Idenroll          = o.NumeroCredencial;
                    obj.Fechahoraregistro = Convert.ToDateTime(o.Anio + o.Mes.ToString().PadLeft(2, '0') + o.Dia.ToString().PadLeft(2, '0') + " " + o.Hora + ":" +o.Minuto + ":" + o.Segundo );
                    obj.Fechahoramarca    = Convert.ToDateTime(o.Anio + o.Mes.ToString().PadLeft(2, '0') + o.Dia.ToString().PadLeft(2, '0') + " " + o.Hora + ":" + o.Minuto + ":" + o.Segundo);
                    obj.Ipdispositivo     = GlobalVars.Ip;
                    obj.Metodoregistro    = (int)o.MetodoMarca;
                    obj.Tipoacceso        = o.TipoMarca;
                    
                    obj.Save();
                    
                    
                }
                lret = true;

            }
            catch (Exception )
            {
               // BD.CancelarTransaccion();
            }
            // BD.ConfirmarTransaccion();
>>>>>>> .merge_file_rxGbtu
            return lret;

        }

        #endregion


        /// <summary>
        /// Elimina las marcaciones de un IdEnroll
        /// </summary>
        /// <param name="IdEnroll">Id de enrolamiento</param>
        /// <param name="Fecha">Fecha y Hora del registro a eliminar.</param>
        /// <returns>Retorna true en caso de eliminar correctamente los datos en otro caso false</returns>
        public bool Delete(int IdEnroll, DateTime Fecha)
        {
            bool lret = false;

            return lret;
        }


        public bool ExisteRegistroAsistencia(int IdEnroll, DateTime Fecha)
        {
            bool lret = false;

            return lret;
        }
    
    }
}
