using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRtiemposPFBTableAdapters;

namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormRtiemposprocesamientofechabatch : Form
    {
        public FormRtiemposprocesamientofechabatch()
        {
            InitializeComponent();
        }
        rtiemposprocesamientofechabatchTableAdapter reporte = new rtiemposprocesamientofechabatchTableAdapter();
        private void FormRtiemposprocesamientofechabatch_Load(object sender, EventArgs e)
        {
            rtiemposprocesamientofechabatchDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
