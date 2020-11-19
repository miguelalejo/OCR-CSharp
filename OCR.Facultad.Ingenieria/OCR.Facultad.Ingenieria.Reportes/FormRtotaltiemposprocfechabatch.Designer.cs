namespace OCR.Facultad.Ingenieria.Reportes
{
    partial class FormRtotaltiemposprocfechabatch
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rtotaltiemposprocfechabatchDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.rtotaltiemposprocfechabatchDataTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rtotaltiemposprocfechabatchDataTableBindingSource
            // 
            this.rtotaltiemposprocfechabatchDataTableBindingSource.DataSource = typeof(OCR.Facultad.Ingenieria.ManagerBases.DataSetRtotaltiemposPFB.rtotaltiemposprocfechabatchDataTable);
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "OCR_Facultad_Ingenieria_ManagerBases_rtotaltiemposprocfechabatchDataTable";
            reportDataSource1.Value = this.rtotaltiemposprocfechabatchDataTableBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "OCR.Facultad.Ingenieria.Reportes.Rtotaltiemposprocfechabatch.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(1033, 588);
            this.reportViewer.TabIndex = 0;
            // 
            // FormRtotaltiemposprocfechabatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 588);
            this.Controls.Add(this.reportViewer);
            this.Name = "FormRtotaltiemposprocfechabatch";
            this.Text = "FormRtotaltiemposprocfechabatch";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormRtotaltiemposprocfechabatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rtotaltiemposprocfechabatchDataTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource rtotaltiemposprocfechabatchDataTableBindingSource;
    }
}