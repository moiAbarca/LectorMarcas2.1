using System;
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
using LectorMarcas.Utilities;
using LectorMarcas.PRGClass;

using Microsoft.Reporting.WinForms;

namespace LectorMarcas
{
    public partial class frmRelojControl : Form
    {

        ZKSauro dispositivo = new ZKSauro(Modelo.X628C);

        public frmRelojControl()
        {
            InitializeComponent();
        }

        private void tsDescarga_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            dgMarcas.Rows.Clear();

            // Leer el dispositivo desde el config
            //
            ShowStatusBar( lblStatus, "Conectando con el dispositivo.", Color.Khaki);

            if (!dispositivo.DispositivoConectar(GlobalVars.Ip, 0, false))
            {
                CambiaEstadoDispositivo(Properties.Resources.Nok);
                MessageBox.Show(dispositivo.ERROR);
            }
            // Cambiar icono del estado en el status bar
            //
            CambiaEstadoDispositivo( Properties.Resources.Ok );

            // Si se obtienen correctamente las marcaciones.
            // 1° Se deben almacenar los datos en la base de datos.
            // 2° Se deben Desplegar los datos en la grilla del formulario.
            // 3° Se debe limpiar el log de marcas.

            ShowStatusBar(lblStatus, "Leyendo datos desde el reloj", Color.Khaki);
            if ( !dispositivo.DispositivoObtenerRegistrosAsistencias() )
            {
                MessageBox.Show("No existen registros nuevos en el reloj.", "Diálogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Almacenar datos en la tabla de Marcas
            //
            ShowStatusBar( lblStatus, "Almacenando datos de marcaciones.", Color.Khaki);

            clsRegistroAsistencia ra = new clsRegistroAsistencia();
            if (ra.Save(dispositivo.ListaMarcajes))
            {
                ShowStatusBar( lblStatus, "Desplegando datos.", Color.Khaki);
                // Desplegar los datos en el DataView
                //
                clsEnrolados enr = new clsEnrolados();
                foreach (UsuarioMarcaje d in dispositivo.ListaMarcajes)
                {
                    string Nombres = string.Empty;

                    if (enr.Get(d.NumeroCredencial).Count == 1)
                        Nombres = enr.Nombre;

                    dgMarcas.Rows.Add(
                        d.NumeroCredencial,
                        Nombres,
                        d.TipoMarcasDescripcion,
                        d.Dia.ToString().PadLeft(2, '0') + "/" + d.Mes.ToString().PadLeft(2, '0') + "/" + d.Anio,
                        d.Hora.ToString().PadLeft(2, '0') + ":" + d.Minuto.ToString().PadLeft(2, '0'),
                        d.MetodoMarcaDescripcion
                    );
                }

                // Limpiar los log del reloj control
                //
                ShowStatusBar( lblStatus, "Limpiando registros del dispositivo.", Color.Khaki);
                if (!dispositivo.DispositivoBorrarRegistrosAsistencias())
                {
                    MessageBox.Show("No se pudieron eliminar los registros del reloj.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Cursor.Current = Cursors.Default;

                ShowStatusBar(lblStatus, "OK!", Color.DodgerBlue);
                MessageBox.Show("El proceso termino correctamente!\nSe recuperaron " + dispositivo.ListaMarcajes.Count + " registros desde el reloj.", "Diálogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudieron almacenar los datos del Reloj Control.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }



        public void CambiaEstadoDispositivo(System.Drawing.Image img)
        {
            StatusStrip control = (StatusStrip)this.MdiParent.Controls["statusStrip1"];
            control.Items["tssEstado"].Image = img;
        }

        private void frmRelojControl_Load(object sender, EventArgs e)
        {
            // Inicializa controles
            dpDesde.Value = DateTime.Now;
            dpHasta.Value = DateTime.Now;

            ShowStatusBar(lblStatus, string.Empty);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabAdmReg_Click(object sender, EventArgs e)
        {
            // Cargar personal en combo
            clsEnrolados obj = new clsEnrolados();
            List<DBClass.Enrolados> lst;

            lst = obj.Get(0);
            lst.Insert(0, new DBClass.Enrolados { IdEnroll = 0, Nombre = "Todos" });

            cmbPersonal.ValueMember = "IdEnroll";
            cmbPersonal.DisplayMember = "Nombre";
            cmbPersonal.DataSource = lst;
        }

        private void cmbPernonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( cmbPersonal.SelectedIndex >= 0)
            {
                ShowStatusBar(lblStatusAdmReg, "Cargando marcaciones.", Color.Khaki);
                dgRegAsistencia.Rows.Clear();

                clsRegistroAsistencia obj = new clsRegistroAsistencia();
                List<DBClass.registroasistencia> lst =  new List<DBClass.registroasistencia>();

                lst = obj.Get( (int)cmbPersonal.SelectedValue, dpDesde.Value.ToString("yyyyMMdd"), dpHasta.Value.ToString("yyyyMMdd") );
                foreach (DBClass.registroasistencia o in lst)
                {
                    clsEnrolados enr = new clsEnrolados();
                    string Nombre = string.Empty;

                    if (enr.Get(o.Idenroll).Count == 1)
                        Nombre = enr.Nombre;

                    dgRegAsistencia.Rows.Add(
                        o.Idenroll,
                        Nombre,
                        o.Fechahoramarca,
                        GlobalVars.TipoMarcasDescripcion( (TipoMarcas) o.Tipoacceso),
                        GlobalVars.MetodoMarcaDescripcion( (MetodoMarcas) o.Metodoregistro)
                   );
                }
                ShowStatusBar(lblStatusAdmReg, "OK!", Color.DodgerBlue);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        public void ShowStatusBar(Control lblStatus, string message, Color color = default(Color))
        {
            if (message.Trim() == string.Empty)
            {
                lblStatus.Visible = false;
                return;
            }

            lblStatus.Visible = true;
            lblStatus.Text = message;
            lblStatus.ForeColor = Color.Black;

            if (color != null)
                lblStatus.BackColor = color;

            //if (type)
            //    lblStatus.BackColor = Color.FromArgb(79, 208, 154);
            //else
            //    lblStatus.BackColor = Color.FromArgb(230, 112, 134);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Reporte( DisplayMode.PrintLayout );
        }



        private void Reporte(DisplayMode modo)
        {
            Cursor.Current = Cursors.WaitCursor;

            ReportesLectorMarcas o = new ReportesLectorMarcas();

            frmReportView frm = new frmReportView();

            frm.displayMode = modo;
            frm.WindowState = FormWindowState.Maximized;
            frm.Reporte = "Reportes\\rptGeneralMarcasDetalle.rdlc";
            frm.RptEmbebed = false;
            frm.ImagenLoad = false;

            // Parametros para obtener los datos
            List<DBClass.RptGeneraMarcasDetalle> cl = o.ObtenerReporteGeneralMarcasDetalle( "201703", 0);
            if (cl.Count == 0)
            {
                MessageBox.Show("No hay datos para mostrar en el reporte.");
                Cursor.Current = Cursors.Default;
                return;
            }
            frm.SetDeDatos.Add(new ReportDataSource("DataSet1", cl));
            frm.Show();

            Cursor.Current = Cursors.Default;
        }


    }
}
using System;
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
using LectorMarcas.Utilities;
using LectorMarcas.PRGClass;

namespace LectorMarcas
{
    public partial class frmRelojControl : Form
    {

        ZKSauro dispositivo = new ZKSauro(Modelo.X628C);

        public frmRelojControl()
        {
            InitializeComponent();
        }

        private void tsDescarga_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            dgMarcas.Rows.Clear();

            // Leer el dispositivo desde el config
            //
            ShowStatusBar("Conectando con el dispositivo.", Color.Khaki);

            if (!dispositivo.DispositivoConectar(GlobalVars.Ip, 0, false))
            {
                CambiaEstadoDispositivo(Properties.Resources.Nok);
                MessageBox.Show(dispositivo.ERROR);
            }
            // Cambiar icono del estado en el status bar
            //
            CambiaEstadoDispositivo( Properties.Resources.Ok );

            // Si se obtienen correctamente las marcaciones.
            // 1° Se deben almacenar los datos en la base de datos.
            // 2° Se deben Desplegar los datos en la grilla del formulario.
            // 3° Se debe limpiar el log de marcas.

            ShowStatusBar("Leyendo datos desde el reloj", Color.Khaki);
            if ( !dispositivo.DispositivoObtenerRegistrosAsistencias() )
            {
                MessageBox.Show("No existen registros nuevos en el reloj.", "Diálogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Almacenar datos en la tabla de Marcas
            //
            ShowStatusBar("Almacenando datos de marcaciones.", Color.Khaki);
            MessageBox.Show("Almacenar datos en la tabla de marcas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            clsRegistroAsistencia ra = new clsRegistroAsistencia();
            if ( ra.Save(dispositivo.ListaMarcajes) )





            ShowStatusBar("Desplegando datos.", Color.Khaki);
            // Desplegar los datos en el DataView
            //
            clsEnrolados enr = new clsEnrolados();
            foreach( UsuarioMarcaje d in dispositivo.ListaMarcajes)
            {
                string Nombres = string.Empty;

                if ( enr.Get(d.NumeroCredencial).Count == 1 )
                    Nombres = enr.Nombre;

                dgMarcas.Rows.Add( 
                    d.NumeroCredencial, 
                    Nombres,
                    d.TipoMarcasDescripcion, 
                    d.Dia.ToString().PadLeft(2, '0') + "/" + d.Mes.ToString().PadLeft(2, '0') + "/" + d.Anio,
                    d.Hora.ToString().PadLeft(2, '0') + ":" + d.Minuto.ToString().PadLeft(2, '0'),
                    d.MetodoMarcaDescripcion
                );
            }

            // Limpiar los log del reloj control
            //
            ShowStatusBar("Limpiando registros del dispositivo.", Color.Khaki);
            MessageBox.Show("Quitar comentarios para eliminar los registros del reloj.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //if ( !dispositivo.DispositivoBorrarRegistrosAsistencias() )
            //{
            //    MessageBox.Show("No se pudieron eliminar los registros del reloj.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            Cursor.Current = Cursors.Default;

            ShowStatusBar("OK!", Color.DodgerBlue);
            MessageBox.Show("El proceso termino correctamente!\nSe recuperaron " + dispositivo.ListaMarcajes.Count + " registros desde el reloj.", "Diálogo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        public void ShowStatusBar(string message, Color color = default(Color) )
        {
            if (message.Trim() == string.Empty)
            {
                lblStatus.Visible = false;
                return;
            }

            lblStatus.Visible = true;
            lblStatus.Text = message;
            lblStatus.ForeColor = Color.Black;

            if (color != null)
                lblStatus.BackColor = color;

            //if (type)
            //    lblStatus.BackColor = Color.FromArgb(79, 208, 154);
            //else
            //    lblStatus.BackColor = Color.FromArgb(230, 112, 134);
        }


        public void CambiaEstadoDispositivo(System.Drawing.Image img)
        {
            StatusStrip control = (StatusStrip)this.MdiParent.Controls["statusStrip1"];
            control.Items["tssEstado"].Image = img;
        }

        private void frmRelojControl_Load(object sender, EventArgs e)
        {
            ShowStatusBar(string.Empty);
        }

    }
}
