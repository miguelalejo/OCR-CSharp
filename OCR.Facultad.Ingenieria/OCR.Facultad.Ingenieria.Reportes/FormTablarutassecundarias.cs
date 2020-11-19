using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetTablarutassecundariasTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormTablarutassecundarias : Form
    {
        public FormTablarutassecundarias()
        {
            InitializeComponent();
        }
        tablarutassecundariasTableAdapter reporte = new tablarutassecundariasTableAdapter();
        private void FormTablarutassecundarias_Load(object sender, EventArgs e)
        {
            tablarutassecundariasDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
