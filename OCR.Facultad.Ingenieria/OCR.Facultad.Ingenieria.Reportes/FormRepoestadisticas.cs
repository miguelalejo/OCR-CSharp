using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRepoestadisticasTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormRepoestadisticas : Form
    {
        public FormRepoestadisticas()
        {
            InitializeComponent();
        }
        repoestadisticasTableAdapter reporte = new repoestadisticasTableAdapter();
        private void FormRepoestadisticas_Load(object sender, EventArgs e)
        {
          this.repoestadisticasDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer1.RefreshReport();
        }
    }
}
