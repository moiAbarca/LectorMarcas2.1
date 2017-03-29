namespace LectorMarcas
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsPersonal = new System.Windows.Forms.ToolStripButton();
            this.tsRelojControl = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsConfiguracion = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsNroDispositivo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsIpDispositivo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsPersonal,
            this.tsRelojControl,
            this.toolStripSeparator1,
            this.tsConfiguracion,
            this.toolStripSeparator2,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(737, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsPersonal
            // 
            this.tsPersonal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsPersonal.Image = ((System.Drawing.Image)(resources.GetObject("tsPersonal.Image")));
            this.tsPersonal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPersonal.Name = "tsPersonal";
            this.tsPersonal.Size = new System.Drawing.Size(23, 22);
            this.tsPersonal.Text = "Personal";
            this.tsPersonal.Click += new System.EventHandler(this.tsPersonal_Click);
            // 
            // tsRelojControl
            // 
            this.tsRelojControl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsRelojControl.Image = ((System.Drawing.Image)(resources.GetObject("tsRelojControl.Image")));
            this.tsRelojControl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRelojControl.Name = "tsRelojControl";
            this.tsRelojControl.Size = new System.Drawing.Size(23, 22);
            this.tsRelojControl.Text = "Reloj control";
            this.tsRelojControl.Click += new System.EventHandler(this.tsRelojControl_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsConfiguracion
            // 
            this.tsConfiguracion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsConfiguracion.Image = ((System.Drawing.Image)(resources.GetObject("tsConfiguracion.Image")));
            this.tsConfiguracion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsConfiguracion.Name = "tsConfiguracion";
            this.tsConfiguracion.Size = new System.Drawing.Size(23, 22);
            this.tsConfiguracion.Text = "Configuración";
            this.tsConfiguracion.Click += new System.EventHandler(this.tsConfiguracion_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Ayuda";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNroDispositivo,
            this.tsIpDispositivo,
            this.toolStripStatusLabel4,
            this.tssEstado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 487);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(737, 24);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsNroDispositivo
            // 
            this.tsNroDispositivo.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsNroDispositivo.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsNroDispositivo.Name = "tsNroDispositivo";
            this.tsNroDispositivo.Size = new System.Drawing.Size(93, 19);
            this.tsNroDispositivo.Text = "Dispositivo: 001";
            this.tsNroDispositivo.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // tsIpDispositivo
            // 
            this.tsIpDispositivo.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsIpDispositivo.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsIpDispositivo.Name = "tsIpDispositivo";
            this.tsIpDispositivo.Size = new System.Drawing.Size(93, 19);
            this.tsIpDispositivo.Text = "Ip : 129.10.2.109";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(490, 19);
            this.toolStripStatusLabel4.Spring = true;
            // 
            // tssEstado
            // 
            this.tssEstado.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssEstado.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tssEstado.Name = "tssEstado";
            this.tssEstado.Size = new System.Drawing.Size(46, 19);
            this.tssEstado.Text = "Estado";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 511);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Text = "SRC ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsConfiguracion;
        private System.Windows.Forms.ToolStripButton tsPersonal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton tsRelojControl;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsNroDispositivo;
        private System.Windows.Forms.ToolStripStatusLabel tsIpDispositivo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tssEstado;
    }
}

