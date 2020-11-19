using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRepoestprocesamientoTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormRepoestprocesamiento : Form
    {
        public FormRepoestprocesamiento()
        {
            InitializeComponent();
        }
        repoestprocesamientoTableAdapter reporte = new repoestprocesamientoTableAdapter();
        private void FormRepoestprocesamiento_Load(object sender, EventArgs e)
        {
            this.repoestprocesamientoDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer1.RefreshReport();
        }
    }
}
