namespace OCR.Facultad.Ingenieria.Reportes
{
    partial class FormTablarutasactivas
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
            this.tablarutasactivasDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.tablarutasactivasDataTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tablarutasactivasDataTableBindingSource
            // 
            this.tablarutasactivasDataTableBindingSource.DataSource = typeof(OCR.Facultad.Ingenieria.ManagerBases.DataSetTablarutasactivas.tablarutasactivasDataTable);
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "OCR_Facultad_Ingenieria_ManagerBases_tablarutasactivasDataTable";
            reportDataSource1.Value = this.tablarutasactivasDataTableBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "OCR.Facultad.Ingenieria.Reportes.Tablarutasactivas.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(948, 666);
            this.reportViewer.TabIndex = 0;
            // 
            // FormTablarutasactivas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 666);
            this.Controls.Add(this.reportViewer);
            this.Name = "FormTablarutasactivas";
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.FormTablarutasactivas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablarutasactivasDataTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource tablarutasactivasDataTableBindingSource;
    }
}