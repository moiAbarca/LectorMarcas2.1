using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZKSauroAPI;

namespace LectorMarcas.DBClass
{
    public class RptGeneraMarcasDetalle 
    {
        private TipoMarcas _tipoAcceso = TipoMarcas.None;
        private MetodoMarcas _metodoRegistro = MetodoMarcas.None;

        public int IdEnroll { get; set; }
        public string Nombre  { get; set; }
        public string FechaHoraRegistro  { get; set; }
        public string FechaHoraMarca  { get; set; }
        public string IpDispositivo  { get; set; }
        public TipoMarcas TipoAcceso  { get { return _tipoAcceso; } set { _tipoAcceso = value;} }
        // public string DescripcionTipoAcceso  { get; set; }
        public MetodoMarcas MetodoRegistro  { get { return _metodoRegistro; } set { _metodoRegistro = value;}  }
        // public string DescripcionMetodoRegistro  { get ; set; }

        public string DescripcionMetodoRegistro
        {
            get
            {
                string sret = string.Empty;
                switch (_metodoRegistro)
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
        }

        public string DescripcionTipoAcceso
        {
            get
            {
                string sret = string.Empty;

                switch (_tipoAcceso)
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
}
