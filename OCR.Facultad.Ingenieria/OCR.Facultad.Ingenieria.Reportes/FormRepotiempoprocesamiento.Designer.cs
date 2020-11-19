namespace OCR.Facultad.Ingenieria.Reportes
{
    partial class FormRepotiempoprocesamiento
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.repotiempoprocesamientoDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.repotiempoprocesamientoDataTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // repotiempoprocesamientoDataTableBindingSource
            // 
            this.repotiempoprocesamientoDataTableBindingSource.DataSource = typeof(OCR.Facultad.Ingenieria.ManagerBases.DataSetRepotiempoprocesamiento.repotiempoprocesamientoDataTable);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "OCR_Facultad_Ingenieria_ManagerBases_repotiempoprocesamientoDataTable";
            reportDataSource2.Value = this.repotiempoprocesamientoDataTableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "OCR.Facultad.Ingenieria.Reportes.Repotiempoprocesamiento.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1053, 586);
            this.reportViewer1.TabIndex = 0;
            // 
            // FormRepotiempoprocesamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 586);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormRepotiempoprocesamiento";
            this.Text = "Gráfica";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormRepotiempoprocesamiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repotiempoprocesamientoDataTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource repotiempoprocesamientoDataTableBindingSource;
    }
}