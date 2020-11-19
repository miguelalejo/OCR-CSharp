namespace OCR.Facultad.Ingenieria.Aplicacion
{
    partial class FormTipo_Imagen
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
            this.tipextensionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxExtension = new System.Windows.Forms.TextBox();
            this.tipdescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipnumetipDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceTipoDocumental = new System.Windows.Forms.BindingSource(this.components);
            this.labelSecuencial = new System.Windows.Forms.Label();
            this.textBoxSecuencial = new System.Windows.Forms.TextBox();
            this.groupBoxDataGrid = new System.Windows.Forms.GroupBox();
            this.dataGridViewRegistros = new System.Windows.Forms.DataGridView();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.toolStripButtonTransmitir = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonModificar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLimpiar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTipoDocumental)).BeginInit();
            this.groupBoxDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegistros)).BeginInit();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tipextensionDataGridViewTextBoxColumn
            // 
            this.tipextensionDataGridViewTextBoxColumn.DataPropertyName = "tip_extension";
            this.tipextensionDataGridViewTextBoxColumn.HeaderText = "Extensión";
            this.tipextensionDataGridViewTextBoxColumn.Name = "tipextensionDataGridViewTextBoxColumn";
            this.tipextensionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // textBoxExtension
            // 
            this.textBoxExtension.Location = new System.Drawing.Point(90, 34);
            this.textBoxExtension.Name = "textBoxExtension";
            this.textBoxExtension.Size = new System.Drawing.Size(85, 20);
            this.textBoxExtension.TabIndex = 9;
            // 
            // tipdescripcionDataGridViewTextBoxColumn
            // 
            this.tipdescripcionDataGridViewTextBoxColumn.DataPropertyName = "tip_descripcion";
            this.tipdescripcionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.tipdescripcionDataGridViewTextBoxColumn.Name = "tipdescripcionDataGridViewTextBoxColumn";
            this.tipdescripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipnumetipDataGridViewTextBoxColumn
            // 
            this.tipnumetipDataGridViewTextBoxColumn.DataPropertyName = "tip_nume_tip";
            this.tipnumetipDataGridViewTextBoxColumn.HeaderText = "ID";
            this.tipnumetipDataGridViewTextBoxColumn.Name = "tipnumetipDataGridViewTextBoxColumn";
            this.tipnumetipDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingSourceTipoDocumental
            // 
            this.bindingSourceTipoDocumental.AllowNew = false;
            this.bindingSourceTipoDocumental.DataSource = typeof(OCR.Facultad.Ingenieria.ManagerBases.DataSetTipo_Documental.tipo_documentalDataTable);
            // 
            // labelSecuencial
            // 
            this.labelSecuencial.AutoSize = true;
            this.labelSecuencial.Location = new System.Drawing.Point(190, 37);
            this.labelSecuencial.Name = "labelSecuencial";
            this.labelSecuencial.Size = new System.Drawing.Size(63, 13);
            this.labelSecuencial.TabIndex = 16;
            this.labelSecuencial.Text = "Secuencial:";
            this.labelSecuencial.Visible = false;
            // 
            // textBoxSecuencial
            // 
            this.textBoxSecuencial.Enabled = false;
            this.textBoxSecuencial.Location = new System.Drawing.Point(259, 31);
            this.textBoxSecuencial.Name = "textBoxSecuencial";
            this.textBoxSecuencial.Size = new System.Drawing.Size(100, 20);
            this.textBoxSecuencial.TabIndex = 15;
            this.textBoxSecuencial.Visible = false;
            // 
            // groupBoxDataGrid
            // 
            this.groupBoxDataGrid.Controls.Add(this.dataGridViewRegistros);
            this.groupBoxDataGrid.Location = new System.Drawing.Point(5, 90);
            this.groupBoxDataGrid.Name = "groupBoxDataGrid";
            this.groupBoxDataGrid.Size = new System.Drawing.Size(388, 209);
            this.groupBoxDataGrid.TabIndex = 14;
            this.groupBoxDataGrid.TabStop = false;
            this.groupBoxDataGrid.Text = "Registros";
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
            this.tipdescripcionDataGridViewTextBoxColumn});
            this.dataGridViewRegistros.DataSource = this.bindingSourceTipoDocumental;
            this.dataGridViewRegistros.Location = new System.Drawing.Point(7, 19);
            this.dataGridViewRegistros.Name = "dataGridViewRegistros";
            this.dataGridViewRegistros.ReadOnly = true;
            this.dataGridViewRegistros.Size = new System.Drawing.Size(375, 180);
            this.dataGridViewRegistros.TabIndex = 5;
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
            this.toolStripMenu.Size = new System.Drawing.Size(400, 25);
            this.toolStripMenu.TabIndex = 13;
            this.toolStripMenu.Text = "Menu Principal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Descripción:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Extensión:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(90, 64);
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(266, 20);
            this.textBoxDescripcion.TabIndex = 10;
            // 
            // toolStripButtonTransmitir
            // 
            this.toolStripButtonTransmitir.Image = global::OCR.Facultad.Ingenieria.Aplicacion.Properties.Resources.onebit_guardar;
            this.toolStripButtonTransmitir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTransmitir.Name = "toolStripButtonTransmitir";
            this.toolStripButtonTransmitir.Size = new System.Drawing.Size(81, 22);
            this.toolStripButtonTransmitir.Text = "Transmitir";
            // 
            // toolStripButtonModificar
            // 
            this.toolStripButtonModificar.Enabled = false;
            this.toolStripButtonModificar.Image = global::OCR.Facultad.Ingenieria.Aplicacion.Properties.Resources.onebit_modificar;
            this.toolStripButtonModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonModificar.Name = "toolStripButtonModificar";
            this.toolStripButtonModificar.Size = new System.Drawing.Size(78, 22);
            this.toolStripButtonModificar.Text = "Modificar";
            // 
            // toolStripButtonEliminar
            // 
            this.toolStripButtonEliminar.Enabled = false;
            this.toolStripButtonEliminar.Image = global::OCR.Facultad.Ingenieria.Aplicacion.Properties.Resources.onebit_eliminar;
            this.toolStripButtonEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEliminar.Name = "toolStripButtonEliminar";
            this.toolStripButtonEliminar.Size = new System.Drawing.Size(70, 22);
            this.toolStripButtonEliminar.Text = "Eliminar";
            // 
            // toolStripButtonBuscar
            // 
            this.toolStripButtonBuscar.Image = global::OCR.Facultad.Ingenieria.Aplicacion.Properties.Resources.onebit_buscar;
            this.toolStripButtonBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBuscar.Name = "toolStripButtonBuscar";
            this.toolStripButtonBuscar.Size = new System.Drawing.Size(62, 22);
            this.toolStripButtonBuscar.Text = "Buscar";
            this.toolStripButtonBuscar.Visible = false;
            // 
            // toolStripButtonLimpiar
            // 
            this.toolStripButtonLimpiar.Image = global::OCR.Facultad.Ingenieria.Aplicacion.Properties.Resources.onebit_home;
            this.toolStripButtonLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLimpiar.Name = "toolStripButtonLimpiar";
            this.toolStripButtonLimpiar.Size = new System.Drawing.Size(67, 22);
            this.toolStripButtonLimpiar.Text = "Limpiar";
            // 
            // FormTipo_Imagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 314);
            this.Controls.Add(this.textBoxExtension);
            this.Controls.Add(this.labelSecuencial);
            this.Controls.Add(this.textBoxSecuencial);
            this.Controls.Add(this.groupBoxDataGrid);
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDescripcion);
            this.Name = "FormTipo_Imagen";
            this.Text = "FormTipo_Imagen";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTipoDocumental)).EndInit();
            this.groupBoxDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegistros)).EndInit();
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn tipextensionDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox textBoxExtension;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipdescripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipnumetipDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bindingSourceTipoDocumental;
        private System.Windows.Forms.Label labelSecuencial;
        private System.Windows.Forms.TextBox textBoxSecuencial;
        private System.Windows.Forms.GroupBox groupBoxDataGrid;
        private System.Windows.Forms.DataGridView dataGridViewRegistros;
        private System.Windows.Forms.ToolStripButton toolStripButtonLimpiar;
        private System.Windows.Forms.ToolStripButton toolStripButtonBuscar;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton toolStripButtonTransmitir;
        private System.Windows.Forms.ToolStripButton toolStripButtonModificar;
        private System.Windows.Forms.ToolStripButton toolStripButtonEliminar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox textBoxDescripcion;
    }
}