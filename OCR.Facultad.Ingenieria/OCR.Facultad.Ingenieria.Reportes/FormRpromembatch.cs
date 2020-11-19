using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRpromemBTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormRpromembatch : Form
    {
        public FormRpromembatch()
        {
            InitializeComponent();
        }
        rpromembatchTableAdapter reporte = new rpromembatchTableAdapter();

        private void FormRpromembatch_Load(object sender, EventArgs e)
        {
            rpromembatchDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
