namespace OCR.Facultad.Ingenieria.Aplicacion
{
    partial class FormMenuPrincipal
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
            this.groupBoxContenedor = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.elementHostMenuWPF = new System.Windows.Forms.Integration.ElementHost();
            this.menuBotonWPF = new TabControlStyle.MenuBotonWPF();
            this.elementHostTabPage = new System.Windows.Forms.Integration.ElementHost();
            this.tabPapeWPF = new TabControlStyle.TabPapeWPF();
            this.elementHostReportes = new System.Windows.Forms.Integration.ElementHost();
            this.reportesWPF = new TabControlStyle.ReportesWPF();
            this.elementHostAyuda = new System.Windows.Forms.Integration.ElementHost();
            this.ayudaWPF = new TabControlStyle.AyudaWPF();
            this.groupBoxContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxContenedor
            // 
            this.groupBoxContenedor.Controls.Add(this.elementHostTabPage);
            this.groupBoxContenedor.Controls.Add(this.elementHostReportes);
            this.groupBoxContenedor.Controls.Add(this.elementHostAyuda);
            this.groupBoxContenedor.Location = new System.Drawing.Point(12, 148);
            this.groupBoxContenedor.Name = "groupBoxContenedor";
            this.groupBoxContenedor.Size = new System.Drawing.Size(646, 512);
            this.groupBoxContenedor.TabIndex = 2;
            this.groupBoxContenedor.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OCR.Facultad.Ingenieria.Aplicacion.Properties.Resources.uce_logo;
            this.pictureBox1.Location = new System.Drawing.Point(29, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(154, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // elementHostMenuWPF
            // 
            this.elementHostMenuWPF.Location = new System.Drawing.Point(202, 1);
            this.elementHostMenuWPF.Name = "elementHostMenuWPF";
            this.elementHostMenuWPF.Size = new System.Drawing.Size(456, 151);
            this.elementHostMenuWPF.TabIndex = 1;
            this.elementHostMenuWPF.Text = "elementHost1";
            this.elementHostMenuWPF.Child = this.menuBotonWPF;
            // 
            // elementHostTabPage
            // 
            this.elementHostTabPage.Location = new System.Drawing.Point(15, 28);
            this.elementHostTabPage.Name = "elementHostTabPage";
            this.elementHostTabPage.Size = new System.Drawing.Size(631, 470);
            this.elementHostTabPage.TabIndex = 0;
            this.elementHostTabPage.Text = "elementHostTabPage";
            this.elementHostTabPage.Child = this.tabPapeWPF;
            // 
            // elementHostReportes
            // 
            this.elementHostReportes.Location = new System.Drawing.Point(15, 9);
            this.elementHostReportes.Name = "elementHostReportes";
            this.elementHostReportes.Size = new System.Drawing.Size(631, 489);
            this.elementHostReportes.TabIndex = 1;
            this.elementHostReportes.Text = "elementHost1";
            this.elementHostReportes.Visible = false;
            this.elementHostReportes.Child = this.reportesWPF;
            // 
            // elementHostAyuda
            // 
            this.elementHostAyuda.Location = new System.Drawing.Point(15, 9);
            this.elementHostAyuda.Name = "elementHostAyuda";
            this.elementHostAyuda.Size = new System.Drawing.Size(625, 489);
            this.elementHostAyuda.TabIndex = 2;
            this.elementHostAyuda.Text = "elementHostAyuda";
            this.elementHostAyuda.Visible = false;
            this.elementHostAyuda.Child = this.ayudaWPF;
            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(670, 662);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.elementHostMenuWPF);
            this.Controls.Add(this.groupBoxContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Menú Principal";
            this.Load += new System.EventHandler(this.FormMenuPrincipal_Load);
            this.groupBoxContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHostTabPage;
        private System.Windows.Forms.Integration.ElementHost elementHostMenuWPF;
        private TabControlStyle.MenuBotonWPF menuBotonWPF;
        private TabControlStyle.TabPapeWPF tabPapeWPF;
        private System.Windows.Forms.GroupBox groupBoxContenedor;
        private System.Windows.Forms.Integration.ElementHost elementHostReportes;
        private TabControlStyle.ReportesWPF reportesWPF;
        private System.Windows.Forms.Integration.ElementHost elementHostAyuda;
        private TabControlStyle.AyudaWPF ayudaWPF;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}