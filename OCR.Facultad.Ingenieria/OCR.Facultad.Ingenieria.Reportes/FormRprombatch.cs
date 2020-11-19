using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRprombatchTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormRprombatch : Form
    {
        public FormRprombatch()
        {
            InitializeComponent();
        }
        rprombatchTableAdapter reporte = new rprombatchTableAdapter();
        private void FormRprombatch_Load(object sender, EventArgs e)
        {
            this.rprombatchDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
