using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRespdiscoprocTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormRespdiscoproc : Form
    {
        public FormRespdiscoproc()
        {
            InitializeComponent();
        }
        respdiscoprocTableAdapter reporte = new respdiscoprocTableAdapter();
        private void FormRespdiscoproc_Load(object sender, EventArgs e)
        {
            this.respdiscoprocDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
