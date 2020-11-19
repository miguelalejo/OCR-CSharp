using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRpromleceshoraBTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormRpromleceshorabatch : Form
    {
        public FormRpromleceshorabatch()
        {
            InitializeComponent();
        }
        rpromleceshorabatchTableAdapter reporte = new rpromleceshorabatchTableAdapter();
        private void FormRpromleceshorabatch_Load(object sender, EventArgs e)
        {
            this.rpromleceshorabatchDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
