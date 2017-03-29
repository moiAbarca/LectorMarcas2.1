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
using LectorMarcas.Utilities;

namespace LectorMarcas
{
    public partial class frmDispositivos : Form
    {
        int nY = 11;

        ZKSauro dispositivo = new ZKSauro(Modelo.X628C);

        PictureBox pb = new PictureBox();

        public frmDispositivos()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Configuration cfg = ConfigurationManager.OpenExeConfiguration( ConfigurationUserLevel.None );
            AppSettingsSection aps = cfg.AppSettings;

            string sD1 = txtIp1.Text.ToString() + ":" + Port1.Value.ToString();
            aps.Settings["RC1"].Value = sD1;
            
            string sD2 = txtIp2.Text.ToString() + ":" + Port2.Value.ToString();
            aps.Settings["RC2"].Value = sD2;
            
            string sD3 = txtIp3.Text.ToString() + ":" + Port3.Value.ToString();
            aps.Settings["RC3"].Value = sD3;
            
            string sD4 = txtIp4.Text.ToString() + ":" + Port4.Value.ToString();
            aps.Settings["RC4"].Value = sD4;
            
            string sD5 = txtIp5.Text.ToString() + ":" + Port5.Value.ToString();
            aps.Settings["RC5"].Value = sD5;
            
            string sD6 = txtIp6.Text.ToString() + ":" + Port6.Value.ToString();
            aps.Settings["RC6"].Value = sD6;

            cfg.Save(ConfigurationSaveMode.Modified);
            
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDispositivos_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "";


            int nIncremento = 27;

            //pb.Image    = Properties.Resources.Ok;
            //pb.SizeMode = PictureBoxSizeMode.StretchImage;
            //pb.Size     = new System.Drawing.Size(18, 18);
            //pb.Location = new Point(291, 11);

            //this.Controls.Add( pb );
            SetearTextos();

        }

        private void DisplayStatus(int x, bool isValidIp)
        {
            pb.Image = isValidIp ? Properties.Resources.Ok : Properties.Resources.Nok;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Size = new System.Drawing.Size(18, 18);
            pb.Location = new Point(291, x);

            this.Controls.Add(pb);
        }

        private void SetearTextos()
        {
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection aps = cfg.AppSettings;

            string[] aArray;

            aArray = aps.Settings["RC1"].Value.ToString().Split(':');

            txtIp1.Text = aArray[0];
            Port1.Value = Convert.ToInt32( aArray[1] );

            aArray = aps.Settings["RC2"].Value.ToString().Split(':');

            txtIp2.Text = aArray[0];
            Port2.Value = Convert.ToInt32(aArray[1]);

            aArray = aps.Settings["RC3"].Value.ToString().Split(':');

            txtIp3.Text = aArray[0];
            Port3.Value = Convert.ToInt32(aArray[1]);

            aArray = aps.Settings["RC4"].Value.ToString().Split(':');

            txtIp4.Text = aArray[0];
            Port4.Value = Convert.ToInt32(aArray[1]);

            aArray = aps.Settings["RC5"].Value.ToString().Split(':');

            txtIp5.Text = aArray[0];
            Port5.Value = Convert.ToInt32(aArray[1]);

            aArray = aps.Settings["RC6"].Value.ToString().Split(':');

            txtIp6.Text = aArray[0];
            Port6.Value = Convert.ToInt32(aArray[1]);

        }

        private void txtIp_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo numeros
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back && e.KeyChar != '.'))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnTest1_Click(object sender, EventArgs e)
        {
            ShowStatusBar(string.Empty, true);

            string ipAddress = txtIp1.Text.Trim();

            bool isValidIpA = UniversalStatic.ValidateIP(ipAddress);
            if (!isValidIpA)
                ShowStatusBar("La IP del dispositivo no es valida !!", false);

            isValidIpA = UniversalStatic.PingTheDevice(ipAddress);
            if (isValidIpA)
                ShowStatusBar("El dispositivo esta activo", true);
            else
                ShowStatusBar("No se obtuvo alguna respuesta", false);

            DisplayStatus(11, isValidIpA);
        }

        public void ShowStatusBar(string message, bool type)
        {
            if (message.Trim() == string.Empty)
            {
                lblStatus.Visible = false;
                return;
            }

            lblStatus.Visible = true;
            lblStatus.Text = message;
            lblStatus.ForeColor = Color.White;

            if (type)
                lblStatus.BackColor = Color.FromArgb(79, 208, 154);
            else
                lblStatus.BackColor = Color.FromArgb(230, 112, 134);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowStatusBar(string.Empty, true);

            string ipAddress = txtIp2.Text.Trim();

            bool isValidIpA = UniversalStatic.ValidateIP(ipAddress);
            if (!isValidIpA)
                ShowStatusBar("La IP del dispositivo no es valida !!", false);

            isValidIpA = UniversalStatic.PingTheDevice(ipAddress);
            if (isValidIpA)
                ShowStatusBar("El dispositivo esta activo", true);
            else
                ShowStatusBar("No se obtuvo alguna respuesta", false);

            DisplayStatus(37, isValidIpA);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowStatusBar(string.Empty, true);

            string ipAddress = txtIp3.Text.Trim();

            bool isValidIpA = UniversalStatic.ValidateIP(ipAddress);
            if (!isValidIpA)
                ShowStatusBar("La IP del dispositivo no es valida !!", false);

            isValidIpA = UniversalStatic.PingTheDevice(ipAddress);
            if (isValidIpA)
                ShowStatusBar("El dispositivo esta activo", true);
            else
                ShowStatusBar("No se obtuvo alguna respuesta", false);

            DisplayStatus(63, isValidIpA);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowStatusBar(string.Empty, true);

            string ipAddress = txtIp4.Text.Trim();

            bool isValidIpA = UniversalStatic.ValidateIP(ipAddress);
            if (!isValidIpA)
                ShowStatusBar("La IP del dispositivo no es valida !!",false);

            isValidIpA = UniversalStatic.PingTheDevice(ipAddress);
            if (isValidIpA)
                ShowStatusBar("El dispositivo esta activo", true);
            else
                ShowStatusBar("No se obtuvo alguna respuesta", false);

            DisplayStatus(89, isValidIpA);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowStatusBar(string.Empty, true);

            string ipAddress = txtIp5.Text.Trim();

            bool isValidIpA = UniversalStatic.ValidateIP(ipAddress);
            if (!isValidIpA)
                ShowStatusBar("La IP del dispositivo no es valida !!",false);

            isValidIpA = UniversalStatic.PingTheDevice(ipAddress);
            if (isValidIpA)
                ShowStatusBar("El dispositivo esta activo", true);
            else
                ShowStatusBar("No se obtuvo alguna respuesta", false);

            DisplayStatus(116, isValidIpA);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowStatusBar(string.Empty, true);

            string ipAddress = txtIp6.Text.Trim();

            bool isValidIpA = UniversalStatic.ValidateIP(ipAddress);
            if (!isValidIpA)
                ShowStatusBar("La IP del dispositivo no es valida !!", false);

            isValidIpA = UniversalStatic.PingTheDevice(ipAddress);
            if (isValidIpA)
                ShowStatusBar("El dispositivo esta activo", true);
            else
                ShowStatusBar("No se obtuvo alguna respuesta", false);

            DisplayStatus(142, isValidIpA);
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
