using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRpromlectdisBTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormRpromlectdisbatch : Form
    {
        public FormRpromlectdisbatch()
        {
            InitializeComponent();
        }
        rpromlectdisbatchTableAdapter reporte = new rpromlectdisbatchTableAdapter();
        private void FormRpromlectdisbatch_Load(object sender, EventArgs e)
        {
            rpromlectdisbatchDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer1.RefreshReport();
        }
    }
}
