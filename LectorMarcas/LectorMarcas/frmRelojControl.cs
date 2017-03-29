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
