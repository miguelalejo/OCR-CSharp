namespace OCR.Facultad.Ingenieria.Aplicacion
{
    partial class FormPrincipal
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
            this.fileQuipuxWatcher = new System.IO.FileSystemWatcher();
            this.progressBarProcesados = new System.Windows.Forms.ProgressBar();
            this.groupBoxArchivo = new System.Windows.Forms.GroupBox();
            this.labelAProfundidadBits = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.maskedTextBoxAFCreacion = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maskedTextBoxAFmodificacion = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelANombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxOcr = new System.Windows.Forms.GroupBox();
            this.labelANlineas = new System.Windows.Forms.Label();
            this.labelANpalabras = new System.Windows.Forms.Label();
            this.labelANcaracteres = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelANpaginas = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelAVertical = new System.Windows.Forms.Label();
            this.labelAHorizontal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxRutaOrigen = new System.Windows.Forms.GroupBox();
            this.textBoxRutaOrigen = new System.Windows.Forms.TextBox();
            this.groupBoxestado = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.labelPIdproceso = new System.Windows.Forms.Label();
            this.maskedTextBoxPFinProceso = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.maskedTextBoxPInicioProceso = new System.Windows.Forms.MaskedTextBox();
            this.buttonProcesar = new System.Windows.Forms.Button();
            this.timerRevisaProcesados = new System.Windows.Forms.Timer(this.components);
            this.listBoxProcesados = new System.Windows.Forms.ListBox();
            this.buttonDetener = new System.Windows.Forms.Button();
            this.groupBoxRutasDestino = new System.Windows.Forms.GroupBox();
            this.listBoxRutasDestino = new System.Windows.Forms.ListBox();
            this.listBoxFormatosExportacion = new System.Windows.Forms.ListBox();
            this.groupBoxFomatosExportacion = new System.Windows.Forms.GroupBox();
            this.groupBoxInformacionGlobal = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.labelsegundos = new System.Windows.Forms.Label();
            this.labelminutos = new System.Windows.Forms.Label();
            this.labelhoras = new System.Windows.Forms.Label();
            this.labeldias = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.labelpornoprocesados = new System.Windows.Forms.Label();
            this.labelporprocesados = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelnnoprocesados = new System.Windows.Forms.Label();
            this.labelnprocesados = new System.Windows.Forms.Label();
            this.labelnpaginas = new System.Windows.Forms.Label();
            this.labelnrarchivos = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBoxArhcivosProcesados = new System.Windows.Forms.GroupBox();
            this.timerCargarBase = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.checkBoxMoverDoc = new System.Windows.Forms.CheckBox();
            this.checkBoxDeskew = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoArranque = new System.Windows.Forms.CheckBox();
            this.listBoxNoProcesados = new System.Windows.Forms.ListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.timerAutoArranque = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxRutaProceso = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileQuipuxWatcher)).BeginInit();
            this.groupBoxArchivo.SuspendLayout();
            this.groupBoxOcr.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxRutaOrigen.SuspendLayout();
            this.groupBoxestado.SuspendLayout();
            this.groupBoxRutasDestino.SuspendLayout();
            this.groupBoxFomatosExportacion.SuspendLayout();
            this.groupBoxInformacionGlobal.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBoxArhcivosProcesados.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileQuipuxWatcher
            // 
            this.fileQuipuxWatcher.EnableRaisingEvents = true;
            this.fileQuipuxWatcher.SynchronizingObject = this;
            this.fileQuipuxWatcher.Renamed += new System.IO.RenamedEventHandler(this.fileQuipuxWatcher_Renamed);
            this.fileQuipuxWatcher.Deleted += new System.IO.FileSystemEventHandler(this.fileQuipuxWatcher_Deleted);
            this.fileQuipuxWatcher.Created += new System.IO.FileSystemEventHandler(this.fileQuipuxWatcher_Created);
            this.fileQuipuxWatcher.Changed += new System.IO.FileSystemEventHandler(this.fileQuipuxWatcher_Changed);
            // 
            // progressBarProcesados
            // 
            this.progressBarProcesados.Location = new System.Drawing.Point(10, 432);
            this.progressBarProcesados.Name = "progressBarProcesados";
            this.progressBarProcesados.Size = new System.Drawing.Size(641, 22);
            this.progressBarProcesados.TabIndex = 0;
            // 
            // groupBoxArchivo
            // 
            this.groupBoxArchivo.AutoSize = true;
            this.groupBoxArchivo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxArchivo.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxArchivo.Controls.Add(this.labelAProfundidadBits);
            this.groupBoxArchivo.Controls.Add(this.label4);
            this.groupBoxArchivo.Controls.Add(this.maskedTextBoxAFCreacion);
            this.groupBoxArchivo.Controls.Add(this.label3);
            this.groupBoxArchivo.Controls.Add(this.maskedTextBoxAFmodificacion);
            this.groupBoxArchivo.Controls.Add(this.label2);
            this.groupBoxArchivo.Controls.Add(this.labelANombre);
            this.groupBoxArchivo.Controls.Add(this.label1);
            this.groupBoxArchivo.Location = new System.Drawing.Point(4, 194);
            this.groupBoxArchivo.Name = "groupBoxArchivo";
            this.groupBoxArchivo.Size = new System.Drawing.Size(249, 120);
            this.groupBoxArchivo.TabIndex = 1;
            this.groupBoxArchivo.TabStop = false;
            this.groupBoxArchivo.Text = "Información Archivo";
            // 
            // labelAProfundidadBits
            // 
            this.labelAProfundidadBits.AutoSize = true;
            this.labelAProfundidadBits.Location = new System.Drawing.Point(127, 91);
            this.labelAProfundidadBits.Name = "labelAProfundidadBits";
            this.labelAProfundidadBits.Size = new System.Drawing.Size(16, 13);
            this.labelAProfundidadBits.TabIndex = 7;
            this.labelAProfundidadBits.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Profundidad en Bits:";
            // 
            // maskedTextBoxAFCreacion
            // 
            this.maskedTextBoxAFCreacion.Location = new System.Drawing.Point(127, 59);
            this.maskedTextBoxAFCreacion.Mask = "00/00/0000";
            this.maskedTextBoxAFCreacion.Name = "maskedTextBoxAFCreacion";
            this.maskedTextBoxAFCreacion.Size = new System.Drawing.Size(116, 20);
            this.maskedTextBoxAFCreacion.TabIndex = 5;
            this.maskedTextBoxAFCreacion.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha  Creación:";
            // 
            // maskedTextBoxAFmodificacion
            // 
            this.maskedTextBoxAFmodificacion.Location = new System.Drawing.Point(127, 34);
            this.maskedTextBoxAFmodificacion.Mask = "00/00/0000";
            this.maskedTextBoxAFmodificacion.Name = "maskedTextBoxAFmodificacion";
            this.maskedTextBoxAFmodificacion.Size = new System.Drawing.Size(116, 20);
            this.maskedTextBoxAFmodificacion.TabIndex = 3;
            this.maskedTextBoxAFmodificacion.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Modificacion:";
            // 
            // labelANombre
            // 
            this.labelANombre.AutoSize = true;
            this.labelANombre.Location = new System.Drawing.Point(127, 18);
            this.labelANombre.Name = "labelANombre";
            this.labelANombre.Size = new System.Drawing.Size(16, 13);
            this.labelANombre.TabIndex = 1;
            this.labelANombre.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // groupBoxOcr
            // 
            this.groupBoxOcr.AutoSize = true;
            this.groupBoxOcr.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxOcr.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxOcr.Controls.Add(this.labelANlineas);
            this.groupBoxOcr.Controls.Add(this.labelANpalabras);
            this.groupBoxOcr.Controls.Add(this.labelANcaracteres);
            this.groupBoxOcr.Controls.Add(this.label10);
            this.groupBoxOcr.Controls.Add(this.label9);
            this.groupBoxOcr.Controls.Add(this.label8);
            this.groupBoxOcr.Controls.Add(this.label7);
            this.groupBoxOcr.Controls.Add(this.labelANpaginas);
            this.groupBoxOcr.Location = new System.Drawing.Point(3, 460);
            this.groupBoxOcr.Name = "groupBoxOcr";
            this.groupBoxOcr.Size = new System.Drawing.Size(246, 69);
            this.groupBoxOcr.TabIndex = 11;
            this.groupBoxOcr.TabStop = false;
            this.groupBoxOcr.Text = "Ocr";
            this.groupBoxOcr.Enter += new System.EventHandler(this.groupBoxOcr_Enter);
            // 
            // labelANlineas
            // 
            this.labelANlineas.AutoSize = true;
            this.labelANlineas.Location = new System.Drawing.Point(222, 40);
            this.labelANlineas.Name = "labelANlineas";
            this.labelANlineas.Size = new System.Drawing.Size(16, 13);
            this.labelANlineas.TabIndex = 16;
            this.labelANlineas.Text = "...";
            // 
            // labelANpalabras
            // 
            this.labelANpalabras.AutoSize = true;
            this.labelANpalabras.Location = new System.Drawing.Point(224, 17);
            this.labelANpalabras.Name = "labelANpalabras";
            this.labelANpalabras.Size = new System.Drawing.Size(16, 13);
            this.labelANpalabras.TabIndex = 15;
            this.labelANpalabras.Text = "...";
            this.labelANpalabras.Click += new System.EventHandler(this.labelANpalabras_Click);
            // 
            // labelANcaracteres
            // 
            this.labelANcaracteres.AutoSize = true;
            this.labelANcaracteres.Location = new System.Drawing.Point(105, 40);
            this.labelANcaracteres.Name = "labelANcaracteres";
            this.labelANcaracteres.Size = new System.Drawing.Size(16, 13);
            this.labelANcaracteres.TabIndex = 14;
            this.labelANcaracteres.Text = "...";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(138, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Nro de Lineas:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(130, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Nro de Palabras:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Nro de Caracteres:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Nro de Páginas:";
            // 
            // labelANpaginas
            // 
            this.labelANpaginas.AutoSize = true;
            this.labelANpaginas.Location = new System.Drawing.Point(105, 16);
            this.labelANpaginas.Name = "labelANpaginas";
            this.labelANpaginas.Size = new System.Drawing.Size(16, 13);
            this.labelANpaginas.TabIndex = 0;
            this.labelANpaginas.Text = "...";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.labelAVertical);
            this.groupBox1.Controls.Add(this.labelAHorizontal);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(262, 460);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(127, 71);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resolucion";
            // 
            // labelAVertical
            // 
            this.labelAVertical.AutoSize = true;
            this.labelAVertical.Location = new System.Drawing.Point(102, 42);
            this.labelAVertical.Name = "labelAVertical";
            this.labelAVertical.Size = new System.Drawing.Size(16, 13);
            this.labelAVertical.TabIndex = 13;
            this.labelAVertical.Text = "...";
            // 
            // labelAHorizontal
            // 
            this.labelAHorizontal.AutoSize = true;
            this.labelAHorizontal.Location = new System.Drawing.Point(105, 18);
            this.labelAHorizontal.Name = "labelAHorizontal";
            this.labelAHorizontal.Size = new System.Drawing.Size(16, 13);
            this.labelAHorizontal.TabIndex = 12;
            this.labelAHorizontal.Text = "...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Vertical:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Horizontal:";
            // 
            // groupBoxRutaOrigen
            // 
            this.groupBoxRutaOrigen.AutoSize = true;
            this.groupBoxRutaOrigen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxRutaOrigen.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxRutaOrigen.Controls.Add(this.textBoxRutaOrigen);
            this.groupBoxRutaOrigen.Location = new System.Drawing.Point(4, 2);
            this.groupBoxRutaOrigen.Name = "groupBoxRutaOrigen";
            this.groupBoxRutaOrigen.Size = new System.Drawing.Size(300, 52);
            this.groupBoxRutaOrigen.TabIndex = 2;
            this.groupBoxRutaOrigen.TabStop = false;
            this.groupBoxRutaOrigen.Text = "Ruta Origen";
            // 
            // textBoxRutaOrigen
            // 
            this.textBoxRutaOrigen.Location = new System.Drawing.Point(6, 13);
            this.textBoxRutaOrigen.Name = "textBoxRutaOrigen";
            this.textBoxRutaOrigen.Size = new System.Drawing.Size(288, 20);
            this.textBoxRutaOrigen.TabIndex = 1;
            // 
            // groupBoxestado
            // 
            this.groupBoxestado.AutoSize = true;
            this.groupBoxestado.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxestado.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxestado.Controls.Add(this.label13);
            this.groupBoxestado.Controls.Add(this.labelPIdproceso);
            this.groupBoxestado.Controls.Add(this.maskedTextBoxPFinProceso);
            this.groupBoxestado.Controls.Add(this.label12);
            this.groupBoxestado.Controls.Add(this.label11);
            this.groupBoxestado.Controls.Add(this.maskedTextBoxPInicioProceso);
            this.groupBoxestado.Location = new System.Drawing.Point(5, 318);
            this.groupBoxestado.Name = "groupBoxestado";
            this.groupBoxestado.Size = new System.Drawing.Size(246, 110);
            this.groupBoxestado.TabIndex = 3;
            this.groupBoxestado.TabStop = false;
            this.groupBoxestado.Text = "Estado Proceso";
            this.groupBoxestado.Enter += new System.EventHandler(this.groupBoxestado_Enter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Id del Proceso:";
            // 
            // labelPIdproceso
            // 
            this.labelPIdproceso.AutoSize = true;
            this.labelPIdproceso.Location = new System.Drawing.Point(123, 81);
            this.labelPIdproceso.Name = "labelPIdproceso";
            this.labelPIdproceso.Size = new System.Drawing.Size(16, 13);
            this.labelPIdproceso.TabIndex = 17;
            this.labelPIdproceso.Text = "...";
            // 
            // maskedTextBoxPFinProceso
            // 
            this.maskedTextBoxPFinProceso.Location = new System.Drawing.Point(124, 49);
            this.maskedTextBoxPFinProceso.Mask = "00/00/0000 00:00";
            this.maskedTextBoxPFinProceso.Name = "maskedTextBoxPFinProceso";
            this.maskedTextBoxPFinProceso.Size = new System.Drawing.Size(116, 20);
            this.maskedTextBoxPFinProceso.TabIndex = 15;
            this.maskedTextBoxPFinProceso.ValidatingType = typeof(System.DateTime);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Inicio Proceso:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Fin Proceso:";
            // 
            // maskedTextBoxPInicioProceso
            // 
            this.maskedTextBoxPInicioProceso.Location = new System.Drawing.Point(124, 24);
            this.maskedTextBoxPInicioProceso.Mask = "00/00/0000 00:00";
            this.maskedTextBoxPInicioProceso.Name = "maskedTextBoxPInicioProceso";
            this.maskedTextBoxPInicioProceso.Size = new System.Drawing.Size(116, 20);
            this.maskedTextBoxPInicioProceso.TabIndex = 13;
            this.maskedTextBoxPInicioProceso.ValidatingType = typeof(System.DateTime);
            // 
            // buttonProcesar
            // 
            this.buttonProcesar.Location = new System.Drawing.Point(414, 460);
            this.buttonProcesar.Name = "buttonProcesar";
            this.buttonProcesar.Size = new System.Drawing.Size(96, 35);
            this.buttonProcesar.TabIndex = 4;
            this.buttonProcesar.Text = "Procesar";
            this.buttonProcesar.UseVisualStyleBackColor = true;
            this.buttonProcesar.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // timerRevisaProcesados
            // 
            this.timerRevisaProcesados.Interval = 3000;
            this.timerRevisaProcesados.Tick += new System.EventHandler(this.timerRevisaProcesados_Tick);
            // 
            // listBoxProcesados
            // 
            this.listBoxProcesados.FormattingEnabled = true;
            this.listBoxProcesados.Location = new System.Drawing.Point(6, 16);
            this.listBoxProcesados.Name = "listBoxProcesados";
            this.listBoxProcesados.Size = new System.Drawing.Size(145, 82);
            this.listBoxProcesados.TabIndex = 5;
            this.listBoxProcesados.SelectedIndexChanged += new System.EventHandler(this.listBoxProcesados_SelectedIndexChanged);
            // 
            // buttonDetener
            // 
            this.buttonDetener.Location = new System.Drawing.Point(540, 460);
            this.buttonDetener.Name = "buttonDetener";
            this.buttonDetener.Size = new System.Drawing.Size(100, 35);
            this.buttonDetener.TabIndex = 6;
            this.buttonDetener.Text = "Detener";
            this.buttonDetener.UseVisualStyleBackColor = true;
            this.buttonDetener.Click += new System.EventHandler(this.buttonDetener_Click);
            // 
            // groupBoxRutasDestino
            // 
            this.groupBoxRutasDestino.AutoSize = true;
            this.groupBoxRutasDestino.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxRutasDestino.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxRutasDestino.Controls.Add(this.listBoxRutasDestino);
            this.groupBoxRutasDestino.Location = new System.Drawing.Point(4, 55);
            this.groupBoxRutasDestino.Name = "groupBoxRutasDestino";
            this.groupBoxRutasDestino.Size = new System.Drawing.Size(250, 62);
            this.groupBoxRutasDestino.TabIndex = 3;
            this.groupBoxRutasDestino.TabStop = false;
            this.groupBoxRutasDestino.Text = "Rutas Destino";
            // 
            // listBoxRutasDestino
            // 
            this.listBoxRutasDestino.FormattingEnabled = true;
            this.listBoxRutasDestino.Location = new System.Drawing.Point(6, 13);
            this.listBoxRutasDestino.Name = "listBoxRutasDestino";
            this.listBoxRutasDestino.Size = new System.Drawing.Size(238, 30);
            this.listBoxRutasDestino.TabIndex = 0;
            // 
            // listBoxFormatosExportacion
            // 
            this.listBoxFormatosExportacion.FormattingEnabled = true;
            this.listBoxFormatosExportacion.Location = new System.Drawing.Point(6, 18);
            this.listBoxFormatosExportacion.Name = "listBoxFormatosExportacion";
            this.listBoxFormatosExportacion.Size = new System.Drawing.Size(352, 43);
            this.listBoxFormatosExportacion.TabIndex = 0;
            // 
            // groupBoxFomatosExportacion
            // 
            this.groupBoxFomatosExportacion.AutoSize = true;
            this.groupBoxFomatosExportacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxFomatosExportacion.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxFomatosExportacion.Controls.Add(this.listBoxFormatosExportacion);
            this.groupBoxFomatosExportacion.Location = new System.Drawing.Point(267, 61);
            this.groupBoxFomatosExportacion.Name = "groupBoxFomatosExportacion";
            this.groupBoxFomatosExportacion.Size = new System.Drawing.Size(364, 80);
            this.groupBoxFomatosExportacion.TabIndex = 4;
            this.groupBoxFomatosExportacion.TabStop = false;
            this.groupBoxFomatosExportacion.Text = "Formatos Exportación";
            // 
            // groupBoxInformacionGlobal
            // 
            this.groupBoxInformacionGlobal.AutoSize = true;
            this.groupBoxInformacionGlobal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxInformacionGlobal.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxInformacionGlobal.Controls.Add(this.groupBox6);
            this.groupBoxInformacionGlobal.Controls.Add(this.groupBox5);
            this.groupBoxInformacionGlobal.Controls.Add(this.groupBox4);
            this.groupBoxInformacionGlobal.Location = new System.Drawing.Point(262, 270);
            this.groupBoxInformacionGlobal.Name = "groupBoxInformacionGlobal";
            this.groupBoxInformacionGlobal.Size = new System.Drawing.Size(384, 158);
            this.groupBoxInformacionGlobal.TabIndex = 7;
            this.groupBoxInformacionGlobal.TabStop = false;
            this.groupBoxInformacionGlobal.Text = "Informacion Global Procesamiento";
            // 
            // groupBox6
            // 
            this.groupBox6.AutoSize = true;
            this.groupBox6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox6.Controls.Add(this.labelsegundos);
            this.groupBox6.Controls.Add(this.labelminutos);
            this.groupBox6.Controls.Add(this.labelhoras);
            this.groupBox6.Controls.Add(this.labeldias);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Location = new System.Drawing.Point(286, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(92, 120);
            this.groupBox6.TabIndex = 42;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Tiempo";
            // 
            // labelsegundos
            // 
            this.labelsegundos.AutoSize = true;
            this.labelsegundos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelsegundos.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelsegundos.Location = new System.Drawing.Point(69, 86);
            this.labelsegundos.Name = "labelsegundos";
            this.labelsegundos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelsegundos.Size = new System.Drawing.Size(17, 18);
            this.labelsegundos.TabIndex = 15;
            this.labelsegundos.Text = "0";
            // 
            // labelminutos
            // 
            this.labelminutos.AutoSize = true;
            this.labelminutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelminutos.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelminutos.Location = new System.Drawing.Point(69, 65);
            this.labelminutos.Name = "labelminutos";
            this.labelminutos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelminutos.Size = new System.Drawing.Size(17, 18);
            this.labelminutos.TabIndex = 14;
            this.labelminutos.Text = "0";
            // 
            // labelhoras
            // 
            this.labelhoras.AutoSize = true;
            this.labelhoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelhoras.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelhoras.Location = new System.Drawing.Point(69, 44);
            this.labelhoras.Name = "labelhoras";
            this.labelhoras.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelhoras.Size = new System.Drawing.Size(17, 18);
            this.labelhoras.TabIndex = 13;
            this.labelhoras.Text = "0";
            // 
            // labeldias
            // 
            this.labeldias.AutoSize = true;
            this.labeldias.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldias.ForeColor = System.Drawing.Color.DarkOrange;
            this.labeldias.Location = new System.Drawing.Point(69, 23);
            this.labeldias.Name = "labeldias";
            this.labeldias.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labeldias.Size = new System.Drawing.Size(17, 18);
            this.labeldias.TabIndex = 12;
            this.labeldias.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Segundos:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 70);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Minutos:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Horas:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 13);
            this.label17.TabIndex = 8;
            this.label17.Text = "Dias:";
            // 
            // groupBox5
            // 
            this.groupBox5.AutoSize = true;
            this.groupBox5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox5.Controls.Add(this.labelpornoprocesados);
            this.groupBox5.Controls.Add(this.labelporprocesados);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Location = new System.Drawing.Point(143, 28);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(125, 106);
            this.groupBox5.TabIndex = 41;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Porcentajes";
            // 
            // labelpornoprocesados
            // 
            this.labelpornoprocesados.AutoSize = true;
            this.labelpornoprocesados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelpornoprocesados.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelpornoprocesados.Location = new System.Drawing.Point(85, 70);
            this.labelpornoprocesados.Name = "labelpornoprocesados";
            this.labelpornoprocesados.Size = new System.Drawing.Size(34, 20);
            this.labelpornoprocesados.TabIndex = 6;
            this.labelpornoprocesados.Text = "0%";
            // 
            // labelporprocesados
            // 
            this.labelporprocesados.AutoSize = true;
            this.labelporprocesados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelporprocesados.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelporprocesados.Location = new System.Drawing.Point(85, 34);
            this.labelporprocesados.Name = "labelporprocesados";
            this.labelporprocesados.Size = new System.Drawing.Size(34, 20);
            this.labelporprocesados.TabIndex = 5;
            this.labelporprocesados.Text = "0%";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 75);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 13);
            this.label18.TabIndex = 3;
            this.label18.Text = "No Procesados:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 39);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "Procesados:";
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox4.Controls.Add(this.labelnnoprocesados);
            this.groupBox4.Controls.Add(this.labelnprocesados);
            this.groupBox4.Controls.Add(this.labelnpaginas);
            this.groupBox4.Controls.Add(this.labelnrarchivos);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Location = new System.Drawing.Point(14, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(110, 120);
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Resultados";
            // 
            // labelnnoprocesados
            // 
            this.labelnnoprocesados.AutoSize = true;
            this.labelnnoprocesados.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnnoprocesados.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelnnoprocesados.Location = new System.Drawing.Point(87, 86);
            this.labelnnoprocesados.Name = "labelnnoprocesados";
            this.labelnnoprocesados.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelnnoprocesados.Size = new System.Drawing.Size(17, 18);
            this.labelnnoprocesados.TabIndex = 7;
            this.labelnnoprocesados.Text = "0";
            // 
            // labelnprocesados
            // 
            this.labelnprocesados.AutoSize = true;
            this.labelnprocesados.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnprocesados.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelnprocesados.Location = new System.Drawing.Point(87, 65);
            this.labelnprocesados.Name = "labelnprocesados";
            this.labelnprocesados.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelnprocesados.Size = new System.Drawing.Size(17, 18);
            this.labelnprocesados.TabIndex = 6;
            this.labelnprocesados.Text = "0";
            // 
            // labelnpaginas
            // 
            this.labelnpaginas.AutoSize = true;
            this.labelnpaginas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnpaginas.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelnpaginas.Location = new System.Drawing.Point(87, 44);
            this.labelnpaginas.Name = "labelnpaginas";
            this.labelnpaginas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelnpaginas.Size = new System.Drawing.Size(17, 18);
            this.labelnpaginas.TabIndex = 5;
            this.labelnpaginas.Text = "0";
            // 
            // labelnrarchivos
            // 
            this.labelnrarchivos.AutoSize = true;
            this.labelnrarchivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnrarchivos.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelnrarchivos.Location = new System.Drawing.Point(87, 23);
            this.labelnrarchivos.Name = "labelnrarchivos";
            this.labelnrarchivos.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelnrarchivos.Size = new System.Drawing.Size(17, 18);
            this.labelnrarchivos.TabIndex = 4;
            this.labelnrarchivos.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 90);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(83, 13);
            this.label20.TabIndex = 3;
            this.label20.Text = "No Procesados:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 69);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(66, 13);
            this.label21.TabIndex = 2;
            this.label21.Text = "Procesados:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 48);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 13);
            this.label22.TabIndex = 1;
            this.label22.Text = "Paginas:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 27);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(51, 13);
            this.label23.TabIndex = 0;
            this.label23.Text = "Archivos:";
            // 
            // groupBoxArhcivosProcesados
            // 
            this.groupBoxArhcivosProcesados.AutoSize = true;
            this.groupBoxArhcivosProcesados.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxArhcivosProcesados.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxArhcivosProcesados.Controls.Add(this.listBoxProcesados);
            this.groupBoxArhcivosProcesados.Location = new System.Drawing.Point(296, 147);
            this.groupBoxArhcivosProcesados.Name = "groupBoxArhcivosProcesados";
            this.groupBoxArhcivosProcesados.Size = new System.Drawing.Size(157, 117);
            this.groupBoxArhcivosProcesados.TabIndex = 8;
            this.groupBoxArhcivosProcesados.TabStop = false;
            this.groupBoxArhcivosProcesados.Text = "Archivos Procesados";
            this.groupBoxArhcivosProcesados.Enter += new System.EventHandler(this.groupBoxArhcivosProcesados_Enter);
            // 
            // timerCargarBase
            // 
            this.timerCargarBase.Enabled = true;
            this.timerCargarBase.Interval = 1000;
            this.timerCargarBase.Tick += new System.EventHandler(this.timerCargarBase_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.buttonGuardar);
            this.groupBox3.Controls.Add(this.checkBoxMoverDoc);
            this.groupBox3.Controls.Add(this.checkBoxDeskew);
            this.groupBox3.Controls.Add(this.checkBoxAutoArranque);
            this.groupBox3.Location = new System.Drawing.Point(4, 119);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 74);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parámetros";
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(158, 19);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 56;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // checkBoxMoverDoc
            // 
            this.checkBoxMoverDoc.AutoSize = true;
            this.checkBoxMoverDoc.Location = new System.Drawing.Point(7, 52);
            this.checkBoxMoverDoc.Name = "checkBoxMoverDoc";
            this.checkBoxMoverDoc.Size = new System.Drawing.Size(119, 17);
            this.checkBoxMoverDoc.TabIndex = 55;
            this.checkBoxMoverDoc.Text = "Mover Documentos";
            this.checkBoxMoverDoc.UseVisualStyleBackColor = true;
            // 
            // checkBoxDeskew
            // 
            this.checkBoxDeskew.AutoSize = true;
            this.checkBoxDeskew.Location = new System.Drawing.Point(7, 36);
            this.checkBoxDeskew.Name = "checkBoxDeskew";
            this.checkBoxDeskew.Size = new System.Drawing.Size(102, 17);
            this.checkBoxDeskew.TabIndex = 54;
            this.checkBoxDeskew.Text = "Enderezamiento";
            this.checkBoxDeskew.UseVisualStyleBackColor = true;
            this.checkBoxDeskew.CheckedChanged += new System.EventHandler(this.checkBoxDeskew_CheckedChanged);
            // 
            // checkBoxAutoArranque
            // 
            this.checkBoxAutoArranque.AutoSize = true;
            this.checkBoxAutoArranque.Location = new System.Drawing.Point(8, 19);
            this.checkBoxAutoArranque.Name = "checkBoxAutoArranque";
            this.checkBoxAutoArranque.Size = new System.Drawing.Size(94, 17);
            this.checkBoxAutoArranque.TabIndex = 53;
            this.checkBoxAutoArranque.Text = "Auto Arranque";
            this.checkBoxAutoArranque.UseVisualStyleBackColor = true;
            this.checkBoxAutoArranque.CheckedChanged += new System.EventHandler(this.checkBoxAutoArranque_CheckedChanged);
            // 
            // listBoxNoProcesados
            // 
            this.listBoxNoProcesados.FormattingEnabled = true;
            this.listBoxNoProcesados.Location = new System.Drawing.Point(6, 16);
            this.listBoxNoProcesados.Name = "listBoxNoProcesados";
            this.listBoxNoProcesados.Size = new System.Drawing.Size(148, 82);
            this.listBoxNoProcesados.TabIndex = 5;
            // 
            // groupBox7
            // 
            this.groupBox7.AutoSize = true;
            this.groupBox7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox7.BackColor = System.Drawing.Color.Transparent;
            this.groupBox7.Controls.Add(this.listBoxNoProcesados);
            this.groupBox7.Location = new System.Drawing.Point(459, 147);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(160, 117);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Archivos No Procesados";
            // 
            // timerAutoArranque
            // 
            this.timerAutoArranque.Interval = 2000;
            this.timerAutoArranque.Tick += new System.EventHandler(this.timerAutoArranque_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.textBoxRutaProceso);
            this.groupBox2.Location = new System.Drawing.Point(310, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 53);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ruta Proceso";
            // 
            // textBoxRutaProceso
            // 
            this.textBoxRutaProceso.Location = new System.Drawing.Point(6, 14);
            this.textBoxRutaProceso.Name = "textBoxRutaProceso";
            this.textBoxRutaProceso.Size = new System.Drawing.Size(311, 20);
            this.textBoxRutaProceso.TabIndex = 0;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(653, 534);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBoxOcr);
            this.Controls.Add(this.groupBoxInformacionGlobal);
            this.Controls.Add(this.groupBoxFomatosExportacion);
            this.Controls.Add(this.groupBoxRutasDestino);
            this.Controls.Add(this.buttonDetener);
            this.Controls.Add(this.buttonProcesar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxestado);
            this.Controls.Add(this.groupBoxRutaOrigen);
            this.Controls.Add(this.groupBoxArchivo);
            this.Controls.Add(this.progressBarProcesados);
            this.Controls.Add(this.groupBoxArhcivosProcesados);
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Principal Procesamiento OCR";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileQuipuxWatcher)).EndInit();
            this.groupBoxArchivo.ResumeLayout(false);
            this.groupBoxArchivo.PerformLayout();
            this.groupBoxOcr.ResumeLayout(false);
            this.groupBoxOcr.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxRutaOrigen.ResumeLayout(false);
            this.groupBoxRutaOrigen.PerformLayout();
            this.groupBoxestado.ResumeLayout(false);
            this.groupBoxestado.PerformLayout();
            this.groupBoxRutasDestino.ResumeLayout(false);
            this.groupBoxFomatosExportacion.ResumeLayout(false);
            this.groupBoxInformacionGlobal.ResumeLayout(false);
            this.groupBoxInformacionGlobal.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBoxArhcivosProcesados.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.FileSystemWatcher fileQuipuxWatcher;
        private System.Windows.Forms.ProgressBar progressBarProcesados;
        private System.Windows.Forms.GroupBox groupBoxestado;
        private System.Windows.Forms.GroupBox groupBoxRutaOrigen;
        private System.Windows.Forms.GroupBox groupBoxArchivo;
        private System.Windows.Forms.Button buttonProcesar;
        private System.Windows.Forms.Timer timerRevisaProcesados;
        private System.Windows.Forms.ListBox listBoxProcesados;
        private System.Windows.Forms.Button buttonDetener;
        private System.Windows.Forms.GroupBox groupBoxRutasDestino;
        private System.Windows.Forms.ListBox listBoxRutasDestino;
        private System.Windows.Forms.GroupBox groupBoxInformacionGlobal;
        private System.Windows.Forms.GroupBox groupBoxFomatosExportacion;
        private System.Windows.Forms.ListBox listBoxFormatosExportacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelAProfundidadBits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxAFCreacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxAFmodificacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelANombre;
        private System.Windows.Forms.GroupBox groupBoxOcr;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelANpaginas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelANlineas;
        private System.Windows.Forms.Label labelANpalabras;
        private System.Windows.Forms.Label labelANcaracteres;
        private System.Windows.Forms.Label labelAVertical;
        private System.Windows.Forms.Label labelAHorizontal;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPFinProceso;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPInicioProceso;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labelPIdproceso;
        private System.Windows.Forms.GroupBox groupBoxArhcivosProcesados;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label labelsegundos;
        private System.Windows.Forms.Label labelminutos;
        private System.Windows.Forms.Label labelhoras;
        private System.Windows.Forms.Label labeldias;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label labelpornoprocesados;
        private System.Windows.Forms.Label labelporprocesados;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelnnoprocesados;
        private System.Windows.Forms.Label labelnprocesados;
        private System.Windows.Forms.Label labelnpaginas;
        private System.Windows.Forms.Label labelnrarchivos;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBoxRutaOrigen;
        private System.Windows.Forms.Timer timerCargarBase;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxAutoArranque;
        private System.Windows.Forms.CheckBox checkBoxMoverDoc;
        private System.Windows.Forms.CheckBox checkBoxDeskew;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ListBox listBoxNoProcesados;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Timer timerAutoArranque;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxRutaProceso;
    }
}