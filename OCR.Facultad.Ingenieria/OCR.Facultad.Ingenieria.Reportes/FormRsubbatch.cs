using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRsubbatchTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormRsubbatch : Form
    {
        public FormRsubbatch()
        {
            InitializeComponent();
        }
        rsubbatchTableAdapter reporte = new rsubbatchTableAdapter();
        private void FormRsubbatch_Load(object sender, EventArgs e)
        {
            rsubbatchDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
