using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRpromtambatchTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormRpromtambatch : Form
    {
        public FormRpromtambatch()
        {
            InitializeComponent();
        }
        rpromtambatchTableAdapter reporte = new rpromtambatchTableAdapter();
        private void FormRpromtambatch_Load(object sender, EventArgs e)
        {
            rpromtambatchDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
