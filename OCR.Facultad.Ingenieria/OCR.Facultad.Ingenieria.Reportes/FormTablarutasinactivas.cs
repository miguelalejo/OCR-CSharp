using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetTablarutasinactivasTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormTablarutasinactivas : Form
    {
        public FormTablarutasinactivas()
        {
            InitializeComponent();
        }
        tablarutasinactivasTableAdapter reporte = new tablarutasinactivasTableAdapter();
        private void FormTablarutasinactivas_Load(object sender, EventArgs e)
        {
            this.tablarutasinactivasDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
