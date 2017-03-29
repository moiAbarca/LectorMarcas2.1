using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectorMarcas.DBClass;
using SGFDataLayer;
using System.Data.Common;
using System.Data;

using SGFBussinesLayer;

namespace LectorMarcas.PRGClass
{
    public class clsEnrolados : Enrolados
    {
        BaseDatos BD = new BaseDatos();

        #region propiedades
        int count;

        public int Count
        {
            get { return count; }
        }
        #endregion

        #region metodos públicos
        public void Clear()
        { 
            this.IdEnroll= 0;

            this.Rut = 0;
            this.Dv = "";

            this.Nombre="";
            this.Nacionalidad="";
            this.FechaNacimiento  = Convert.ToDateTime("19000101");
            this.Telefonos = "";
            this.AltaLaboral = Convert.ToDateTime("19000101");
            this.Direccion = "";
            this.Genero = "";
            this.Foto = null;

        }

        public List<Enrolados> Get(string Nombre) {
            var lst = new List<Enrolados>();




            return lst;
        }

        public List<Enrolados> Get(int IdEnroll)
        { 
            var list = new List<Enrolados>();
            BD.Conectar();

            BD.CrearComando("call spGetEnrolados(@IdEnroll)");
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
                Enrolados e = new Enrolados()
                {
                    IdEnroll = reader.IsDBNull(reader.GetOrdinal("IdEnroll")) ? 0 : reader.GetInt32(reader.GetOrdinal("IdEnroll")),
                    Rut = reader.IsDBNull(reader.GetOrdinal("Rut")) ? 0 : reader.GetInt32(reader.GetOrdinal("Rut")),
                    Dv = reader.IsDBNull(reader.GetOrdinal("Dv")) ? "" : reader.GetString(reader.GetOrdinal("Dv")),
                    Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? "" : reader.GetString(reader.GetOrdinal("Nombre")),
                    Nacionalidad = reader.IsDBNull(reader.GetOrdinal("Nacionalidad")) ? "" : reader.GetString(reader.GetOrdinal("Nacionalidad")),
                    FechaNacimiento = reader.IsDBNull(reader.GetOrdinal("FechaNacimiento")) ? Convert.ToDateTime("19000101") : reader.GetDateTime(reader.GetOrdinal("FechaNacimiento")),
                    Telefonos = reader.IsDBNull(reader.GetOrdinal("Telefonos")) ? "" : reader.GetString(reader.GetOrdinal("Telefonos")),
                    AltaLaboral = reader.IsDBNull(reader.GetOrdinal("AltaLaboral")) ? Convert.ToDateTime("19000101") : reader.GetDateTime(reader.GetOrdinal("AltaLaboral")),
                    Direccion = reader.IsDBNull(reader.GetOrdinal("Direccion")) ? "" : reader.GetString(reader.GetOrdinal("Direccion")),
                    Genero = reader.IsDBNull(reader.GetOrdinal("Genero")) ? "" : reader.GetString(reader.GetOrdinal("Genero")),
                   // Foto = reader.IsDBNull(reader.GetOrdinal("Foto")) ? byte[null] : reader.GetByte(reader.GetOrdinal("Foto")),
                };
                list.Add(e);
            }
            if (list.Count == 1)
            {
                this.IdEnroll = list[0].IdEnroll;
                this.Rut = list[0].Rut;
                this.Dv = list[0].Dv;
                this.Nombre = list[0].Nombre;
                this.Nacionalidad = list[0].Nacionalidad;
                this.FechaNacimiento = list[0].FechaNacimiento;
                this.Telefonos = list[0].Telefonos;
                this.AltaLaboral = list[0].AltaLaboral;
                this.Direccion = list[0].Direccion;
                this.Genero = list[0].Genero;
                this.Foto = list[0].Foto;
            }

            reader.Close();
            BD.Desconectar();
            return list;

        }

        #endregion


        public bool ExistePersona(int IdEnroll)
        {

            Boolean lRet = false;
            try
            {
                if (IdEnroll <= 0) throw new ReglasNegocioException("El Id del Cliente es inválido");
                BD.Conectar();
                BD.CrearComando("call spGetEnrolados @IdEnroll");
                BD.AsignarParametroEntero("@IdEnroll", IdEnroll);
                DbDataReader dr = BD.EjecutarConsulta();

                DataTable dt = new DataTable();
                //Convertimos el DataRead a DataTable para obtener el RowsAffect
                DataTableReader reader = new DataTableReader(dt);
                dt.Load(dr);
                this.count = dt.Rows.Count;

                if (this.count <= 0)
                {
                    return lRet;
                }
                lRet = true;

                reader.Close();
                BD.Desconectar();
            }
            catch (BaseDatosException)
            {

                throw new ReglasNegocioException("Error al acceder a la base de datos para validar la existencia del registro");
            }
            catch (ReglasNegocioException ex)
            {
                throw new ReglasNegocioException("Error a obtener los datos" + ex.Message);
            }
            return lRet;
        }



        public  Boolean Save()
        {
            Boolean lRet = true;
            try
            {
                BD.Conectar();
                BD.CrearComando("call spUpdEnrolados(@IdEnroll, @Rut, @Dv, @Nombre, @Nacionalidad, @FechaNacimiento, @Telefonos, @AltaLaboral, @Direccion, @Genero, @Foto)");
                BD.AsignarParametroEntero("@IdEnroll", this.IdEnroll);
                BD.AsignarParametroEntero("@Rut", this.Rut);
                BD.AsignarParametroCadena("@Dv", this.Dv);
                BD.AsignarParametroCadena("@Nombre", this.Nombre);
                BD.AsignarParametroCadena("@Nacionalidad", this.Nacionalidad);
                BD.AsignarParametroCadena("@FechaNacimiento", this.FechaNacimiento.ToString("yyyyMMdd"));
                BD.AsignarParametroCadena("@Telefonos", this.Telefonos);
                BD.AsignarParametroCadena("@AltaLaboral", this.AltaLaboral.ToString("yyyyMMdd"));
                BD.AsignarParametroCadena("@Direccion", this.Direccion);
                BD.AsignarParametroCadena("@Genero", this.Genero.ToString());
                BD.AsignarParametroFoto("@Foto", "");
                BD.EjecutarComando();
            }
            catch (BaseDatosException)
            {

                throw new ReglasNegocioException("Error al guardar datos en la base de datos.");
            }
            catch (ReglasNegocioException)
            {
                lRet = false;
                throw new ReglasNegocioException("Error al actualizar los datos");
            }
            finally
            {
                BD.Desconectar();
            }
            return lRet;
        }
    }
}
