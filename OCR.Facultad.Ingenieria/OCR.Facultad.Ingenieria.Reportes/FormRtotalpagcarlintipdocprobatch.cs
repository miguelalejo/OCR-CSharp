using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRtotalpagcarlinTPBTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormRtotalpagcarlintipdocprobatch : Form
    {
        public FormRtotalpagcarlintipdocprobatch()
        {
            InitializeComponent();
        }
        rtotalpagcarlintipdocprobatchTableAdapter reporte = new rtotalpagcarlintipdocprobatchTableAdapter();
        private void FormRtotalpagcarlintipdocprobatch_Load(object sender, EventArgs e)
        {
            this.rtotalpagcarlintipdocprobatchDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
