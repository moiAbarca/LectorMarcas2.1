using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorMarcas.DBClass
{
    public class registroasistencia
    {
        private System.Int32 idenroll;
        public System.Int32 Idenroll
        {
            get
            {
                return idenroll;
            }
            set
            {
                idenroll = value;
            }
        }
        private System.DateTime fechahoraregistro;
        public System.DateTime Fechahoraregistro
        {
            get
            {
                return fechahoraregistro;
            }
            set
            {
                fechahoraregistro = value;
            }
        }
        private System.DateTime fechahoramarca;
        public System.DateTime Fechahoramarca
        {
            get
            {
                return fechahoramarca;
            }
            set
            {
                fechahoramarca = value;
            }
        }
        private System.String ipdispositivo;
        public System.String Ipdispositivo
        {
            get
            {
                return ipdispositivo;
            }
            set
            {
                ipdispositivo = value;
            }
        }
        private System.Int32 tipoacceso;
        public System.Int32 Tipoacceso
        {
            get
            {
                return tipoacceso;
            }
            set
            {
                tipoacceso = value;
            }
        }
        private System.Int32 metodoregistro;
        public System.Int32 Metodoregistro
        {
            get
            {
                return metodoregistro;
            }
            set
            {
                metodoregistro = value;
            }
        }
    }
}
