using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetTablarutasactivasTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormTablarutasactivas : Form
    {
        public FormTablarutasactivas()
        {
            InitializeComponent();
        }
        tablarutasactivasTableAdapter reporte = new tablarutasactivasTableAdapter();
        private void FormTablarutasactivas_Load(object sender, EventArgs e)
        {
            this.tablarutasactivasDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
