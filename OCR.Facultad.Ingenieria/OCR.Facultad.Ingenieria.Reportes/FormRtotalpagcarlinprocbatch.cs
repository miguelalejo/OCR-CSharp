using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRtotalpagcarlinPBTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormRtotalpagcarlinprocbatch : Form
    {
        public FormRtotalpagcarlinprocbatch()
        {
            InitializeComponent();
        }
        rtotalpagcarlinprocbatchTableAdapter reporte = new rtotalpagcarlinprocbatchTableAdapter();
        private void FormRtotalpagcarlinprocbatch_Load(object sender, EventArgs e)
        {
            this.rtotalpagcarlinprocbatchDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
