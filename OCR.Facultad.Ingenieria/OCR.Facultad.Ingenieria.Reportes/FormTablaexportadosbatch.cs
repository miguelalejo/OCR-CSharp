using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetTablaexportadosbatchTableAdapters;

namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormTablaexportadosbatch : Form
    {
        public FormTablaexportadosbatch()
        {
            InitializeComponent();
        }
        tablaexportadosbatchTableAdapter reporte = new tablaexportadosbatchTableAdapter();
        private void FormTablaexportadosbatch_Load(object sender, EventArgs e)
        {
            this.tablaexportadosbatchDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
