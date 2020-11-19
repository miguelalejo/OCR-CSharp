using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetTablanumeroexportadosTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormTablanumeroexportados : Form
    {
        public FormTablanumeroexportados()
        {
            InitializeComponent();
        }
        tablanumeroexportadosTableAdapter reporte = new tablanumeroexportadosTableAdapter();
        private void FormTablanumeroexportados_Load(object sender, EventArgs e)
        {
            this.tablanumeroexportadosDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
