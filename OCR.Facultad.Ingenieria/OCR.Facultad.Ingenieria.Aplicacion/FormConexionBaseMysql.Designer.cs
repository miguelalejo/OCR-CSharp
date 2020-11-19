namespace OCR.Facultad.Ingenieria.Aplicacion
{
    partial class FormConexionBaseMysql
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
            this.numericUpDownPuerto = new System.Windows.Forms.NumericUpDown();
            this.buttonTest = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxBaseDatos = new System.Windows.Forms.ComboBox();
            this.textBoxContrasenia = new System.Windows.Forms.TextBox();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonTransmitir = new System.Windows.Forms.ToolStripButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.textBoxIp = new OCR.Facultad.Ingenieria.Aplicacion.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPuerto)).BeginInit();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownPuerto
            // 
            this.numericUpDownPuerto.Location = new System.Drawing.Point(150, 85);
            this.numericUpDownPuerto.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDownPuerto.Name = "numericUpDownPuerto";
            this.numericUpDownPuerto.Size = new System.Drawing.Size(137, 20);
            this.numericUpDownPuerto.TabIndex = 22;
            this.numericUpDownPuerto.Value = new decimal(new int[] {
            3306,
            0,
            0,
            0});
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(38, 256);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(261, 43);
            this.buttonTest.TabIndex = 21;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Base de Datos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Puerto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "IpServer";
            // 
            // comboBoxBaseDatos
            // 
            this.comboBoxBaseDatos.FormattingEnabled = true;
            this.comboBoxBaseDatos.Location = new System.Drawing.Point(150, 211);
            this.comboBoxBaseDatos.Name = "comboBoxBaseDatos";
            this.comboBoxBaseDatos.Size = new System.Drawing.Size(137, 21);
            this.comboBoxBaseDatos.TabIndex = 15;
            this.comboBoxBaseDatos.Text = "Seleccione:";
            this.comboBoxBaseDatos.SelectedIndexChanged += new System.EventHandler(this.comboBoxBaseDatos_SelectedIndexChanged);
            this.comboBoxBaseDatos.DropDown += new System.EventHandler(this.comboBoxBaseDatos_DropDown);
            // 
            // textBoxContrasenia
            // 
            this.textBoxContrasenia.Location = new System.Drawing.Point(150, 168);
            this.textBoxContrasenia.Name = "textBoxContrasenia";
            this.textBoxContrasenia.PasswordChar = '*';
            this.textBoxContrasenia.Size = new System.Drawing.Size(137, 20);
            this.textBoxContrasenia.TabIndex = 14;
            this.textBoxContrasenia.Text = "silvanabs17200";
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Location = new System.Drawing.Point(150, 125);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(137, 20);
            this.textBoxUsuario.TabIndex = 13;
            this.textBoxUsuario.Text = "root";
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonTransmitir});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(318, 25);
            this.toolStripMenu.TabIndex = 23;
            this.toolStripMenu.Text = "Menu Principal";
            // 
            // toolStripButtonTransmitir
            // 
            this.toolStripButtonTransmitir.Image = global::OCR.Facultad.Ingenieria.Aplicacion.Properties.Resources.onebit_guardar;
            this.toolStripButtonTransmitir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTransmitir.Name = "toolStripButtonTransmitir";
            this.toolStripButtonTransmitir.Size = new System.Drawing.Size(69, 22);
            this.toolStripButtonTransmitir.Text = "Guardar";
            this.toolStripButtonTransmitir.Click += new System.EventHandler(this.toolStripButtonTransmitir_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // textBoxIp
            // 
            this.textBoxIp.Location = new System.Drawing.Point(150, 44);
            this.textBoxIp.Masked = OCR.Facultad.Ingenieria.Aplicacion.Mask.IpAddress;
            this.textBoxIp.Name = "textBoxIp";
            this.textBoxIp.Size = new System.Drawing.Size(137, 20);
            this.textBoxIp.TabIndex = 24;
            // 
            // FormConexionBaseMysql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 313);
            this.Controls.Add(this.textBoxIp);
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.numericUpDownPuerto);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxBaseDatos);
            this.Controls.Add(this.textBoxContrasenia);
            this.Controls.Add(this.textBoxUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormConexionBaseMysql";
            this.Text = "Conexión MySQL";
            this.Load += new System.EventHandler(this.FormConexionBaseMysql_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPuerto)).EndInit();
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownPuerto;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxBaseDatos;
        private System.Windows.Forms.TextBox textBoxContrasenia;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton toolStripButtonTransmitir;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private MaskedTextBox textBoxIp;
    }
}