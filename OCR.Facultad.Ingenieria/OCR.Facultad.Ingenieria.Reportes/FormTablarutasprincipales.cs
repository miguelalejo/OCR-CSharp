using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetTablarutasprincipalesTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormTablarutasprincipales : Form
    {
        public FormTablarutasprincipales()
        {
            InitializeComponent();
        }
        tablarutasprincipalesTableAdapter reporte = new tablarutasprincipalesTableAdapter();
        private void FormTablarutasprincipales_Load(object sender, EventArgs e)
        {
            this.tablarutasprincipalesDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
