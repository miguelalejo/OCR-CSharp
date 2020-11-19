using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRtotaltiemposPFBTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormRtotaltiemposprocfechabatch : Form
    {
        public FormRtotaltiemposprocfechabatch()
        {
            InitializeComponent();
        }
        rtotaltiemposprocfechabatchTableAdapter reporte = new rtotaltiemposprocfechabatchTableAdapter();
        private void FormRtotaltiemposprocfechabatch_Load(object sender, EventArgs e)
        {
            this.rtotaltiemposprocfechabatchDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
