namespace LectorMarcas
{
    partial class frmDispositivos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.Port1 = new System.Windows.Forms.NumericUpDown();
            this.Port2 = new System.Windows.Forms.NumericUpDown();
            this.Port4 = new System.Windows.Forms.NumericUpDown();
            this.Port3 = new System.Windows.Forms.NumericUpDown();
            this.Port6 = new System.Windows.Forms.NumericUpDown();
            this.Port5 = new System.Windows.Forms.NumericUpDown();
            this.txtIp1 = new System.Windows.Forms.TextBox();
            this.txtIp2 = new System.Windows.Forms.TextBox();
            this.txtIp3 = new System.Windows.Forms.TextBox();
            this.txtIp6 = new System.Windows.Forms.TextBox();
            this.txtIp5 = new System.Windows.Forms.TextBox();
            this.txtIp4 = new System.Windows.Forms.TextBox();
            this.btnTest1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Port1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Port2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Port4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Port3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Port6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Port5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Dispositivo 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Dispositivo 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Dispositivo 4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Dispositivo 3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Dispositivo 6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Dispositivo 5";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(135, 175);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 38;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(216, 175);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 39;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // Port1
            // 
            this.Port1.Location = new System.Drawing.Point(191, 11);
            this.Port1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Port1.Name = "Port1";
            this.Port1.Size = new System.Drawing.Size(49, 20);
            this.Port1.TabIndex = 27;
            this.Port1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Port2
            // 
            this.Port2.Location = new System.Drawing.Point(191, 38);
            this.Port2.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Port2.Name = "Port2";
            this.Port2.Size = new System.Drawing.Size(49, 20);
            this.Port2.TabIndex = 29;
            this.Port2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Port4
            // 
            this.Port4.Location = new System.Drawing.Point(191, 90);
            this.Port4.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Port4.Name = "Port4";
            this.Port4.Size = new System.Drawing.Size(49, 20);
            this.Port4.TabIndex = 33;
            this.Port4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Port3
            // 
            this.Port3.Location = new System.Drawing.Point(191, 64);
            this.Port3.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Port3.Name = "Port3";
            this.Port3.Size = new System.Drawing.Size(49, 20);
            this.Port3.TabIndex = 31;
            this.Port3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Port6
            // 
            this.Port6.Location = new System.Drawing.Point(191, 143);
            this.Port6.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Port6.Name = "Port6";
            this.Port6.Size = new System.Drawing.Size(49, 20);
            this.Port6.TabIndex = 37;
            this.Port6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Port5
            // 
            this.Port5.Location = new System.Drawing.Point(191, 117);
            this.Port5.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Port5.Name = "Port5";
            this.Port5.Size = new System.Drawing.Size(49, 20);
            this.Port5.TabIndex = 35;
            this.Port5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIp1
            // 
            this.txtIp1.Location = new System.Drawing.Point(83, 11);
            this.txtIp1.Name = "txtIp1";
            this.txtIp1.Size = new System.Drawing.Size(102, 20);
            this.txtIp1.TabIndex = 26;
            this.txtIp1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIp_KeyPress);
            // 
            // txtIp2
            // 
            this.txtIp2.Location = new System.Drawing.Point(83, 38);
            this.txtIp2.Name = "txtIp2";
            this.txtIp2.Size = new System.Drawing.Size(102, 20);
            this.txtIp2.TabIndex = 29;
            this.txtIp2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIp_KeyPress);
            // 
            // txtIp3
            // 
            this.txtIp3.Location = new System.Drawing.Point(83, 64);
            this.txtIp3.Name = "txtIp3";
            this.txtIp3.Size = new System.Drawing.Size(102, 20);
            this.txtIp3.TabIndex = 30;
            this.txtIp3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIp_KeyPress);
            // 
            // txtIp6
            // 
            this.txtIp6.Location = new System.Drawing.Point(83, 143);
            this.txtIp6.Name = "txtIp6";
            this.txtIp6.Size = new System.Drawing.Size(102, 20);
            this.txtIp6.TabIndex = 36;
            this.txtIp6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIp_KeyPress);
            // 
            // txtIp5
            // 
            this.txtIp5.Location = new System.Drawing.Point(83, 117);
            this.txtIp5.Name = "txtIp5";
            this.txtIp5.Size = new System.Drawing.Size(102, 20);
            this.txtIp5.TabIndex = 34;
            this.txtIp5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIp_KeyPress);
            // 
            // txtIp4
            // 
            this.txtIp4.Location = new System.Drawing.Point(83, 90);
            this.txtIp4.Name = "txtIp4";
            this.txtIp4.Size = new System.Drawing.Size(102, 20);
            this.txtIp4.TabIndex = 32;
            this.txtIp4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIp_KeyPress);
            // 
            // btnTest1
            // 
            this.btnTest1.Location = new System.Drawing.Point(246, 11);
            this.btnTest1.Name = "btnTest1";
            this.btnTest1.Size = new System.Drawing.Size(45, 20);
            this.btnTest1.TabIndex = 40;
            this.btnTest1.Text = "Test";
            this.btnTest1.UseVisualStyleBackColor = true;
            this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(246, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 20);
            this.button2.TabIndex = 47;
            this.button2.Text = "Test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(246, 63);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 20);
            this.button3.TabIndex = 48;
            this.button3.Text = "Test";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(246, 89);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(45, 20);
            this.button4.TabIndex = 49;
            this.button4.Text = "Test";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(246, 116);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(45, 20);
            this.button5.TabIndex = 50;
            this.button5.Text = "Test";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(246, 142);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(45, 20);
            this.button6.TabIndex = 51;
            this.button6.Text = "Test";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(2, 214);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(318, 19);
            this.lblStatus.TabIndex = 52;
            this.lblStatus.Text = "lblStatus";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // frmDispositivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 235);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnTest1);
            this.Controls.Add(this.txtIp6);
            this.Controls.Add(this.txtIp5);
            this.Controls.Add(this.txtIp4);
            this.Controls.Add(this.txtIp3);
            this.Controls.Add(this.txtIp2);
            this.Controls.Add(this.txtIp1);
            this.Controls.Add(this.Port6);
            this.Controls.Add(this.Port5);
            this.Controls.Add(this.Port4);
            this.Controls.Add(this.Port3);
            this.Controls.Add(this.Port2);
            this.Controls.Add(this.Port1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDispositivos";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Dispositivos";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmDispositivos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Port1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Port2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Port4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Port3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Port6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Port5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.NumericUpDown Port1;
        private System.Windows.Forms.NumericUpDown Port2;
        private System.Windows.Forms.NumericUpDown Port4;
        private System.Windows.Forms.NumericUpDown Port3;
        private System.Windows.Forms.NumericUpDown Port6;
        private System.Windows.Forms.NumericUpDown Port5;
        private System.Windows.Forms.TextBox txtIp1;
        private System.Windows.Forms.TextBox txtIp2;
        private System.Windows.Forms.TextBox txtIp3;
        private System.Windows.Forms.TextBox txtIp6;
        private System.Windows.Forms.TextBox txtIp5;
        private System.Windows.Forms.TextBox txtIp4;
        private System.Windows.Forms.Button btnTest1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label lblStatus;
    }
}