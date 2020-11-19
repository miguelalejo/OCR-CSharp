using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRepoprocesadosTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormRepoprocesados : Form
    {
        public FormRepoprocesados()
        {
            InitializeComponent();
        }
        repoprocesadosTableAdapter reporte = new repoprocesadosTableAdapter();
        private void FormRepoprocesados_Load(object sender, EventArgs e)
        {
            this.repoprocesadosDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer1.RefreshReport();
        }
    }
}
