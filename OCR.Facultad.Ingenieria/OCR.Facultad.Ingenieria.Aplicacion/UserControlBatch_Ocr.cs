using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetTipo_DocumentalTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetBatchOcrTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetBatchOcr_RutaTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRutaTableAdapters;
namespace OCR.Facultad.Ingenieria.Aplicacion
{
    public partial class UserControlBatch_Ocr : UserControl
    {
        public UserControlBatch_Ocr()
        {
            InitializeComponent();
        }
        rutaTableAdapter adaptadorruta = new rutaTableAdapter();
        tipo_documentalTableAdapter adaptadortipo_documental = new tipo_documentalTableAdapter();
        batch_ocrTableAdapter adaptadorbatch_ocr = new batch_ocrTableAdapter();
        batch_ocr_rutaTableAdapter adaptadorbatch_ocr_ruta = new batch_ocr_rutaTableAdapter();
        private void UserControlBatch_Ocr_Load(object sender, EventArgs e)
        {
            this.dataGridViewProcesos.DataSource = adaptadorbatch_ocr.GetDataByBatchAsignados();
            
        }

        private void dataGridViewProcesos_DoubleClick(object sender, EventArgs e)
        {
            DataRowView vista = this.dataGridViewProcesos.CurrentRow.DataBoundItem as DataRowView;
            DataSetBatchOcr.batch_ocrRow fila = (DataSetBatchOcr.batch_ocrRow)vista.Row;
           // this.CargarVentana(fila.ba_ocr_id, fila.ba_ocr_nlotes, fila.ba_ocr_path, fila.ba_ocr_descripcion, fila.ba_ocr_horainicio, fila.ba_ocr_horafin);
            if (fila != null)
            {
                
                this.dataGridViewRutasProceso.DataSource = adaptadorruta.GetDataByRutas_BatchOcr(fila.ba_ocr_id);
                this.CargarVentanaProceso(fila.ba_ocr_id, fila.ba_ocr_nlotes, fila.ba_ocr_path, fila.ba_ocr_descripcion, fila.ba_ocr_horainicio, fila.ba_ocr_horafin);
            }
        }

        private void tabControlProceso_Enter(object sender, EventArgs e)
        {
          
           
        }
        public void CargarVentanaProceso(int secuencial, int nroprocesos, string ruta, string descripcion, DateTime horainicio, DateTime horafin)
        {
            this.textBoxSecuencial.Text = secuencial.ToString();
            this.numericUpDownProcesos.Value = nroprocesos;
            this.textBoxRuta.Text = ruta;
            this.textBoxDescripcion.Text = descripcion;
            this.dateTimePickerInicio.Value = horainicio;
            this.dateTimePickerFin.Value = horafin;
            this.labelSecuencial.Visible = true;
            this.textBoxSecuencial.Visible = true;
        }
        public void CargarVentanaRuta(int secuencial, string ruta, bool activa, bool principal, string tipoext)
        {
            this.textBoxSecRutaProceso.Text = secuencial.ToString();
            this.textBoxRutaProceso.Text = ruta;
            this.checkBoxActiva.Checked = activa;
            this.checkBoxPrincipal.Checked = principal;
            this.comboBoxTipo_Documental.Text= tipoext;
            this.labelSecuencial.Visible = true;
            this.textBoxSecuencial.Visible = true;
        }

        private void tabPageInfoProceso_Enter(object sender, EventArgs e)
        {
           
        }

        private void dataGridViewRutasProceso_DoubleClick(object sender, EventArgs e)
        {
            DataRowView vista = this.dataGridViewRutasProceso.CurrentRow.DataBoundItem as DataRowView;
            DataSetRuta.rutaRow fila = (DataSetRuta.rutaRow)vista.Row;
            this.CargarVentanaRuta(fila.ru_id, fila.ru_path, fila.ru_activa, fila.ru_principal, fila.tip_extension);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public int sec_proceso;
        public int Sec_Proceso
        {
            get {
                return this.sec_proceso;
            }
        }

        private void buttonListo_Click(object sender, EventArgs e)
        {
            this.sec_proceso = int.Parse(this.textBoxSecuencial.Text);
        }
    }
}
