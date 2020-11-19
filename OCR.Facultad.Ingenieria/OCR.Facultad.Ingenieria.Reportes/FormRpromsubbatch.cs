using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRpromsubbatchTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormRpromsubbatch : Form
    {
        public FormRpromsubbatch()
        {
            InitializeComponent();
        }
        rpromsubbatchTableAdapter reporte = new rpromsubbatchTableAdapter();
        private void FormRpromsubbatch_Load(object sender, EventArgs e)
        {
            rpromsubbatchDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
