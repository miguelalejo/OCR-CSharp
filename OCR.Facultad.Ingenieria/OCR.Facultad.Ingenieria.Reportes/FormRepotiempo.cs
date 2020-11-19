using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRepotiempoTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormRepotiempo : Form
    {
        public FormRepotiempo()
        {
            InitializeComponent();
        }
        repotiempoTableAdapter reporte = new repotiempoTableAdapter();
        private void FormRepotiempo_Load(object sender, EventArgs e)
        {
            this.repotiempoDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer1.RefreshReport();
        }
    }
}
