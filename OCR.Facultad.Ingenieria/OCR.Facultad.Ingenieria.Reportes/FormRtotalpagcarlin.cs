using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRtotalpagcarlinTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormRtotalpagcarlin : Form
    {
        public FormRtotalpagcarlin()
        {
            InitializeComponent();
        }
        rtotalpagcarlinTableAdapter reporte = new rtotalpagcarlinTableAdapter();
        private void FormRtotalpagcarlin_Load(object sender, EventArgs e)
        {
            this.rtotalpagcarlinDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
