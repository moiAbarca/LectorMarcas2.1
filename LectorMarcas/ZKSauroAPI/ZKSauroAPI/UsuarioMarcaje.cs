using System;
using System.Runtime.CompilerServices;

namespace ZKSauroAPI
{
    public class UsuarioMarcaje
    {
        private ZKSauroAPI.MarcajeOperativo a;


        private int _tipoMarca;
        private MetodoMarcas _metodomarca;

        public int Anio
        {
            get;
            set;
        }

        public int Dia
        {
            get;
            set;
        }

        public int Hora
        {
            get;
            set;
        }

        public int TipoMarca
        {
            get { return _tipoMarca; }
            set { _tipoMarca = value; }
        }

        public MetodoMarcas MetodoMarca
        {
            get { return _metodomarca; }
            set { _metodomarca = value; }
        }

        public string MetodoMarcaDescripcion
        {
            get
            {
                string sret = string.Empty;
                switch(_metodomarca)
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

        public string TipoMarcasDescripcion
        {
            get
            {
                string sret = string.Empty;

                switch (_tipoMarca)
                {
                    case (int)TipoMarcas.CheckIn:
                        sret = "Entrada";
                        break;
                    case (int)TipoMarcas.CheckOut:
                        sret = "Salida";
                        break;
                    case (int)TipoMarcas.BreakIn:
                        sret = "Entrada Colación";
                        break;
                    case (int)TipoMarcas.BreakOut:
                        sret = "Salida Colación";
                        break;
                    case (int)TipoMarcas.Ot_In:
                        sret = "Entrada";
                        break;
                    case (int)TipoMarcas.Ot_Out:
                        sret = "Salida";
                        break;
                }
                return sret;
            }
        }

        public ZKSauroAPI.MarcajeOperativo MarcajeOperativo
        {
            get
            {
                return this.a;
            }
            set
            {
                this.a = value;
            }
        }

        public int Mes
        {
            get;
            set;
        }

        public int Minuto
        {
            get;
            set;
        }

        public int NumeroCredencial
        {
            get;
            set;
        }

        public int Segundo
        {
            get;
            set;
        }

        public UsuarioMarcaje()
        {
        }

        public override string ToString()
        {
            string[] str = new string[14];
            str[0] = this.NumeroCredencial.ToString();
            str[1] = "|";
            int dia = this.Dia;
            str[2] = dia.ToString().PadLeft(2, '0');
            str[3] = "/";
            int mes = this.Mes;
            str[4] = mes.ToString().PadLeft(2, '0');
            str[5] = "/";
            str[6] = this.Anio.ToString();
            str[7] = " ";
            str[8] = this.Hora.ToString();
            str[9] = ":";
            str[10] = this.Minuto.ToString();
            str[11] = ":";
            int segundo = this.Segundo;
            str[12] = segundo.ToString().PadLeft(2, '0');
            str[13] = (this.MarcajeOperativo != null ? string.Concat("|", this.MarcajeOperativo.ToString()) : string.Empty);
            return string.Concat(str);
        }
    }
}