using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using ZKSauroAPI;
using System.Windows.Forms;


namespace LectorMarcas
{
    public class GlobalVars
    {
        private static string _currentIp = string.Empty;
        private static int _currentPort  = 0;

        private static ArrayList _reloj = new ArrayList();

        public GlobalVars()
        {
            ObtenerConfiguracion();
        }

        #region Public Properties
        public static string Ip
        {
            get { return _currentIp; }
            set { _currentIp = value; }
        }
        public static int Port
        {
            get { return _currentPort; }
            set { _currentPort = Port; }
        }
        #endregion

        private static void ObtenerConfiguracion()
        {
            try
            {
                _reloj.Add(ConfigurationManager.AppSettings.Get("RC1").Length > 0 ? ConfigurationManager.AppSettings.Get("RC1") : null);
                _reloj.Add(ConfigurationManager.AppSettings.Get("RC2").Length > 0 ? ConfigurationManager.AppSettings.Get("RC2") : null);
                _reloj.Add(ConfigurationManager.AppSettings.Get("RC3").Length > 0 ? ConfigurationManager.AppSettings.Get("RC3") : null);
                _reloj.Add(ConfigurationManager.AppSettings.Get("RC4").Length > 0 ? ConfigurationManager.AppSettings.Get("RC4") : null);
                _reloj.Add(ConfigurationManager.AppSettings.Get("RC5").Length > 0 ? ConfigurationManager.AppSettings.Get("RC5") : null);
                _reloj.Add(ConfigurationManager.AppSettings.Get("RC6").Length > 0 ? ConfigurationManager.AppSettings.Get("RC6") : null);
            }
            catch (ConfigurationException ex)
            {
                MessageBox.Show("Error al cargar la configuración del acceso a datos.", "Error Configuracion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        public static ArrayList Dispositivos()
        {
            ObtenerConfiguracion();

            return _reloj;
        }

        /// <summary>
        /// Validador de rut
        /// </summary>
        /// <param name="rut">parte numerica del rut</param>
        /// <param name="digito">digito verificador</param>
        /// <returns></returns>
        public static Boolean ValidaRut(int rut, char digito)
        {
            Boolean lRet = false;
            int Digito;
            int Contador;
            int Multiplo;
            int Acumulador;

            Contador = 2;
            Acumulador = 0;

            while (rut != 0)
            {
                Multiplo = (rut % 10) * Contador;
                Acumulador = Acumulador + Multiplo;
                rut = rut / 10;
                Contador++;
                if (Contador == 8) Contador = 2;
            }
            Digito = 11 - (Acumulador % 11);

            if (Digito == 10)
            {
                lRet = 'K' == digito ? true : false;
            }
            else
                if (Digito == 11)
                {
                    lRet = '0' == digito ? true : false;
                }
                else
                {
                    lRet = Digito.ToString() == digito.ToString() ? true : false;
                }
            return lRet;
        }

        public static string MetodoMarcaDescripcion(ZKSauroAPI.MetodoMarcas _metodomarca)
        {
            string sret = string.Empty;
            switch (_metodomarca)
            {
                case MetodoMarcas.PF_OR_PW_OR_RF:
                    sret = "PF o PW o RF";
                    break;
                case MetodoMarcas.FP:
                    sret = "PF";
                    break;
                case MetodoMarcas.PIN:
                    sret = "PIN";
                    break;
                case MetodoMarcas.PW:
                    sret = "PW";
                    break;
                case MetodoMarcas.RF:
                    sret = "RF";
                    break;
                case MetodoMarcas.FP_OR_PW:
                    sret = "FP o PW";
                    break;
                case MetodoMarcas.FP_OR_RF:
                    sret = "FP o RF";
                    break;
                case MetodoMarcas.PW_OR_RF:
                    sret = "PW o RF";
                    break;
                case MetodoMarcas.PIN_AND_FP:
                    sret = "PIN y FP";
                    break;
                case MetodoMarcas.FP_AND_PW:
                    sret = "FP y PW";
                    break;
                case MetodoMarcas.FP_AND_RF:
                    sret = "FP y RF";
                    break;
                case MetodoMarcas.PW_AND_RF:
                    sret = "PW y RF";
                    break;
                case MetodoMarcas.FP_AND_PW_AND_RF:
                    sret = "FP y PW y RF";
                    break;
                case MetodoMarcas.PIN_AND_FP_AND_PW:
                    sret = "PIN y FP y PW";
                    break;
                case MetodoMarcas.FP_AND_RF_OR_PIN:
                    sret = "FP y RF o PIN";
                    break;
            }
            return sret;
        }

        public static string TipoMarcasDescripcion(ZKSauroAPI.TipoMarcas _tipoMarca)
        {
            string sret = string.Empty;

            switch (_tipoMarca)
            {
                case TipoMarcas.CheckIn:
                    sret = "Entrada";
                    break;
                case TipoMarcas.CheckOut:
                    sret = "Salida";
                    break;
                case TipoMarcas.BreakIn:
                    sret = "Entrada Colación";
                    break;
                case TipoMarcas.BreakOut:
                    sret = "Salida Colación";
                    break;
                case TipoMarcas.Ot_In:
                    sret = "Entrada";
                    break;
                case TipoMarcas.Ot_Out:
                    sret = "Salida";
                    break;
            }
            return sret;
        }

    }



}
