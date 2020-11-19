using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRepotiempoprocesamientoTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormRepotiempoprocesamiento : Form
    {
        public FormRepotiempoprocesamiento()
        {
            InitializeComponent();
        }
        repotiempoprocesamientoTableAdapter reporte = new repotiempoprocesamientoTableAdapter();
        private void FormRepotiempoprocesamiento_Load(object sender, EventArgs e)
        {
            this.repotiempoprocesamientoDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer1.RefreshReport();
        }
    }
}
