namespace OCR.Facultad.Ingenieria.Reportes
{
    partial class FormRtotalpagcarlinfechprobatch
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
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rtotalpagcarlinfechprobatchDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.rtotalpagcarlinfechprobatchDataTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "OCR_Facultad_Ingenieria_ManagerBases_rtotalpagcarlinfechprobatchDataTable";
            reportDataSource1.Value = this.rtotalpagcarlinfechprobatchDataTableBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "OCR.Facultad.Ingenieria.Reportes.Rtotalpagcarlinfechprobatch.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(1063, 613);
            this.reportViewer.TabIndex = 0;
            // 
            // rtotalpagcarlinfechprobatchDataTableBindingSource
            // 
            this.rtotalpagcarlinfechprobatchDataTableBindingSource.DataSource = typeof(OCR.Facultad.Ingenieria.ManagerBases.DataSetRtotalpagcarlinFPB.rtotalpagcarlinfechprobatchDataTable);
            // 
            // FormRtotalpagcarlinfechprobatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 613);
            this.Controls.Add(this.reportViewer);
            this.Name = "FormRtotalpagcarlinfechprobatch";
            this.Text = "FormRtotalpagcarlinfechprobatch";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormRtotalpagcarlinfechprobatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rtotalpagcarlinfechprobatchDataTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource rtotalpagcarlinfechprobatchDataTableBindingSource;
    }
}