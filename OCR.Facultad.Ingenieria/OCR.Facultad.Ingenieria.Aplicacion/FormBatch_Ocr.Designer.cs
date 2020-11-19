namespace OCR.Facultad.Ingenieria.Aplicacion
{
    partial class FormBatch_Ocr
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonTransmitir = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonModificar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLimpiar = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewRegistros = new System.Windows.Forms.DataGridView();
            this.bindingSourceBatchOcr = new System.Windows.Forms.BindingSource(this.components);
            this.labelSecuencial = new System.Windows.Forms.Label();
            this.textBoxSecuencial = new System.Windows.Forms.TextBox();
            this.groupBoxDataGrid = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownProcesos = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonExaminar = new System.Windows.Forms.Button();
            this.textBoxRuta = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.openFileDialogBatch = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.baocridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baocrdescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baocrpathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baocrnlotesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baocrhorainicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baocrhorafinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBatchOcr)).BeginInit();
            this.groupBoxDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProcesos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
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
            this.toolStripMenu.Size = new System.Drawing.Size(749, 25);
            this.toolStripMenu.TabIndex = 13;
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
            this.baocridDataGridViewTextBoxColumn,
            this.baocrdescripcionDataGridViewTextBoxColumn,
            this.baocrpathDataGridViewTextBoxColumn,
            this.baocrnlotesDataGridViewTextBoxColumn,
            this.baocrhorainicioDataGridViewTextBoxColumn,
            this.baocrhorafinDataGridViewTextBoxColumn});
            this.dataGridViewRegistros.DataSource = this.bindingSourceBatchOcr;
            this.dataGridViewRegistros.Location = new System.Drawing.Point(9, 19);
            this.dataGridViewRegistros.Name = "dataGridViewRegistros";
            this.dataGridViewRegistros.ReadOnly = true;
            this.dataGridViewRegistros.Size = new System.Drawing.Size(698, 180);
            this.dataGridViewRegistros.TabIndex = 5;
            this.dataGridViewRegistros.DoubleClick += new System.EventHandler(this.dataGridViewRegistros_DoubleClick);
            // 
            // bindingSourceBatchOcr
            // 
            this.bindingSourceBatchOcr.AllowNew = false;
            this.bindingSourceBatchOcr.DataSource = typeof(OCR.Facultad.Ingenieria.ManagerBases.DataSetBatchOcr.batch_ocrDataTable);
            // 
            // labelSecuencial
            // 
            this.labelSecuencial.AutoSize = true;
            this.labelSecuencial.Location = new System.Drawing.Point(209, 37);
            this.labelSecuencial.Name = "labelSecuencial";
            this.labelSecuencial.Size = new System.Drawing.Size(63, 13);
            this.labelSecuencial.TabIndex = 16;
            this.labelSecuencial.Text = "Secuencial:";
            this.labelSecuencial.Visible = false;
            // 
            // textBoxSecuencial
            // 
            this.textBoxSecuencial.Enabled = false;
            this.textBoxSecuencial.Location = new System.Drawing.Point(278, 31);
            this.textBoxSecuencial.Name = "textBoxSecuencial";
            this.textBoxSecuencial.Size = new System.Drawing.Size(100, 20);
            this.textBoxSecuencial.TabIndex = 15;
            this.textBoxSecuencial.Visible = false;
            // 
            // groupBoxDataGrid
            // 
            this.groupBoxDataGrid.Controls.Add(this.dataGridViewRegistros);
            this.groupBoxDataGrid.Location = new System.Drawing.Point(18, 164);
            this.groupBoxDataGrid.Name = "groupBoxDataGrid";
            this.groupBoxDataGrid.Size = new System.Drawing.Size(717, 209);
            this.groupBoxDataGrid.TabIndex = 14;
            this.groupBoxDataGrid.TabStop = false;
            this.groupBoxDataGrid.Text = "Registros";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Descripción:";
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(98, 96);
            this.textBoxDescripcion.Multiline = true;
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(613, 62);
            this.textBoxDescripcion.TabIndex = 10;
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerInicio.Location = new System.Drawing.Point(79, 19);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.ShowUpDown = true;
            this.dateTimePickerInicio.Size = new System.Drawing.Size(85, 20);
            this.dateTimePickerInicio.TabIndex = 17;
            this.dateTimePickerInicio.Value = new System.DateTime(2012, 5, 4, 23, 23, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nro Procesos:";
            // 
            // numericUpDownProcesos
            // 
            this.numericUpDownProcesos.Location = new System.Drawing.Point(109, 32);
            this.numericUpDownProcesos.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownProcesos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownProcesos.Name = "numericUpDownProcesos";
            this.numericUpDownProcesos.Size = new System.Drawing.Size(94, 20);
            this.numericUpDownProcesos.TabIndex = 19;
            this.numericUpDownProcesos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Inicio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Fin:";
            // 
            // dateTimePickerFin
            // 
            this.dateTimePickerFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerFin.Location = new System.Drawing.Point(220, 19);
            this.dateTimePickerFin.Name = "dateTimePickerFin";
            this.dateTimePickerFin.ShowUpDown = true;
            this.dateTimePickerFin.Size = new System.Drawing.Size(91, 20);
            this.dateTimePickerFin.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePickerInicio);
            this.groupBox1.Controls.Add(this.dateTimePickerFin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(384, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 62);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Horarios de Procesamiento:";
            // 
            // buttonExaminar
            // 
            this.buttonExaminar.Location = new System.Drawing.Point(295, 12);
            this.buttonExaminar.Name = "buttonExaminar";
            this.buttonExaminar.Size = new System.Drawing.Size(67, 23);
            this.buttonExaminar.TabIndex = 26;
            this.buttonExaminar.Text = "Examinar";
            this.buttonExaminar.UseVisualStyleBackColor = true;
            this.buttonExaminar.Click += new System.EventHandler(this.buttonExaminar_Click);
            // 
            // textBoxRuta
            // 
            this.textBoxRuta.Location = new System.Drawing.Point(24, 67);
            this.textBoxRuta.Name = "textBoxRuta";
            this.textBoxRuta.Size = new System.Drawing.Size(265, 20);
            this.textBoxRuta.TabIndex = 25;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonExaminar);
            this.groupBox3.Location = new System.Drawing.Point(12, 53);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(366, 37);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ruta";
            // 
            // openFileDialogBatch
            // 
            this.openFileDialogBatch.DefaultExt = "*.exe";
            this.openFileDialogBatch.FileName = "openFileDialog1";
            this.openFileDialogBatch.Filter = "|*.exe";
            this.openFileDialogBatch.Title = "Ejecutable Proceso Batch";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // baocridDataGridViewTextBoxColumn
            // 
            this.baocridDataGridViewTextBoxColumn.DataPropertyName = "ba_ocr_id";
            this.baocridDataGridViewTextBoxColumn.HeaderText = "Ocr id";
            this.baocridDataGridViewTextBoxColumn.Name = "baocridDataGridViewTextBoxColumn";
            this.baocridDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // baocrdescripcionDataGridViewTextBoxColumn
            // 
            this.baocrdescripcionDataGridViewTextBoxColumn.DataPropertyName = "ba_ocr_descripcion";
            this.baocrdescripcionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.baocrdescripcionDataGridViewTextBoxColumn.Name = "baocrdescripcionDataGridViewTextBoxColumn";
            this.baocrdescripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // baocrpathDataGridViewTextBoxColumn
            // 
            this.baocrpathDataGridViewTextBoxColumn.DataPropertyName = "ba_ocr_path";
            this.baocrpathDataGridViewTextBoxColumn.HeaderText = "Path";
            this.baocrpathDataGridViewTextBoxColumn.Name = "baocrpathDataGridViewTextBoxColumn";
            this.baocrpathDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // baocrnlotesDataGridViewTextBoxColumn
            // 
            this.baocrnlotesDataGridViewTextBoxColumn.DataPropertyName = "ba_ocr_nlotes";
            this.baocrnlotesDataGridViewTextBoxColumn.HeaderText = "Nro Lotes";
            this.baocrnlotesDataGridViewTextBoxColumn.Name = "baocrnlotesDataGridViewTextBoxColumn";
            this.baocrnlotesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // baocrhorainicioDataGridViewTextBoxColumn
            // 
            this.baocrhorainicioDataGridViewTextBoxColumn.DataPropertyName = "ba_ocr_horainicio";
            dataGridViewCellStyle1.Format = "t";
            dataGridViewCellStyle1.NullValue = null;
            this.baocrhorainicioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.baocrhorainicioDataGridViewTextBoxColumn.HeaderText = "Hora de Inicio";
            this.baocrhorainicioDataGridViewTextBoxColumn.Name = "baocrhorainicioDataGridViewTextBoxColumn";
            this.baocrhorainicioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // baocrhorafinDataGridViewTextBoxColumn
            // 
            this.baocrhorafinDataGridViewTextBoxColumn.DataPropertyName = "ba_ocr_horafin";
            dataGridViewCellStyle2.Format = "t";
            dataGridViewCellStyle2.NullValue = null;
            this.baocrhorafinDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.baocrhorafinDataGridViewTextBoxColumn.HeaderText = "Hora de Finalización";
            this.baocrhorafinDataGridViewTextBoxColumn.Name = "baocrhorafinDataGridViewTextBoxColumn";
            this.baocrhorafinDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FormBatch_Ocr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 393);
            this.Controls.Add(this.textBoxRuta);
            this.Controls.Add(this.numericUpDownProcesos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.labelSecuencial);
            this.Controls.Add(this.textBoxSecuencial);
            this.Controls.Add(this.groupBoxDataGrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDescripcion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormBatch_Ocr";
            this.Text = "Batch Ocr";
            this.Load += new System.EventHandler(this.FormBatch_Ocr_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBatchOcr)).EndInit();
            this.groupBoxDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProcesos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton toolStripButtonBuscar;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton toolStripButtonTransmitir;
        private System.Windows.Forms.ToolStripButton toolStripButtonModificar;
        private System.Windows.Forms.ToolStripButton toolStripButtonEliminar;
        private System.Windows.Forms.ToolStripButton toolStripButtonLimpiar;
        private System.Windows.Forms.DataGridView dataGridViewRegistros;
        private System.Windows.Forms.BindingSource bindingSourceBatchOcr;
        private System.Windows.Forms.Label labelSecuencial;
        private System.Windows.Forms.TextBox textBoxSecuencial;
        private System.Windows.Forms.GroupBox groupBoxDataGrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownProcesos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerFin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonExaminar;
        private System.Windows.Forms.TextBox textBoxRuta;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.OpenFileDialog openFileDialogBatch;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn baocridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn baocrdescripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn baocrpathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn baocrnlotesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn baocrhorainicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn baocrhorafinDataGridViewTextBoxColumn;
    }
}