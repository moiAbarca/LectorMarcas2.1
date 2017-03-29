using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LectorMarcas.PRGClass;
using SGFBussinesLayer;

namespace LectorMarcas
{
    public partial class frmPersonal : Form
    {
        public frmPersonal()
        {
            InitializeComponent();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }



        /*Ya no existe el formulario help
         * private void btnHelp_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "frmHelp").SingleOrDefault<Form>();
            if (existe != null)
            {
                return;
            }

            frmHelp frm = new frmHelp();
            // frm.MdiParent = this;
            frm.ShowDialog();
            Cursor.Current = Cursors.Default;
        }
        */

        private void nuevoToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                pbFoto.Image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Diálogo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void abrirToolStripButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    pbFoto.Image = new Bitmap(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Diálogo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtRut_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo numeros
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtDv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Validar rut
                if (txtRut.Text.Length <= 0 && txtDv.Text.Length <= 0)
                {
                    MessageBox.Show("Debe ingresar datos validos", "Diálogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                TraerDatos();
            }
        }

        private void TraerDatos()
        {

            if (!(txtRut.Text.Length > 0 && txtDv.Text.Length > 0))
                return;

            // Validar Rut 
            int Rut = Convert.ToInt32(txtRut.Text);
            if (!GlobalVars.ValidaRut(Rut, Convert.ToChar(txtDv.Text.ToString())))
            {
                MessageBox.Show("El rut ingresado es invalido!!", "Diálogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDv.Focus();
                return;
            }

            clsEnrolados per = new clsEnrolados();

            List<DBClass.Enrolados> lst = per.Get(Rut, txtDv.Text.ToString());

            if (lst.Count == 1)
                MostrarDatos(per);
            else
                HabilitarIngreso();

            // Si el rut es correcto
            // Buscar datos y habilitar el ingreso de campos
            /*
            if (!per.ExistePersona(IdEn))
                HabilitarIngreso();
            else
                MostrarDatos();
            */
        }

        private void MostrarDatos(clsEnrolados per)
        {

            txtNombre.Text = per.Nombre;
            txtIdEnrolamiento.Text = Convert.ToString(per.IdEnroll);
            txtNombre.Text = per.Nombre;
            txtNacionalidad.Text = per.Nacionalidad;
            dateTimeNacimiento.Value = per.FechaNacimiento;
            txtTelefono.Text = per.Telefonos;
            dateTimeAltaLaboral.Value = per.AltaLaboral;
            txtDireccion.Text = per.Direccion;

            if (per.Genero == "F")
            {
                radioButtonFemenino.Checked = true;
            }
            else
                radioButtonMasculino.Checked = true;
        }

        private void HabilitarIngreso()
        {
            habilitarFormulario(true);
        }

        private void txtDv_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo numeros, Back y la letra K
            e.Handled = !(char.IsNumber(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.K) || (e.KeyChar == (char)107));
            return;
        }

        private void txtDv_Leave(object sender, EventArgs e)
        {
            if (txtDv.Enabled && txtDv.Text.Length > 0)
            {
                TraerDatos();
                guardarToolStripButton.Enabled = true;
                habilitarFormulario(true);
            }
        }



        private void guardarToolStripButton_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            clsEnrolados enr = new clsEnrolados();

            enr.IdEnroll = Convert.ToInt32(txtIdEnrolamiento.Text);
            enr.Rut = Convert.ToInt32(txtRut.Text);
            enr.Dv = txtDv.Text;
            enr.Nombre = txtNombre.Text;
            enr.Nacionalidad = txtNacionalidad.Text;
            enr.FechaNacimiento = dateTimeNacimiento.Value.Date;
            enr.Telefonos = txtTelefono.Text;
            enr.AltaLaboral = dateTimeAltaLaboral.Value.Date;
            enr.Direccion = txtDireccion.Text;

            string value = "";
            bool isChecked = radioButtonFemenino.Checked;
            if (isChecked)
                enr.Genero = "F";
            else
                enr.Genero = "M";

            //Averiguar como capturar los datos del PictureBox
            //enr.Foto = pbFoto.Image;
            enr.Foto = null;
            try
            {
                if (!enr.Save())
                {
                    MessageBox.Show("Error al grabar datos", "Diálogo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Datos almacenados correctamente.", "Diálogo", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (ReglasNegocioException ex)
            {
                MessageBox.Show(ex.Message, "Diálogo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        public void habilitarFormulario(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtNacionalidad.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;
            dateTimeAltaLaboral.Enabled = habilitar;
            dateTimeNacimiento.Enabled = habilitar;
            txtIdEnrolamiento.Enabled = habilitar;
            txtDireccion.Enabled = habilitar;
            groupBox1.Enabled = habilitar;
            groupBox2.Enabled = habilitar;
        }

        private void nuevoToolStripButton_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
            txtRut.Focus();
            guardarToolStripButton.Enabled = false;
            habilitarFormulario(false);
        }

        public void limpiarFormulario()
        {
            txtRut.Clear();
            txtDv.Clear();
            txtNombre.Clear();
            txtNacionalidad.Clear();
            txtTelefono.Clear();
            dateTimeAltaLaboral.ResetText();
            dateTimeNacimiento.ResetText();
            txtIdEnrolamiento.Clear(); ;
            txtDireccion.Clear(); ;
            radioButtonFemenino.Checked = false;
            radioButtonMasculino.Checked = false;
            pbFoto.Image = null;
        }

        private void frmPersonal_Load(object sender, EventArgs e)
        {
            guardarToolStripButton.Enabled = false;
            habilitarFormulario(false);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permite solamente letras
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }

        }

        private void txtNacionalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permite solamente letras
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtIdEnrolamiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo números
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo números
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }

        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            // Permite  números y letras
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back)) && (!(char.IsWhiteSpace(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))) 
            {
                e.Handled = true;
                return;
            }
             
    
        }
    }
}
