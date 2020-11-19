namespace OCR.Facultad.Ingenieria.Aplicacion
{
    partial class FormProgresBar
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.backgroundWorkerDoc = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerCom = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerComBorrar = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerUpdate = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerResFicheros = new System.ComponentModel.BackgroundWorker();
            this.labelRutas = new System.Windows.Forms.Label();
            this.backgroundWorkerFicheroRango = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerFicheroAccion = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerNoProcesado = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.progressBar.Enabled = false;
            this.progressBar.Location = new System.Drawing.Point(12, 25);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(444, 23);
            this.progressBar.TabIndex = 0;
            this.progressBar.UseWaitCursor = true;
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 65);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(468, 22);
            this.statusBar.TabIndex = 30;
            this.statusBar.UseWaitCursor = true;
            this.statusBar.PanelClick += new System.Windows.Forms.StatusBarPanelClickEventHandler(this.statusBar_PanelClick);
            // 
            // backgroundWorkerDoc
            // 
            this.backgroundWorkerDoc.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDoc_DoWork);
            this.backgroundWorkerDoc.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDoc_RunWorkerCompleted);
            this.backgroundWorkerDoc.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerDoc_ProgressChanged);
            // 
            // backgroundWorkerCom
            // 
            this.backgroundWorkerCom.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCom_DoWork);
            this.backgroundWorkerCom.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCom_RunWorkerCompleted);
            this.backgroundWorkerCom.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerCom_ProgressChanged);
            // 
            // backgroundWorkerComBorrar
            // 
            this.backgroundWorkerComBorrar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerComBorrar_DoWork);
            this.backgroundWorkerComBorrar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerComBorrar_RunWorkerCompleted);
            this.backgroundWorkerComBorrar.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerComBorrar_ProgressChanged);
            // 
            // backgroundWorkerUpdate
            // 
            this.backgroundWorkerUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUpdate_DoWork);
            this.backgroundWorkerUpdate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerUpdate_RunWorkerCompleted);
            this.backgroundWorkerUpdate.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerUpdate_ProgressChanged);
            // 
            // backgroundWorkerResFicheros
            // 
            this.backgroundWorkerResFicheros.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerResFicheros_DoWork);
            this.backgroundWorkerResFicheros.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerResFicheros_RunWorkerCompleted);
            this.backgroundWorkerResFicheros.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerResFicheros_ProgressChanged);
            // 
            // labelRutas
            // 
            this.labelRutas.AutoSize = true;
            this.labelRutas.Location = new System.Drawing.Point(12, 4);
            this.labelRutas.Name = "labelRutas";
            this.labelRutas.Size = new System.Drawing.Size(0, 13);
            this.labelRutas.TabIndex = 31;
            this.labelRutas.UseWaitCursor = true;
            // 
            // backgroundWorkerFicheroRango
            // 
            this.backgroundWorkerFicheroRango.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFicheroRango_DoWork);
            this.backgroundWorkerFicheroRango.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFicheroRango_RunWorkerCompleted);
            this.backgroundWorkerFicheroRango.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerFicheroRango_ProgressChanged);
            // 
            // backgroundWorkerFicheroAccion
            // 
            this.backgroundWorkerFicheroAccion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFicheroAccion_DoWork);
            this.backgroundWorkerFicheroAccion.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFicheroAccion_RunWorkerCompleted);
            this.backgroundWorkerFicheroAccion.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerFicheroAccion_ProgressChanged);
            // 
            // backgroundWorkerNoProcesado
            // 
            this.backgroundWorkerNoProcesado.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerNoProcesado_DoWork);
            this.backgroundWorkerNoProcesado.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerNoProcesado_RunWorkerCompleted);
            this.backgroundWorkerNoProcesado.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerNoProcesado_ProgressChanged);
            // 
            // FormProgresBar
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(468, 87);
            this.ControlBox = false;
            this.Controls.Add(this.labelRutas);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.progressBar);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "FormProgresBar";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargando...";
            this.TopMost = true;
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.FormProgresBar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.StatusBar statusBar;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDoc;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCom;
        private System.ComponentModel.BackgroundWorker backgroundWorkerComBorrar;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUpdate;
        private System.ComponentModel.BackgroundWorker backgroundWorkerResFicheros;
        private System.Windows.Forms.Label labelRutas;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFicheroRango;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFicheroAccion;
        private System.ComponentModel.BackgroundWorker backgroundWorkerNoProcesado;
    }
}