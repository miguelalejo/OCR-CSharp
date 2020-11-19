using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRtotaltiemposPFDTableAdapters;
namespace OCR.Facultad.Ingenieria.Reportes
{
    public partial class FormRtotaltiemposprocfechadir : Form
    {
        public FormRtotaltiemposprocfechadir()
        {
            InitializeComponent();
        }
        rtotaltiemposprocfechadirTableAdapter reporte = new rtotaltiemposprocfechadirTableAdapter();
        private void FormRtotaltiemposprocfechadir_Load(object sender, EventArgs e)
        {
            this.rtotaltiemposprocfechadirDataTableBindingSource.DataSource = reporte.GetData();
            this.reportViewer.RefreshReport();
        }
    }
}
