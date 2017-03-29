using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorMarcas.DBClass
{
    public class Personal
    {

        public Personal()
        {

        }

        #region Properties
        // var privadas 
        //
        private int _id;
        private string _rut;
        private char _dv;
        private string _nombre;
        private string _nacionalidad;
        private DateTime _fnacimiento;
        private string _telefonos;
        private DateTime _altalaboral;
        private string _direccion;
        private char _genero;
        private byte[] _foto;

        public int IdEnroll
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Rut
        {
            get { return _rut; }
            set { 
                    if ( this.ValidaRut() )
                        _rut = value;
                    else
                        throw new Exception(); 
            }
        }

        public char Dv
        {
            get { return _dv; }
            set { _dv = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Nacionalidad
        {
            get { return _nacionalidad; }
            set { _nacionalidad = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return _fnacimiento; }
            set { _fnacimiento = value; }
        }

        public string Telefonos
        {
            get { return _telefonos; }
            set { _telefonos = value; }
        }

        public DateTime AltaLaboral
        {
            get { return _altalaboral; }
            set { _altalaboral = value; }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public char Genero
        {
            get { return _genero; }
            set { _genero = value; }
        }

        public byte[] Foto
        {
            get { return _foto; }
            set { _foto = value; }
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Obtener datos de una persona enrolada o una lista de registros del personal enrollado
        /// </summary>
        /// <param name="nIdEnroll">Si especifica cero, se devuelve una lista completa de las personas enroladas, de lo contrario se debuelve la información del id especificado.</param>
        /// <returns>Retorna una colección del tipo List/<Persona/></returns>
        public List<Personal> ObtenerPersonal(int nIdEnroll)
        {
            List<Personal> lst = new List<Personal>();


            return lst;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Validación del rut
        /// </summary>
        /// <returns>Retorna true cuando el rut es correcto, de lo contrario false.</returns>
        internal bool ValidaRut()
        {
            Int32 Rut = 0;
            bool lret = false;

            int Digito;
            int Contador;
            int Multiplo;
            int Acumulador;

            Contador = 2;
            Acumulador = 0;

            while (Rut != 0)
            {
                Multiplo = (Rut % 10) * Contador;
                Acumulador = Acumulador + Multiplo;
                Rut = Rut / 10;
                Contador++;
                if (Contador == 8) Contador = 2;
            }
            Digito = 11 - (Acumulador % 11);

            if (Digito == 10)
            {
                lret = 'K' == _dv ? true : false;
            }
            else
                if (Digito == 11)
                {
                    lret = '0' == _dv ? true : false;
                }
                else
                {
                    lret = Digito.ToString() == _dv.ToString() ? true : false;
                }
            return lret;

        }
        #endregion

    }
}
