namespace OCR.Facultad.Ingenieria.Aplicacion
{
    partial class FormBatchOcr_Ruta
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
            this.comboBoxRutaPrin = new System.Windows.Forms.ComboBox();
            this.bindingSourceRutaPrincipal = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxRutaPrinSecuencial = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxRutaDescripcion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bindingSourceRuta = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxTipoDocumental = new System.Windows.Forms.ComboBox();
            this.bindingSourceTipo_Documental = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxTipoDesc = new System.Windows.Forms.TextBox();
            this.textBoxTipoSecuencial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxRutasPorSeleccionar = new System.Windows.Forms.ListBox();
            this.listBoxRutasSeleccionadas = new System.Windows.Forms.ListBox();
            this.bindingSourceRutaSeleccionadas = new System.Windows.Forms.BindingSource(this.components);
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonAddAll = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonRemoveAll = new System.Windows.Forms.Button();
            this.textBoxRutaPath = new System.Windows.Forms.TextBox();
            this.checkBoxRutaActiva = new System.Windows.Forms.CheckBox();
            this.textBoxRutaSecuencial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxRutaTipo_Documental = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxProcesoDescripcion = new System.Windows.Forms.TextBox();
            this.bindingSourceBatchOcr = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxProcesoSec = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxProceso = new System.Windows.Forms.ComboBox();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonTransmitir = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonModificar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLimpiar = new System.Windows.Forms.ToolStripButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRutaPrincipal)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRuta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTipo_Documental)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRutaSeleccionadas)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBatchOcr)).BeginInit();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxRutaPrin
            // 
            this.comboBoxRutaPrin.DataSource = this.bindingSourceRutaPrincipal;
            this.comboBoxRutaPrin.DisplayMember = "ru_path";
            this.comboBoxRutaPrin.FormattingEnabled = true;
            this.comboBoxRutaPrin.Location = new System.Drawing.Point(91, 19);
            this.comboBoxRutaPrin.Name = "comboBoxRutaPrin";
            this.comboBoxRutaPrin.Size = new System.Drawing.Size(352, 21);
            this.comboBoxRutaPrin.TabIndex = 0;
            this.comboBoxRutaPrin.ValueMember = "ru_id";
            // 
            // bindingSourceRutaPrincipal
            // 
            this.bindingSourceRutaPrincipal.AllowNew = false;
            this.bindingSourceRutaPrincipal.DataSource = typeof(OCR.Facultad.Ingenieria.ManagerBases.DataSetRuta.rutaDataTable);
            // 
            // textBoxRutaPrinSecuencial
            // 
            this.textBoxRutaPrinSecuencial.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bindingSourceRutaPrincipal, "ru_id", true));
            this.textBoxRutaPrinSecuencial.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceRutaPrincipal, "ru_id", true));
            this.textBoxRutaPrinSecuencial.Enabled = false;
            this.textBoxRutaPrinSecuencial.Location = new System.Drawing.Point(22, 19);
            this.textBoxRutaPrinSecuencial.Name = "textBoxRutaPrinSecuencial";
            this.textBoxRutaPrinSecuencial.Size = new System.Drawing.Size(63, 20);
            this.textBoxRutaPrinSecuencial.TabIndex = 16;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxRutaDescripcion);
            this.groupBox3.Controls.Add(this.textBoxRutaPrinSecuencial);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.comboBoxRutaPrin);
            this.groupBox3.Location = new System.Drawing.Point(79, 130);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(456, 93);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rutas Principales";
            // 
            // textBoxRutaDescripcion
            // 
            this.textBoxRutaDescripcion.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bindingSourceRutaPrincipal, "ru_id", true));
            this.textBoxRutaDescripcion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceRutaPrincipal, "ru_descripcion", true));
            this.textBoxRutaDescripcion.Location = new System.Drawing.Point(91, 42);
            this.textBoxRutaDescripcion.Multiline = true;
            this.textBoxRutaDescripcion.Name = "textBoxRutaDescripcion";
            this.textBoxRutaDescripcion.Size = new System.Drawing.Size(352, 50);
            this.textBoxRutaDescripcion.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Descripción:";
            // 
            // bindingSourceRuta
            // 
            this.bindingSourceRuta.AllowNew = false;
            this.bindingSourceRuta.DataSource = typeof(OCR.Facultad.Ingenieria.ManagerBases.DataSetRuta.rutaDataTable);
            // 
            // comboBoxTipoDocumental
            // 
            this.comboBoxTipoDocumental.DataSource = this.bindingSourceTipo_Documental;
            this.comboBoxTipoDocumental.DisplayMember = "tip_extension";
            this.comboBoxTipoDocumental.FormattingEnabled = true;
            this.comboBoxTipoDocumental.Location = new System.Drawing.Point(78, 19);
            this.comboBoxTipoDocumental.Name = "comboBoxTipoDocumental";
            this.comboBoxTipoDocumental.Size = new System.Drawing.Size(130, 21);
            this.comboBoxTipoDocumental.TabIndex = 31;
            this.comboBoxTipoDocumental.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoDocumental_SelectedIndexChanged);
            // 
            // bindingSourceTipo_Documental
            // 
            this.bindingSourceTipo_Documental.AllowNew = false;
            this.bindingSourceTipo_Documental.DataSource = typeof(OCR.Facultad.Ingenieria.ManagerBases.DataSetTipo_Documental.tipo_documentalDataTable);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxTipoDesc);
            this.groupBox1.Controls.Add(this.textBoxTipoSecuencial);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxTipoDocumental);
            this.groupBox1.Location = new System.Drawing.Point(18, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 101);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipos Documentales";
            // 
            // textBoxTipoDesc
            // 
            this.textBoxTipoDesc.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bindingSourceTipo_Documental, "tip_nume_tip", true));
            this.textBoxTipoDesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceTipo_Documental, "tip_descripcion", true));
            this.textBoxTipoDesc.Location = new System.Drawing.Point(78, 42);
            this.textBoxTipoDesc.Multiline = true;
            this.textBoxTipoDesc.Name = "textBoxTipoDesc";
            this.textBoxTipoDesc.Size = new System.Drawing.Size(130, 53);
            this.textBoxTipoDesc.TabIndex = 18;
            // 
            // textBoxTipoSecuencial
            // 
            this.textBoxTipoSecuencial.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bindingSourceTipo_Documental, "tip_nume_tip", true));
            this.textBoxTipoSecuencial.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceTipo_Documental, "tip_nume_tip", true));
            this.textBoxTipoSecuencial.Enabled = false;
            this.textBoxTipoSecuencial.Location = new System.Drawing.Point(7, 19);
            this.textBoxTipoSecuencial.Name = "textBoxTipoSecuencial";
            this.textBoxTipoSecuencial.Size = new System.Drawing.Size(65, 20);
            this.textBoxTipoSecuencial.TabIndex = 17;
            this.textBoxTipoSecuencial.TextChanged += new System.EventHandler(this.textBoxTipoSecuencial_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Descripción:";
            // 
            // listBoxRutasPorSeleccionar
            // 
            this.listBoxRutasPorSeleccionar.DataSource = this.bindingSourceRuta;
            this.listBoxRutasPorSeleccionar.DisplayMember = "ru_path";
            this.listBoxRutasPorSeleccionar.FormattingEnabled = true;
            this.listBoxRutasPorSeleccionar.Location = new System.Drawing.Point(12, 229);
            this.listBoxRutasPorSeleccionar.Name = "listBoxRutasPorSeleccionar";
            this.listBoxRutasPorSeleccionar.Size = new System.Drawing.Size(307, 290);
            this.listBoxRutasPorSeleccionar.TabIndex = 33;
            this.listBoxRutasPorSeleccionar.SelectedIndexChanged += new System.EventHandler(this.listBoxRutasPorSeleccionar_SelectedIndexChanged);
            this.listBoxRutasPorSeleccionar.DoubleClick += new System.EventHandler(this.listBoxRutasPorSeleccionar_DoubleClick);
            // 
            // listBoxRutasSeleccionadas
            // 
            this.listBoxRutasSeleccionadas.DataSource = this.bindingSourceRutaSeleccionadas;
            this.listBoxRutasSeleccionadas.DisplayMember = "ru_path";
            this.listBoxRutasSeleccionadas.FormattingEnabled = true;
            this.listBoxRutasSeleccionadas.Location = new System.Drawing.Point(405, 229);
            this.listBoxRutasSeleccionadas.Name = "listBoxRutasSeleccionadas";
            this.listBoxRutasSeleccionadas.Size = new System.Drawing.Size(298, 290);
            this.listBoxRutasSeleccionadas.TabIndex = 34;
            this.listBoxRutasSeleccionadas.Tag = "ru_path";
            this.listBoxRutasSeleccionadas.SelectedIndexChanged += new System.EventHandler(this.listBoxRutasSeleccionadas_SelectedIndexChanged);
            this.listBoxRutasSeleccionadas.DoubleClick += new System.EventHandler(this.listBoxRutasSeleccionadas_DoubleClick);
            // 
            // bindingSourceRutaSeleccionadas
            // 
            this.bindingSourceRutaSeleccionadas.AllowNew = true;
            this.bindingSourceRutaSeleccionadas.DataSource = typeof(OCR.Facultad.Ingenieria.ManagerBases.DataSetRuta.rutaDataTable);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(337, 233);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(57, 55);
            this.buttonAdd.TabIndex = 35;
            this.buttonAdd.Text = ">";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonAddAll
            // 
            this.buttonAddAll.Location = new System.Drawing.Point(337, 310);
            this.buttonAddAll.Name = "buttonAddAll";
            this.buttonAddAll.Size = new System.Drawing.Size(57, 55);
            this.buttonAddAll.TabIndex = 36;
            this.buttonAddAll.Text = ">>";
            this.buttonAddAll.UseVisualStyleBackColor = true;
            this.buttonAddAll.Click += new System.EventHandler(this.buttonAddAll_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(337, 393);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(57, 55);
            this.buttonRemove.TabIndex = 37;
            this.buttonRemove.Text = "<";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonRemoveAll
            // 
            this.buttonRemoveAll.Location = new System.Drawing.Point(337, 464);
            this.buttonRemoveAll.Name = "buttonRemoveAll";
            this.buttonRemoveAll.Size = new System.Drawing.Size(57, 55);
            this.buttonRemoveAll.TabIndex = 38;
            this.buttonRemoveAll.Text = "<<";
            this.buttonRemoveAll.UseVisualStyleBackColor = true;
            this.buttonRemoveAll.Click += new System.EventHandler(this.buttonRemoveAll_Click);
            // 
            // textBoxRutaPath
            // 
            this.textBoxRutaPath.Location = new System.Drawing.Point(105, 44);
            this.textBoxRutaPath.Name = "textBoxRutaPath";
            this.textBoxRutaPath.Size = new System.Drawing.Size(487, 20);
            this.textBoxRutaPath.TabIndex = 39;
            // 
            // checkBoxRutaActiva
            // 
            this.checkBoxRutaActiva.AutoSize = true;
            this.checkBoxRutaActiva.Enabled = false;
            this.checkBoxRutaActiva.Location = new System.Drawing.Point(313, 21);
            this.checkBoxRutaActiva.Name = "checkBoxRutaActiva";
            this.checkBoxRutaActiva.Size = new System.Drawing.Size(40, 17);
            this.checkBoxRutaActiva.TabIndex = 40;
            this.checkBoxRutaActiva.Text = "No";
            this.checkBoxRutaActiva.UseVisualStyleBackColor = true;
            this.checkBoxRutaActiva.CheckedChanged += new System.EventHandler(this.checkBoxRutaActiva_CheckedChanged);
            // 
            // textBoxRutaSecuencial
            // 
            this.textBoxRutaSecuencial.Enabled = false;
            this.textBoxRutaSecuencial.Location = new System.Drawing.Point(105, 18);
            this.textBoxRutaSecuencial.Name = "textBoxRutaSecuencial";
            this.textBoxRutaSecuencial.Size = new System.Drawing.Size(47, 20);
            this.textBoxRutaSecuencial.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Path:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Activa:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Secuencial:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxRutaTipo_Documental);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxRutaPath);
            this.groupBox2.Controls.Add(this.checkBoxRutaActiva);
            this.groupBox2.Controls.Add(this.textBoxRutaSecuencial);
            this.groupBox2.Location = new System.Drawing.Point(24, 593);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(689, 78);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Descripción Ruta";
            // 
            // textBoxRutaTipo_Documental
            // 
            this.textBoxRutaTipo_Documental.Enabled = false;
            this.textBoxRutaTipo_Documental.Location = new System.Drawing.Point(492, 18);
            this.textBoxRutaTipo_Documental.Name = "textBoxRutaTipo_Documental";
            this.textBoxRutaTipo_Documental.Size = new System.Drawing.Size(100, 20);
            this.textBoxRutaTipo_Documental.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(395, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Tipo Documental:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxProcesoDescripcion);
            this.groupBox4.Controls.Add(this.textBoxProcesoSec);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.comboBoxProceso);
            this.groupBox4.Location = new System.Drawing.Point(247, 28);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(456, 101);
            this.groupBox4.TabIndex = 46;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Proceso Batch";
            // 
            // textBoxProcesoDescripcion
            // 
            this.textBoxProcesoDescripcion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceBatchOcr, "ba_ocr_descripcion", true));
            this.textBoxProcesoDescripcion.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bindingSourceBatchOcr, "ba_ocr_id", true));
            this.textBoxProcesoDescripcion.Location = new System.Drawing.Point(91, 45);
            this.textBoxProcesoDescripcion.Multiline = true;
            this.textBoxProcesoDescripcion.Name = "textBoxProcesoDescripcion";
            this.textBoxProcesoDescripcion.Size = new System.Drawing.Size(352, 50);
            this.textBoxProcesoDescripcion.TabIndex = 33;
            // 
            // bindingSourceBatchOcr
            // 
            this.bindingSourceBatchOcr.AllowNew = false;
            this.bindingSourceBatchOcr.DataSource = typeof(OCR.Facultad.Ingenieria.ManagerBases.DataSetBatchOcr.batch_ocrDataTable);
            // 
            // textBoxProcesoSec
            // 
            this.textBoxProcesoSec.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bindingSourceBatchOcr, "ba_ocr_id", true));
            this.textBoxProcesoSec.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceBatchOcr, "ba_ocr_id", true));
            this.textBoxProcesoSec.Enabled = false;
            this.textBoxProcesoSec.Location = new System.Drawing.Point(22, 19);
            this.textBoxProcesoSec.Name = "textBoxProcesoSec";
            this.textBoxProcesoSec.Size = new System.Drawing.Size(63, 20);
            this.textBoxProcesoSec.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Descripción:";
            // 
            // comboBoxProceso
            // 
            this.comboBoxProceso.DataSource = this.bindingSourceBatchOcr;
            this.comboBoxProceso.DisplayMember = "ba_ocr_path";
            this.comboBoxProceso.FormattingEnabled = true;
            this.comboBoxProceso.Location = new System.Drawing.Point(91, 19);
            this.comboBoxProceso.Name = "comboBoxProceso";
            this.comboBoxProceso.Size = new System.Drawing.Size(352, 21);
            this.comboBoxProceso.TabIndex = 0;
            this.comboBoxProceso.ValueMember = "ru_id";
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
            this.toolStripMenu.Size = new System.Drawing.Size(735, 25);
            this.toolStripMenu.TabIndex = 47;
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
            this.toolStripButtonModificar.Visible = false;
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
            this.toolStripButtonEliminar.Visible = false;
            // 
            // toolStripButtonBuscar
            // 
            this.toolStripButtonBuscar.Image = global::OCR.Facultad.Ingenieria.Aplicacion.Properties.Resources.onebit_buscar;
            this.toolStripButtonBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBuscar.Name = "toolStripButtonBuscar";
            this.toolStripButtonBuscar.Size = new System.Drawing.Size(62, 22);
            this.toolStripButtonBuscar.Text = "Buscar";
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
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FormBatchOcr_Ruta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 523);
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonRemoveAll);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAddAll);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listBoxRutasSeleccionadas);
            this.Controls.Add(this.listBoxRutasPorSeleccionar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormBatchOcr_Ruta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Asociación Batch Ocr - Ruta";
            this.Load += new System.EventHandler(this.FormBatchOcr_Ruta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRutaPrincipal)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRuta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTipo_Documental)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRutaSeleccionadas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBatchOcr)).EndInit();
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxRutaPrin;
        private System.Windows.Forms.TextBox textBoxRutaPrinSecuencial;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBoxTipoDocumental;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxTipoDesc;
        private System.Windows.Forms.TextBox textBoxTipoSecuencial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxRutasPorSeleccionar;
        private System.Windows.Forms.ListBox listBoxRutasSeleccionadas;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonAddAll;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonRemoveAll;
        private System.Windows.Forms.TextBox textBoxRutaPath;
        private System.Windows.Forms.CheckBox checkBoxRutaActiva;
        private System.Windows.Forms.TextBox textBoxRutaSecuencial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.BindingSource bindingSourceRuta;
        private System.Windows.Forms.BindingSource bindingSourceTipo_Documental;
        private System.Windows.Forms.BindingSource bindingSourceRutaPrincipal;
        private System.Windows.Forms.BindingSource bindingSourceRutaSeleccionadas;
        private System.Windows.Forms.TextBox textBoxRutaTipo_Documental;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxProcesoSec;
        private System.Windows.Forms.ComboBox comboBoxProceso;
        private System.Windows.Forms.BindingSource bindingSourceBatchOcr;
        private System.Windows.Forms.TextBox textBoxProcesoDescripcion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxRutaDescripcion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton toolStripButtonTransmitir;
        private System.Windows.Forms.ToolStripButton toolStripButtonModificar;
        private System.Windows.Forms.ToolStripButton toolStripButtonEliminar;
        private System.Windows.Forms.ToolStripButton toolStripButtonBuscar;
        private System.Windows.Forms.ToolStripButton toolStripButtonLimpiar;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}