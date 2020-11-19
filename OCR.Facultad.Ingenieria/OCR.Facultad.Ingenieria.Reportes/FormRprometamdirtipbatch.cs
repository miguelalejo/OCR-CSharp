using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRprometamdirTPBTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormRprometamdirtipbatch : Form
    {
        public FormRprometamdirtipbatch()
        {
            InitializeComponent();
        }
        rprometamdirtipbatchTableAdapter reporte = new rprometamdirtipbatchTableAdapter();
        private void FormRprometamdirtipbatch_Load(object sender, EventArgs e)
        {
            this.rprometamdirtipbatchDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
