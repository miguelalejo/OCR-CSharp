namespace OCR.Facultad.Ingenieria.Aplicacion
{
    partial class FormRuta
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
            this.components = new System.ComponentModel.Container();
            this.buttonExaminar = new System.Windows.Forms.Button();
            this.textBoxRuta = new System.Windows.Forms.TextBox();
            this.checkBoxActiva = new System.Windows.Forms.CheckBox();
            this.comboBoxTipo_Documental = new System.Windows.Forms.ComboBox();
            this.bindingSourceTipo_Documental = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxPrincipal = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxRutaDescripcion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewRegistros = new System.Windows.Forms.DataGridView();
            this.bindingSourceRuta = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxDataGrid = new System.Windows.Forms.GroupBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonTransmitir = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonModificar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLimpiar = new System.Windows.Forms.ToolStripButton();
            this.labelSecuencial = new System.Windows.Forms.Label();
            this.textBoxSecuencial = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ruidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rupathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ruactivaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ruprincipalDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tipextensionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rutipodocumentalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rudescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTipo_Documental)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRuta)).BeginInit();
            this.groupBoxDataGrid.SuspendLayout();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonExaminar
            // 
            this.buttonExaminar.Location = new System.Drawing.Point(456, 62);
            this.buttonExaminar.Name = "buttonExaminar";
            this.buttonExaminar.Size = new System.Drawing.Size(75, 23);
            this.buttonExaminar.TabIndex = 6;
            this.buttonExaminar.Text = "Examinar";
            this.buttonExaminar.UseVisualStyleBackColor = true;
            this.buttonExaminar.Click += new System.EventHandler(this.buttonExaminar_Click);
            // 
            // textBoxRuta
            // 
            this.textBoxRuta.Location = new System.Drawing.Point(23, 65);
            this.textBoxRuta.Name = "textBoxRuta";
            this.textBoxRuta.Size = new System.Drawing.Size(424, 20);
            this.textBoxRuta.TabIndex = 5;
            // 
            // checkBoxActiva
            // 
            this.checkBoxActiva.AutoSize = true;
            this.checkBoxActiva.Location = new System.Drawing.Point(110, 19);
            this.checkBoxActiva.Name = "checkBoxActiva";
            this.checkBoxActiva.Size = new System.Drawing.Size(56, 17);
            this.checkBoxActiva.TabIndex = 23;
            this.checkBoxActiva.Text = "Activa";
            this.checkBoxActiva.UseVisualStyleBackColor = true;
            // 
            // comboBoxTipo_Documental
            // 
            this.comboBoxTipo_Documental.DataSource = this.bindingSourceTipo_Documental;
            this.comboBoxTipo_Documental.DisplayMember = "tip_extension";
            this.comboBoxTipo_Documental.FormattingEnabled = true;
            this.comboBoxTipo_Documental.Location = new System.Drawing.Point(9, 16);
            this.comboBoxTipo_Documental.Name = "comboBoxTipo_Documental";
            this.comboBoxTipo_Documental.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipo_Documental.TabIndex = 24;
            this.comboBoxTipo_Documental.ValueMember = "tip_nume_tip";
            // 
            // bindingSourceTipo_Documental
            // 
            this.bindingSourceTipo_Documental.DataSource = typeof(OCR.Facultad.Ingenieria.ManagerBases.DataSetTipo_Documental.tipo_documentalDataTable);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxTipo_Documental);
            this.groupBox1.Location = new System.Drawing.Point(23, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 43);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo Doumental";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxPrincipal);
            this.groupBox2.Controls.Add(this.checkBoxActiva);
            this.groupBox2.Location = new System.Drawing.Point(168, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(172, 43);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parametros";
            // 
            // checkBoxPrincipal
            // 
            this.checkBoxPrincipal.AutoSize = true;
            this.checkBoxPrincipal.Location = new System.Drawing.Point(6, 19);
            this.checkBoxPrincipal.Name = "checkBoxPrincipal";
            this.checkBoxPrincipal.Size = new System.Drawing.Size(66, 17);
            this.checkBoxPrincipal.TabIndex = 24;
            this.checkBoxPrincipal.Text = "Principal";
            this.checkBoxPrincipal.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxRutaDescripcion);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.buttonExaminar);
            this.groupBox3.Controls.Add(this.textBoxRuta);
            this.groupBox3.Location = new System.Drawing.Point(12, 44);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(546, 160);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ruta";
            // 
            // textBoxRutaDescripcion
            // 
            this.textBoxRutaDescripcion.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bindingSourceTipo_Documental, "tip_nume_tip", true));
            this.textBoxRutaDescripcion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceTipo_Documental, "tip_descripcion", true));
            this.textBoxRutaDescripcion.Location = new System.Drawing.Point(23, 105);
            this.textBoxRutaDescripcion.Multiline = true;
            this.textBoxRutaDescripcion.Name = "textBoxRutaDescripcion";
            this.textBoxRutaDescripcion.Size = new System.Drawing.Size(508, 49);
            this.textBoxRutaDescripcion.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Descripción:";
            // 
            // dataGridViewRegistros
            // 
            this.dataGridViewRegistros.AllowUserToAddRows = false;
            this.dataGridViewRegistros.AllowUserToDeleteRows = false;
            this.dataGridViewRegistros.AutoGenerateColumns = false;
            this.dataGridViewRegistros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRegistros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ruidDataGridViewTextBoxColumn,
            this.rupathDataGridViewTextBoxColumn,
            this.ruactivaDataGridViewCheckBoxColumn,
            this.ruprincipalDataGridViewCheckBoxColumn,
            this.tipextensionDataGridViewTextBoxColumn,
            this.rutipodocumentalDataGridViewTextBoxColumn,
            this.rudescripcionDataGridViewTextBoxColumn});
            this.dataGridViewRegistros.DataSource = this.bindingSourceRuta;
            this.dataGridViewRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRegistros.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewRegistros.Name = "dataGridViewRegistros";
            this.dataGridViewRegistros.ReadOnly = true;
            this.dataGridViewRegistros.Size = new System.Drawing.Size(525, 190);
            this.dataGridViewRegistros.TabIndex = 5;
            this.dataGridViewRegistros.DoubleClick += new System.EventHandler(this.dataGridViewRegistros_DoubleClick);
            this.dataGridViewRegistros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRegistros_CellContentClick);
            // 
            // bindingSourceRuta
            // 
            this.bindingSourceRuta.AllowNew = false;
            this.bindingSourceRuta.DataSource = typeof(OCR.Facultad.Ingenieria.ManagerBases.DataSetRuta.rutaDataTable);
            // 
            // groupBoxDataGrid
            // 
            this.groupBoxDataGrid.Controls.Add(this.dataGridViewRegistros);
            this.groupBoxDataGrid.Location = new System.Drawing.Point(12, 210);
            this.groupBoxDataGrid.Name = "groupBoxDataGrid";
            this.groupBoxDataGrid.Size = new System.Drawing.Size(531, 209);
            this.groupBoxDataGrid.TabIndex = 29;
            this.groupBoxDataGrid.TabStop = false;
            this.groupBoxDataGrid.Text = "Registros";
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonTransmitir,
            this.toolStripButtonModificar,
            this.toolStripButtonEliminar,
            this.toolStripButtonBuscar,
            this.toolStripButtonLimpiar});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(570, 25);
            this.toolStripMenu.TabIndex = 30;
            this.toolStripMenu.Text = "Menu Principal";
            // 
            // toolStripButtonTransmitir
            // 
            this.toolStripButtonTransmitir.Image = global::OCR.Facultad.Ingenieria.Aplicacion.Properties.Resources.onebit_guardar;
            this.toolStripButtonTransmitir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTransmitir.Name = "toolStripButtonTransmitir";
            this.toolStripButtonTransmitir.Size = new System.Drawing.Size(81, 22);
            this.toolStripButtonTransmitir.Text = "Transmitir";
            this.toolStripButtonTransmitir.Click += new System.EventHandler(this.toolStripButtonTransmitir_Click);
            // 
            // toolStripButtonModificar
            // 
            this.toolStripButtonModificar.Enabled = false;
            this.toolStripButtonModificar.Image = global::OCR.Facultad.Ingenieria.Aplicacion.Properties.Resources.onebit_modificar;
            this.toolStripButtonModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonModificar.Name = "toolStripButtonModificar";
            this.toolStripButtonModificar.Size = new System.Drawing.Size(78, 22);
            this.toolStripButtonModificar.Text = "Modificar";
            this.toolStripButtonModificar.Click += new System.EventHandler(this.toolStripButtonModificar_Click);
            // 
            // toolStripButtonEliminar
            // 
            this.toolStripButtonEliminar.Enabled = false;
            this.toolStripButtonEliminar.Image = global::OCR.Facultad.Ingenieria.Aplicacion.Properties.Resources.onebit_eliminar;
            this.toolStripButtonEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEliminar.Name = "toolStripButtonEliminar";
            this.toolStripButtonEliminar.Size = new System.Drawing.Size(70, 22);
            this.toolStripButtonEliminar.Text = "Eliminar";
            this.toolStripButtonEliminar.Click += new System.EventHandler(this.toolStripButtonEliminar_Click);
            // 
            // toolStripButtonBuscar
            // 
            this.toolStripButtonBuscar.Image = global::OCR.Facultad.Ingenieria.Aplicacion.Properties.Resources.onebit_buscar;
            this.toolStripButtonBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBuscar.Name = "toolStripButtonBuscar";
            this.toolStripButtonBuscar.Size = new System.Drawing.Size(62, 22);
            this.toolStripButtonBuscar.Text = "Buscar";
            this.toolStripButtonBuscar.Visible = false;
            this.toolStripButtonBuscar.Click += new System.EventHandler(this.toolStripButtonBuscar_Click);
            // 
            // toolStripButtonLimpiar
            // 
            this.toolStripButtonLimpiar.Image = global::OCR.Facultad.Ingenieria.Aplicacion.Properties.Resources.onebit_home;
            this.toolStripButtonLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLimpiar.Name = "toolStripButtonLimpiar";
            this.toolStripButtonLimpiar.Size = new System.Drawing.Size(67, 22);
            this.toolStripButtonLimpiar.Text = "Limpiar";
            this.toolStripButtonLimpiar.Click += new System.EventHandler(this.toolStripButtonLimpiar_Click);
            // 
            // labelSecuencial
            // 
            this.labelSecuencial.AutoSize = true;
            this.labelSecuencial.Location = new System.Drawing.Point(410, 21);
            this.labelSecuencial.Name = "labelSecuencial";
            this.labelSecuencial.Size = new System.Drawing.Size(63, 13);
            this.labelSecuencial.TabIndex = 32;
            this.labelSecuencial.Text = "Secuencial:";
            this.labelSecuencial.Visible = false;
            // 
            // textBoxSecuencial
            // 
            this.textBoxSecuencial.Enabled = false;
            this.textBoxSecuencial.Location = new System.Drawing.Point(479, 18);
            this.textBoxSecuencial.Name = "textBoxSecuencial";
            this.textBoxSecuencial.Size = new System.Drawing.Size(79, 20);
            this.textBoxSecuencial.TabIndex = 31;
            this.textBoxSecuencial.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ruidDataGridViewTextBoxColumn
            // 
            this.ruidDataGridViewTextBoxColumn.DataPropertyName = "ru_id";
            this.ruidDataGridViewTextBoxColumn.FillWeight = 72.69455F;
            this.ruidDataGridViewTextBoxColumn.HeaderText = "ID";
            this.ruidDataGridViewTextBoxColumn.Name = "ruidDataGridViewTextBoxColumn";
            this.ruidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rupathDataGridViewTextBoxColumn
            // 
            this.rupathDataGridViewTextBoxColumn.DataPropertyName = "ru_path";
            this.rupathDataGridViewTextBoxColumn.FillWeight = 148.3562F;
            this.rupathDataGridViewTextBoxColumn.HeaderText = "Path";
            this.rupathDataGridViewTextBoxColumn.Name = "rupathDataGridViewTextBoxColumn";
            this.rupathDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ruactivaDataGridViewCheckBoxColumn
            // 
            this.ruactivaDataGridViewCheckBoxColumn.DataPropertyName = "ru_activa";
            this.ruactivaDataGridViewCheckBoxColumn.FillWeight = 72.69455F;
            this.ruactivaDataGridViewCheckBoxColumn.HeaderText = "Activa";
            this.ruactivaDataGridViewCheckBoxColumn.Name = "ruactivaDataGridViewCheckBoxColumn";
            this.ruactivaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // ruprincipalDataGridViewCheckBoxColumn
            // 
            this.ruprincipalDataGridViewCheckBoxColumn.DataPropertyName = "ru_principal";
            this.ruprincipalDataGridViewCheckBoxColumn.FillWeight = 72.69455F;
            this.ruprincipalDataGridViewCheckBoxColumn.HeaderText = "Principal";
            this.ruprincipalDataGridViewCheckBoxColumn.Name = "ruprincipalDataGridViewCheckBoxColumn";
            this.ruprincipalDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // tipextensionDataGridViewTextBoxColumn
            // 
            this.tipextensionDataGridViewTextBoxColumn.DataPropertyName = "tip_extension";
            this.tipextensionDataGridViewTextBoxColumn.FillWeight = 91.94531F;
            this.tipextensionDataGridViewTextBoxColumn.HeaderText = "Extensión";
            this.tipextensionDataGridViewTextBoxColumn.Name = "tipextensionDataGridViewTextBoxColumn";
            this.tipextensionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rutipodocumentalDataGridViewTextBoxColumn
            // 
            this.rutipodocumentalDataGridViewTextBoxColumn.DataPropertyName = "ru_tipo_documental";
            this.rutipodocumentalDataGridViewTextBoxColumn.FillWeight = 142.132F;
            this.rutipodocumentalDataGridViewTextBoxColumn.HeaderText = "Tipo Documental";
            this.rutipodocumentalDataGridViewTextBoxColumn.Name = "rutipodocumentalDataGridViewTextBoxColumn";
            this.rutipodocumentalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rudescripcionDataGridViewTextBoxColumn
            // 
            this.rudescripcionDataGridViewTextBoxColumn.DataPropertyName = "ru_descripcion";
            this.rudescripcionDataGridViewTextBoxColumn.FillWeight = 99.483F;
            this.rudescripcionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.rudescripcionDataGridViewTextBoxColumn.Name = "rudescripcionDataGridViewTextBoxColumn";
            this.rudescripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FormRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 428);
            this.Controls.Add(this.labelSecuencial);
            this.Controls.Add(this.textBoxSecuencial);
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.groupBoxDataGrid);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormRuta";
            this.Text = "Rutas Documentales";
            this.Load += new System.EventHandler(this.FormRuta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTipo_Documental)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRuta)).EndInit();
            this.groupBoxDataGrid.ResumeLayout(false);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExaminar;
        private System.Windows.Forms.TextBox textBoxRuta;
        private System.Windows.Forms.CheckBox checkBoxActiva;
        private System.Windows.Forms.ComboBox comboBoxTipo_Documental;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxPrincipal;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridViewRegistros;
        private System.Windows.Forms.GroupBox groupBoxDataGrid;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton toolStripButtonTransmitir;
        private System.Windows.Forms.ToolStripButton toolStripButtonModificar;
        private System.Windows.Forms.ToolStripButton toolStripButtonEliminar;
        private System.Windows.Forms.ToolStripButton toolStripButtonBuscar;
        private System.Windows.Forms.ToolStripButton toolStripButtonLimpiar;
        private System.Windows.Forms.BindingSource bindingSourceTipo_Documental;
        private System.Windows.Forms.BindingSource bindingSourceRuta;
        private System.Windows.Forms.Label labelSecuencial;
        private System.Windows.Forms.TextBox textBoxSecuencial;
        private System.Windows.Forms.TextBox textBoxRutaDescripcion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn ruidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rupathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ruactivaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ruprincipalDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipextensionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rutipodocumentalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rudescripcionDataGridViewTextBoxColumn;
    }
}