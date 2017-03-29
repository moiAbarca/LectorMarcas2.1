using System;
using System.Runtime.CompilerServices;

namespace ZKSauroAPI
{
    public class UsuarioMarcaje
    {
        private ZKSauroAPI.MarcajeOperativo a;

        private int _tipoMarca;

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