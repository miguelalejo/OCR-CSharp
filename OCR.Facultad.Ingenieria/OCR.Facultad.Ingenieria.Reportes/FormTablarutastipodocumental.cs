using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetTablarutastipodocumentalTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormTablarutastipodocumental : Form
    {
        public FormTablarutastipodocumental()
        {
            InitializeComponent();
        }
        tablarutastipodocumentalTableAdapter reporte = new tablarutastipodocumentalTableAdapter();
        private void FormTablarutastipodocumental_Load(object sender, EventArgs e)
        {
            this.tablarutastipodocumentalDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
