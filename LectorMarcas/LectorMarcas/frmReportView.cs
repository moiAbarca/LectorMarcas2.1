using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Reporting.WinForms;
using System.Configuration;
using System.Reflection;


namespace LectorMarcas
{
    public enum eTipoReporte
    {
        ReporteLocal,
        ReporteServidor
    }

    public partial class frmReportView : Form
    {

        public class Valor
        {
            public string Name;
            public List<object> Values = new List<object>();

            public Valor(string n, object v)
            {
                this.Name = n;
                this.Values.Add(v);
            }
        }

        /// <summary>
        /// true, indica que el reporte debe leer desde el disco la imagen logo.png
        /// </summary>
        public bool ImagenLoad = false;
        /// <summary>
        /// true, indica si el reporte es incrustado. Si no es false.
        /// </summary>
        public bool RptEmbebed = false;
        /// <summary>
        /// true, indica si el reporte principal contiene un subreporte.
        /// </summary>
        public bool SubRptEnable = false;

        public DataTable dataTable = new DataTable();
        /// <summary>
        /// 
        /// </summary>
        public eTipoReporte TipoReporte = eTipoReporte.ReporteLocal;
        /// <summary>
        /// Tipo de visualizacion del Visor de reportes
        /// </summary>
        public DisplayMode displayMode;
        /// <summary>
        /// Reporte incluye la carpeta donde se distribuyen los reportes dentro del disco o en caso de ser un reporte incrustado en una DLL la ruta completa del Ensamblado
        /// Ej.: Reporte\\Reporte.dll o SGFReport.Embeddeb.Reporte.dll
        /// </summary>
        public string Reporte;
        /// <summary>
        /// Subreporte dentro del informe padre.
        /// </summary>
        public string SubReporte;  
        /// <summary>
        /// Datos para la representación del reporte.
        /// </summary>
        public List<ReportDataSource> SetDeDatos = new List<ReportDataSource>();

        //private ReportParameter[] parametros;
        /// <summary>
        /// 
        /// </summary>
        public List<Valor> Valores               = new List<Valor>();
        /// <summary>
        /// Ruta de servidor de reportes
        /// </summary>
        public string sReportServer = null;
        /// <summary>
        /// Ruta del reporte
        /// </summary>
        public string sReportPath = null;

        ReportParameter[] rptParametros = null;

        public frmReportView()
        {
            InitializeComponent();
        }

        private void frmReportView_Load(object sender, EventArgs e)
        {
            // Variable para acceso al ensamblado
            //
            Assembly assembly;

            // Arreglo de parámetros
            //
            

            // Image parametro por defecto
            //
            if (ImagenLoad)
            {
                rptParametros = new ReportParameter[Valores.Count() + 1];

                ReportParameter img = new ReportParameter("img_logo", "file:\\" + Application.StartupPath + "\\Resources\\logoImpresion.png", true);

                // Seteo de parametros
                //

                // Se asigna Parametro por defecto
                //
                rptParametros[0] = img;
            }
            // Cargar parametros
            //
            int i = 1;
            foreach (Valor o in Valores)
            {
                ReportParameter param = new ReportParameter(o.Name, o.Values[0].ToString(), true);
                rptParametros[i++] = param;
            }
            //


            // Reporte local
            //
            if (this.TipoReporte == eTipoReporte.ReporteLocal)
            {
                this.reportViewer1.LocalReport.DataSources.Clear();
                //
                //
                foreach (ReportDataSource o in SetDeDatos)
                    this.reportViewer1.LocalReport.DataSources.Add(o);

                //s
                //
                if (dataTable.Rows.Count > 0)
                    this.reportViewer1.LocalReport.DataSources.Add( new ReportDataSource("DataSet1", dataTable) );

                this.reportViewer1.SetDisplayMode(this.displayMode);


                // Si los reportes estan incrustados en una DLL
                //
                if (RptEmbebed)
                {
                    // Configuración para recuperar los reportes desde la dll
                    //
                    assembly = Assembly.LoadFrom("SGFReports.dll"); // Cargar el ensamblado
                    // 
                    Stream stream = assembly.GetManifestResourceStream("SGFReports.Embedded." + this.Reporte);
                    this.reportViewer1.LocalReport.LoadReportDefinition(stream);

                    // Si el reporte es incrustado y tiene un sub reporte 
                    //
                    if (SubRptEnable)
                    {
                        //this.reportViewer1.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;
                        Stream streamSubReport = assembly.GetManifestResourceStream("SGFReports.Embedded." + this.SubReporte);
                        //this.reportViewer1.LocalReport.LoadSubreportDefinition("SubReporte", streamSubReport);
                        this.reportViewer1.LocalReport.LoadSubreportDefinition("SGFReports.Embedded." + this.SubReporte, streamSubReport);
                        // this.reportViewer1.LocalReport.ReportEmbeddedResource = "SGFReports.Embedded." + this.SubReporte;
                    }
                }
                else
                {
                    // Si los reportes no estan incrustados, y se proveen en una carpeta
                    //

                    // Validar que el reporte exista en el disco
                    //
                    string Path = Application.StartupPath + "\\" + Reporte;
                    if (!File.Exists(Path))
                    {
                        MessageBox.Show("Ups!\r No he podido encontrar el archivo de reporte. Para solucionar el problema comuniquese con el desarrollador del sistema,\r este problema puede deberse a que alguien haya borrado el archivo inconsientemente.", "Diálogo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    this.reportViewer1.LocalReport.ReportPath = Path;
                }
                this.reportViewer1.LocalReport.EnableExternalImages = true; // Habilitar el enlace con imagenes externas

                // Si hay parametros se agregan al reporte
                //
                // if (rptParametros.Count() > 0)
                if (rptParametros != null)
                {
                    this.reportViewer1.LocalReport.SetParameters(rptParametros);
                }

                if (SetDeDatos.Count() > 0)
                {
                    this.bindingSource1.DataSource = SetDeDatos;
                }
                this.reportViewer1.RefreshReport();
            }
            // Reporte servidor
            //
            else if( this.TipoReporte == eTipoReporte.ReporteServidor)
            {
                this.reportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = new System.Net.NetworkCredential("administrador", "Zkxthy27", "IMLG");

                if ( sReportServer != null )
                    this.reportViewer1.ServerReport.ReportServerUrl = new Uri(sReportServer);
                if ( sReportPath != null )
                    this.reportViewer1.ServerReport.ReportPath = sReportPath;

                this.reportViewer1.Visible = true;
                this.reportViewer1.ShowParameterPrompts = true;
                this.reportViewer1.ShowCredentialPrompts = true;

                this.reportViewer1.ServerReport.Refresh();
                this.reportViewer1.RefreshReport();

                // Generar PDF
                //
                /*
                string deviceInfo = "";
                Warning[] warnings = null;
                string[] streamids = null;
                string mimeType = null;
                string encoding = null;
                string extension = null;
                byte[] bytes = null;

                bytes = this.reportViewer1.ServerReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                
                Response.ContentType = "Application/pdf";
                Response.BinaryWrite(ms.ToArray());
                Response.End();
                */

            }
        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e) 
        { 
            //Set e.DataSources here depending on e.ReportPath 
        }

    }
}
