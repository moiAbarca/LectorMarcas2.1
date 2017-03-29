using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using ZKSauroAPI;
using SGFDataLayer;
using System.Data.Common;
using LectorMarcas.Utilities;

namespace LectorMarcas
{
    public partial class frmMain : Form
    {
        BaseDatos db = new BaseDatos();
        private ArrayList Reloj=new ArrayList();
        private string Ip;
        private int Port;

        VersionDlls vdll = new VersionDlls();

        public frmMain()
        {
            InitializeComponent();
            ObtenerConfiguracion();
        }
        ZKSauro dispositivo = new ZKSauro(Modelo.X628C);


        private void ObtenerConfiguracion()
        {
            try
            {
                Reloj.Add( ConfigurationManager.AppSettings.Get("RC1").Length > 0 ? ConfigurationManager.AppSettings.Get("RC1") : null );
                Reloj.Add( ConfigurationManager.AppSettings.Get("RC2").Length > 0 ? ConfigurationManager.AppSettings.Get("RC2") : null );
                Reloj.Add( ConfigurationManager.AppSettings.Get("RC3").Length > 0 ? ConfigurationManager.AppSettings.Get("RC3") : null );
                Reloj.Add( ConfigurationManager.AppSettings.Get("RC4").Length > 0 ? ConfigurationManager.AppSettings.Get("RC4") : null );
                Reloj.Add( ConfigurationManager.AppSettings.Get("RC5").Length > 0 ? ConfigurationManager.AppSettings.Get("RC5") : null );
                Reloj.Add( ConfigurationManager.AppSettings.Get("RC6").Length > 0 ? ConfigurationManager.AppSettings.Get("RC6") : null );
            }
            catch ( ConfigurationException ex)
            {
                MessageBox.Show("Error al cargar la configuración del acceso a datos.", "Error Configuracion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            System.Reflection.Assembly vdll = VersionDlls.GetAssemblyDLL("zkemkeeper.dll");

            String Pathdlls = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);
            
            //db.Conectar();
            //db.CrearComando("call prueba(@par1)");
            //db.AsignarParametroEntero("@par1", 3);
            //DbDataReader dr = db.EjecutarConsulta();
            //DataTable dt= new DataTable();
            //dt.Load(dr);
            //int registros = dt.Rows.Count;
            //MessageBox.Show("Número de registros" + registros);
            //DataTableReader reader = new DataTableReader(dt);

            //int resultados = 0;
            //while (reader.Read())
            //{
            //     resultados = reader.IsDBNull(reader.GetOrdinal("resultado")) ? 0 :
            //        reader.GetInt32(reader.GetOrdinal("resultado"));
            //}
            //MessageBox.Show(resultados.ToString());

            if (Reloj.Count > 0)
            {
                string[] aArreglo = Reloj[0].ToString().Split(':');

                Ip   = aArreglo[0].Length > 0 ? aArreglo[0] : null;
                Port = aArreglo[1].Length > 0 ? Convert.ToInt32( aArreglo[1] ) : 0;
            }

            GlobalVars.Ip = Ip;
            GlobalVars.Port = Port;

            if ( Ip == null || Port == 0)
            {
                MessageBox.Show("La configuración del dispositivo no se encuentra realizada.", "Error Configuracion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }
            
            tsIpDispositivo.Text = "IP: " + Ip;


            
        }

        private void tsConfiguracion_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "frmDispositivos").SingleOrDefault<Form>();
            if (existe != null)
            {
                return;
            }

            frmDispositivos frm = new frmDispositivos();
            // frm.MdiParent = this;
            frm.Show();
            Cursor.Current = Cursors.Default;
        }

        private void tsPersonal_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "frmPersonal").SingleOrDefault<Form>();
            if (existe != null)
            {
                return;
            }

            frmPersonal frm = new frmPersonal();
            frm.MdiParent = this;
            frm.Show();
            Cursor.Current = Cursors.Default;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void tsRelojControl_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "frmRelojControl").SingleOrDefault<Form>();
            if (existe != null)
            {
                return;
            }

            frmRelojControl frm = new frmRelojControl();
            frm.MdiParent = this;
            frm.Show();
            Cursor.Current = Cursors.Default;
        }

    }
}
