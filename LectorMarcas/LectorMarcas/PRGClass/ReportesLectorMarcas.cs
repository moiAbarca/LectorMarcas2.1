using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LectorMarcas.Utilities;
using LectorMarcas.PRGClass;
using SGFDataLayer;
using System.Data;
using System.Data.Common;
using LectorMarcas;

using ZKSauroAPI;

namespace LectorMarcas.PRGClass
{
    public class ReportesLectorMarcas : DBClass.RptGeneraMarcasDetalle
    {

        BaseDatos BD = new BaseDatos();

        #region propiedades
        int count;

        public int Count
        {
            get { return count; }
        }
        #endregion


        /// <summary>
        /// Obtiene el detalle de las marcaciones de los enrollados
        /// </summary>
        /// <param name="Periodo">Año y mes que se desea obtener</param>
        /// <param name="IdEnroll">Id de enrolamiento, si es cero trae todos los enrolados de un periodo</param>
        /// <returns>Retorna una colección con las marcaciones del idEnroll</returns>
        public List<DBClass.RptGeneraMarcasDetalle> ObtenerReporteGeneralMarcasDetalle(string Periodo, int IdEnroll)
        {
            var obj = new List<DBClass.RptGeneraMarcasDetalle>();

            BD.Conectar();

            BD.CrearComando("call sp_GetAsistenciaByPeriodo(@Periodo, @IdEnroll)");
            BD.AsignarParametroCadena("@Periodo", Periodo);
            BD.AsignarParametroEntero("@IdEnroll", IdEnroll);
            

            DbDataReader dr = BD.EjecutarConsulta();

            DataTable dt = new DataTable();
            dt.Load(dr);
            this.count = dt.Rows.Count;
            DataTableReader reader = new DataTableReader(dt);

            if (this.count <= 0)
                return null;

            while (reader.Read())
            {
                DBClass.RptGeneraMarcasDetalle e = new DBClass.RptGeneraMarcasDetalle()
                {
                    IdEnroll                  = reader.IsDBNull(reader.GetOrdinal("IdEnroll")) ? 0 : reader.GetInt32(reader.GetOrdinal("IdEnroll")),
                    Nombre                    = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? "" : reader.GetString(reader.GetOrdinal("Nombre")),
                    FechaHoraMarca            = reader.IsDBNull(reader.GetOrdinal("FechaHoraMarca")) ? "" : reader.GetDateTime(reader.GetOrdinal("FechaHoraMarca")).ToString("yyyyMMdd HH:mm:ss"),
                    FechaHoraRegistro         = reader.IsDBNull(reader.GetOrdinal("FechaHoraRegistro")) ? "" : reader.GetDateTime(reader.GetOrdinal("FechaHoraRegistro")).ToString("yyyyMMdd HH:mm:ss"),
                    IpDispositivo             = reader.IsDBNull(reader.GetOrdinal("IpDispositivo")) ? "" : reader.GetString(reader.GetOrdinal("IpDispositivo")),
                    TipoAcceso                = (reader.IsDBNull(reader.GetOrdinal("TipoAcceso")) ? TipoMarcas.None : (TipoMarcas)reader.GetInt32(reader.GetOrdinal("TipoAcceso")) ),
                    MetodoRegistro            = reader.IsDBNull(reader.GetOrdinal("MetodoRegistro")) ? MetodoMarcas.None  : (MetodoMarcas)reader.GetInt32(reader.GetOrdinal("MetodoRegistro")),
                    // DescripcionTipoAcceso     = TipoAccesoDescripcion,
                    // DescripcionMetodoRegistro = MetodoRegistroDescripcion,
                };
                
                obj.Add(e);
            }

            reader.Close();
            BD.Desconectar();

            return obj;

        }

    }
}
