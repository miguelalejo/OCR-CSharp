namespace OCR.Facultad.Ingenieria.Batch
{
    partial class FormProcesamiento
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProcesamiento));
            this.openFileDialogArchivo = new System.Windows.Forms.OpenFileDialog();
            this.progressBarOcr = new System.Windows.Forms.ProgressBar();
            this.statusBarOcr = new System.Windows.Forms.StatusBar();
            this.labelIdProceso = new System.Windows.Forms.Label();
         
         
            this.timerEstadisticas = new System.Windows.Forms.Timer(this.components);
           
            this.SuspendLayout();
            // 
            // openFileDialogArchivo
            // 
            this.openFileDialogArchivo.FileName = "openFileDialogArchivo";
            // 
            // progressBarOcr
            // 
            resources.ApplyResources(this.progressBarOcr, "progressBarOcr");
            this.progressBarOcr.Name = "progressBarOcr";
            // 
            // statusBarOcr
            // 
            resources.ApplyResources(this.statusBarOcr, "statusBarOcr");
            this.statusBarOcr.Name = "statusBarOcr";
            this.statusBarOcr.PanelClick += new System.Windows.Forms.StatusBarPanelClickEventHandler(this.statusBarOcr_PanelClick);
            // 
            // labelIdProceso
            // 
            resources.ApplyResources(this.labelIdProceso, "labelIdProceso");
            this.labelIdProceso.Name = "labelIdProceso";
            // 
            // timerEstadisticas
            // 
            this.timerEstadisticas.Enabled = true;
            this.timerEstadisticas.Interval = 10000;
            this.timerEstadisticas.Tick += new System.EventHandler(this.timerEstadisticas_Tick);
            // 
            // FormProcesamiento
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelIdProceso);
            this.Controls.Add(this.statusBarOcr);
            this.Controls.Add(this.progressBarOcr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FormProcesamiento";
            this.Load += new System.EventHandler(this.FormProcesamiento_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormProcesamiento_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogArchivo;
        private System.Windows.Forms.ProgressBar progressBarOcr;
        private System.Windows.Forms.StatusBar statusBarOcr;
        private System.Windows.Forms.Label labelIdProceso;

        private System.Windows.Forms.Timer timerEstadisticas;
    }
}

