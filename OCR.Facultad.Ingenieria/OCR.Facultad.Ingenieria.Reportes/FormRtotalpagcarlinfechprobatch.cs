using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRtotalpagcarlinFPBTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormRtotalpagcarlinfechprobatch : Form
    {
        public FormRtotalpagcarlinfechprobatch()
        {
            InitializeComponent();
        }
        rtotalpagcarlinfechprobatchTableAdapter reporte = new rtotalpagcarlinfechprobatchTableAdapter();
        private void FormRtotalpagcarlinfechprobatch_Load(object sender, EventArgs e)
        {
            this.rtotalpagcarlinfechprobatchDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
