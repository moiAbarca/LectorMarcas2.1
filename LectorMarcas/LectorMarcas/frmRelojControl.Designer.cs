namespace LectorMarcas
{
    partial class frmRelojControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelojControl));
            this.tabAdmReg = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsDescarga = new System.Windows.Forms.ToolStripButton();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dgMarcas = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoramarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMetodoMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dpHasta = new System.Windows.Forms.DateTimePicker();
            this.dpDesde = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblStatusAdmReg = new System.Windows.Forms.Label();
            this.cmbPersonal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgRegAsistencia = new System.Windows.Forms.DataGridView();
            this.colEnroll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g2colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g2colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g2colTipoAcceso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g2colMetodoRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabAdmReg.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMarcas)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRegAsistencia)).BeginInit();
            this.SuspendLayout();
            // 
            // tabAdmReg
            // 
            this.tabAdmReg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabAdmReg.Controls.Add(this.tabPage1);
            this.tabAdmReg.Controls.Add(this.tabPage2);
            this.tabAdmReg.Location = new System.Drawing.Point(12, 14);
            this.tabAdmReg.Name = "tabAdmReg";
            this.tabAdmReg.SelectedIndex = 0;
            this.tabAdmReg.Size = new System.Drawing.Size(824, 555);
            this.tabAdmReg.TabIndex = 1;
            this.tabAdmReg.Click += new System.EventHandler(this.tabAdmReg_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Controls.Add(this.lblStatus);
            this.tabPage1.Controls.Add(this.dgMarcas);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(816, 529);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Marcaciones";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDescarga});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(810, 25);
            this.toolStrip1.TabIndex = 54;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsDescarga
            // 
            this.tsDescarga.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDescarga.Image = global::LectorMarcas.Properties.Resources.download_256;
            this.tsDescarga.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDescarga.Name = "tsDescarga";
            this.tsDescarga.Size = new System.Drawing.Size(23, 22);
            this.tsDescarga.Text = "Descarga datos";
            this.tsDescarga.Click += new System.EventHandler(this.tsDescarga_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(0, 486);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(787, 19);
            this.lblStatus.TabIndex = 53;
            this.lblStatus.Text = "lblStatus";
            // 
            // dgMarcas
            // 
            this.dgMarcas.AllowUserToAddRows = false;
            this.dgMarcas.AllowUserToDeleteRows = false;
            this.dgMarcas.AllowUserToResizeRows = false;
            this.dgMarcas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMarcas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colNombre,
            this.colTipoMarca,
            this.colFecha,
            this.colHoramarca,
            this.colMetodoMarca});
            this.dgMarcas.Location = new System.Drawing.Point(3, 36);
            this.dgMarcas.Name = "dgMarcas";
            this.dgMarcas.RowHeadersVisible = false;
            this.dgMarcas.Size = new System.Drawing.Size(784, 447);
            this.dgMarcas.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 70;
            // 
            // colNombre
            // 
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.Width = 250;
            // 
            // colTipoMarca
            // 
            this.colTipoMarca.HeaderText = "Entrada/Salida";
            this.colTipoMarca.Name = "colTipoMarca";
            this.colTipoMarca.ReadOnly = true;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colHoramarca
            // 
            this.colHoramarca.HeaderText = "Hora";
            this.colHoramarca.Name = "colHoramarca";
            this.colHoramarca.ReadOnly = true;
            // 
            // colMetodoMarca
            // 
            this.colMetodoMarca.HeaderText = "Metodo";
            this.colMetodoMarca.Name = "colMetodoMarca";
            this.colMetodoMarca.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.toolStrip2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.dpHasta);
            this.tabPage2.Controls.Add(this.dpDesde);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.cmbPersonal);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(816, 529);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Administrador de Registros";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(810, 25);
            this.toolStrip2.TabIndex = 55;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::LectorMarcas.Properties.Resources.office_stuff_printer_icon;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Generar reporte";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Hasta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Desde";
            // 
            // dpHasta
            // 
            this.dpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpHasta.Location = new System.Drawing.Point(123, 44);
            this.dpHasta.Name = "dpHasta";
            this.dpHasta.Size = new System.Drawing.Size(105, 20);
            this.dpHasta.TabIndex = 8;
            // 
            // dpDesde
            // 
            this.dpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDesde.Location = new System.Drawing.Point(12, 44);
            this.dpDesde.Name = "dpDesde";
            this.dpDesde.Size = new System.Drawing.Size(105, 20);
            this.dpDesde.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lblStatusAdmReg);
            this.panel2.Location = new System.Drawing.Point(6, 498);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(801, 25);
            this.panel2.TabIndex = 6;
            // 
            // lblStatusAdmReg
            // 
            this.lblStatusAdmReg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusAdmReg.Location = new System.Drawing.Point(3, 4);
            this.lblStatusAdmReg.Name = "lblStatusAdmReg";
            this.lblStatusAdmReg.Size = new System.Drawing.Size(795, 18);
            this.lblStatusAdmReg.TabIndex = 54;
            this.lblStatusAdmReg.Text = "lblStatusAdmReg";
            // 
            // cmbPersonal
            // 
            this.cmbPersonal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonal.FormattingEnabled = true;
            this.cmbPersonal.Location = new System.Drawing.Point(234, 44);
            this.cmbPersonal.Name = "cmbPersonal";
            this.cmbPersonal.Size = new System.Drawing.Size(380, 21);
            this.cmbPersonal.TabIndex = 5;
            this.cmbPersonal.SelectedIndexChanged += new System.EventHandler(this.cmbPernonal_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Personal";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgRegAsistencia);
            this.panel1.Location = new System.Drawing.Point(6, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 427);
            this.panel1.TabIndex = 3;
            // 
            // dgRegAsistencia
            // 
            this.dgRegAsistencia.AllowUserToAddRows = false;
            this.dgRegAsistencia.AllowUserToDeleteRows = false;
            this.dgRegAsistencia.AllowUserToResizeRows = false;
            this.dgRegAsistencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRegAsistencia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEnroll,
            this.g2colNombre,
            this.g2colFecha,
            this.g2colTipoAcceso,
            this.g2colMetodoRegistro});
            this.dgRegAsistencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRegAsistencia.Location = new System.Drawing.Point(0, 0);
            this.dgRegAsistencia.Name = "dgRegAsistencia";
            this.dgRegAsistencia.ReadOnly = true;
            this.dgRegAsistencia.RowHeadersVisible = false;
            this.dgRegAsistencia.Size = new System.Drawing.Size(801, 427);
            this.dgRegAsistencia.TabIndex = 2;
            // 
            // colEnroll
            // 
            this.colEnroll.HeaderText = "Id";
            this.colEnroll.Name = "colEnroll";
            this.colEnroll.ReadOnly = true;
            // 
            // g2colNombre
            // 
            this.g2colNombre.HeaderText = "Nombre";
            this.g2colNombre.Name = "g2colNombre";
            this.g2colNombre.ReadOnly = true;
            this.g2colNombre.Width = 275;
            // 
            // g2colFecha
            // 
            this.g2colFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.g2colFecha.HeaderText = "Marca";
            this.g2colFecha.Name = "g2colFecha";
            this.g2colFecha.ReadOnly = true;
            this.g2colFecha.Width = 62;
            // 
            // g2colTipoAcceso
            // 
            this.g2colTipoAcceso.HeaderText = "Tipo Marca";
            this.g2colTipoAcceso.Name = "g2colTipoAcceso";
            this.g2colTipoAcceso.ReadOnly = true;
            // 
            // g2colMetodoRegistro
            // 
            this.g2colMetodoRegistro.HeaderText = "Metodo registro";
            this.g2colMetodoRegistro.Name = "g2colMetodoRegistro";
            this.g2colMetodoRegistro.ReadOnly = true;
            this.g2colMetodoRegistro.Width = 150;
            // 
            // frmRelojControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 581);
            this.Controls.Add(this.tabAdmReg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRelojControl";
            this.Text = "Reloj Control";
            this.Load += new System.EventHandler(this.frmRelojControl_Load);
            this.tabAdmReg.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMarcas)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRegAsistencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabAdmReg;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsDescarga;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dgMarcas;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoramarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMetodoMarca;
        private System.Windows.Forms.DataGridView dgRegAsistencia;
        private System.Windows.Forms.ComboBox cmbPersonal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblStatusAdmReg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dpHasta;
        private System.Windows.Forms.DateTimePicker dpDesde;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEnroll;
        private System.Windows.Forms.DataGridViewTextBoxColumn g2colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn g2colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn g2colTipoAcceso;
        private System.Windows.Forms.DataGridViewTextBoxColumn g2colMetodoRegistro;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}