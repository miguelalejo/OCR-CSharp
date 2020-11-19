namespace OCR.Facultad.Ingenieria.Aplicacion
{
    partial class FormTipo_Documental
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
            this.textBoxExtension = new System.Windows.Forms.TextBox();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonTransmitir = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonModificar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLimpiar = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewRegistros = new System.Windows.Forms.DataGridView();
            this.bindingSourceTipoDocumental = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxDataGrid = new System.Windows.Forms.GroupBox();
            this.textBoxSecuencial = new System.Windows.Forms.TextBox();
            this.labelSecuencial = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.checkBoxImagen = new System.Windows.Forms.CheckBox();
            this.tipnumetipDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipextensionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipdescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipimagenDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTipoDocumental)).BeginInit();
            this.groupBoxDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxExtension
            // 
            this.textBoxExtension.Location = new System.Drawing.Point(90, 36);
            this.textBoxExtension.Name = "textBoxExtension";
            this.textBoxExtension.Size = new System.Drawing.Size(85, 20);
            this.textBoxExtension.TabIndex = 0;
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(90, 66);
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(187, 20);
            this.textBoxDescripcion.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Extensión:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción:";
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
            this.toolStripMenu.Size = new System.Drawing.Size(405, 25);
            this.toolStripMenu.TabIndex = 4;
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
            // dataGridViewRegistros
            // 
            this.dataGridViewRegistros.AllowUserToAddRows = false;
            this.dataGridViewRegistros.AllowUserToDeleteRows = false;
            this.dataGridViewRegistros.AutoGenerateColumns = false;
            this.dataGridViewRegistros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRegistros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipnumetipDataGridViewTextBoxColumn,
            this.tipextensionDataGridViewTextBoxColumn,
            this.tipdescripcionDataGridViewTextBoxColumn,
            this.tipimagenDataGridViewCheckBoxColumn});
            this.dataGridViewRegistros.DataSource = this.bindingSourceTipoDocumental;
            this.dataGridViewRegistros.Location = new System.Drawing.Point(7, 19);
            this.dataGridViewRegistros.Name = "dataGridViewRegistros";
            this.dataGridViewRegistros.ReadOnly = true;
            this.dataGridViewRegistros.Size = new System.Drawing.Size(375, 184);
            this.dataGridViewRegistros.TabIndex = 5;
            this.dataGridViewRegistros.DoubleClick += new System.EventHandler(this.dataGridViewRegistros_DoubleClick);
            // 
            // bindingSourceTipoDocumental
            // 
            this.bindingSourceTipoDocumental.AllowNew = false;
            this.bindingSourceTipoDocumental.DataSource = typeof(OCR.Facultad.Ingenieria.ManagerBases.DataSetTipo_Documental.tipo_documentalDataTable);
            // 
            // groupBoxDataGrid
            // 
            this.groupBoxDataGrid.Controls.Add(this.dataGridViewRegistros);
            this.groupBoxDataGrid.Location = new System.Drawing.Point(5, 92);
            this.groupBoxDataGrid.Name = "groupBoxDataGrid";
            this.groupBoxDataGrid.Size = new System.Drawing.Size(388, 209);
            this.groupBoxDataGrid.TabIndex = 6;
            this.groupBoxDataGrid.TabStop = false;
            this.groupBoxDataGrid.Text = "Registros";
            // 
            // textBoxSecuencial
            // 
            this.textBoxSecuencial.Enabled = false;
            this.textBoxSecuencial.Location = new System.Drawing.Point(283, 33);
            this.textBoxSecuencial.Name = "textBoxSecuencial";
            this.textBoxSecuencial.Size = new System.Drawing.Size(100, 20);
            this.textBoxSecuencial.TabIndex = 7;
            this.textBoxSecuencial.Visible = false;
            // 
            // labelSecuencial
            // 
            this.labelSecuencial.AutoSize = true;
            this.labelSecuencial.Location = new System.Drawing.Point(214, 39);
            this.labelSecuencial.Name = "labelSecuencial";
            this.labelSecuencial.Size = new System.Drawing.Size(63, 13);
            this.labelSecuencial.TabIndex = 8;
            this.labelSecuencial.Text = "Secuencial:";
            this.labelSecuencial.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // checkBoxImagen
            // 
            this.checkBoxImagen.AutoSize = true;
            this.checkBoxImagen.Location = new System.Drawing.Point(295, 68);
            this.checkBoxImagen.Name = "checkBoxImagen";
            this.checkBoxImagen.Size = new System.Drawing.Size(85, 17);
            this.checkBoxImagen.TabIndex = 9;
            this.checkBoxImagen.Text = "Tipo Imágen";
            this.checkBoxImagen.UseVisualStyleBackColor = true;
            // 
            // tipnumetipDataGridViewTextBoxColumn
            // 
            this.tipnumetipDataGridViewTextBoxColumn.DataPropertyName = "tip_nume_tip";
            this.tipnumetipDataGridViewTextBoxColumn.HeaderText = "Nro";
            this.tipnumetipDataGridViewTextBoxColumn.Name = "tipnumetipDataGridViewTextBoxColumn";
            this.tipnumetipDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipextensionDataGridViewTextBoxColumn
            // 
            this.tipextensionDataGridViewTextBoxColumn.DataPropertyName = "tip_extension";
            this.tipextensionDataGridViewTextBoxColumn.HeaderText = "Extensión";
            this.tipextensionDataGridViewTextBoxColumn.Name = "tipextensionDataGridViewTextBoxColumn";
            this.tipextensionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipdescripcionDataGridViewTextBoxColumn
            // 
            this.tipdescripcionDataGridViewTextBoxColumn.DataPropertyName = "tip_descripcion";
            this.tipdescripcionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.tipdescripcionDataGridViewTextBoxColumn.Name = "tipdescripcionDataGridViewTextBoxColumn";
            this.tipdescripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipimagenDataGridViewCheckBoxColumn
            // 
            this.tipimagenDataGridViewCheckBoxColumn.DataPropertyName = "tip_imagen";
            this.tipimagenDataGridViewCheckBoxColumn.HeaderText = "Tipo Imágen";
            this.tipimagenDataGridViewCheckBoxColumn.Name = "tipimagenDataGridViewCheckBoxColumn";
            this.tipimagenDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // FormTipo_Documental
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 312);
            this.Controls.Add(this.checkBoxImagen);
            this.Controls.Add(this.labelSecuencial);
            this.Controls.Add(this.textBoxSecuencial);
            this.Controls.Add(this.groupBoxDataGrid);
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDescripcion);
            this.Controls.Add(this.textBoxExtension);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormTipo_Documental";
            this.Text = "Tipo Documental";
            this.Load += new System.EventHandler(this.FormTipo_Documental_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTipoDocumental)).EndInit();
            this.groupBoxDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxExtension;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton toolStripButtonTransmitir;
        private System.Windows.Forms.ToolStripButton toolStripButtonModificar;
        private System.Windows.Forms.ToolStripButton toolStripButtonEliminar;
        private System.Windows.Forms.ToolStripButton toolStripButtonBuscar;
        private System.Windows.Forms.DataGridView dataGridViewRegistros;
        private System.Windows.Forms.GroupBox groupBoxDataGrid;
        private System.Windows.Forms.BindingSource bindingSourceTipoDocumental;
        private System.Windows.Forms.TextBox textBoxSecuencial;
        private System.Windows.Forms.Label labelSecuencial;
        private System.Windows.Forms.ToolStripButton toolStripButtonLimpiar;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckBox checkBoxImagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipnumetipDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipextensionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipdescripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tipimagenDataGridViewCheckBoxColumn;
    }
}