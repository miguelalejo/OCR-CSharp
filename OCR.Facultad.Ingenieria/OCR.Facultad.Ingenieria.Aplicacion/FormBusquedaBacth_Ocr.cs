using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRutaTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetTipo_DocumentalTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetBatchOcrTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetBatchOcr_RutaTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases;

namespace OCR.Facultad.Ingenieria.Aplicacion
{
    public partial class FormBusquedaBacth_Ocr : Form
    {
        public FormBusquedaBacth_Ocr()
        {
            InitializeComponent();
        }
        rutaTableAdapter adaptadorruta = new rutaTableAdapter();
        tipo_documentalTableAdapter adaptadortipo_documental = new tipo_documentalTableAdapter();
        batch_ocrTableAdapter adaptadorbatch_ocr = new batch_ocrTableAdapter();
        batch_ocr_rutaTableAdapter adaptadorbatch_ocr_ruta = new batch_ocr_rutaTableAdapter();
       

        private void dataGridViewProcesos_DoubleClick(object sender, EventArgs e)
        {
            try
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
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        public void CargarVentanaRuta(int secuencial, string ruta, bool activa, bool principal, string tipoext,string descripcion)
        {
            this.textBoxSecRutaProceso.Text = secuencial.ToString();
            this.textBoxRutaProceso.Text = ruta;
            this.checkBoxActiva.Checked = activa;
            this.checkBoxPrincipal.Checked = principal;
            this.comboBoxTipo_Documental.Text = tipoext;
            this.labelSecuencial.Visible = true;
            this.textBoxSecuencial.Visible = true;
            this.textBoxRutaDescripcion.Text = descripcion;
        }

       

        private void dataGridViewRutasProceso_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRowView vista = this.dataGridViewRutasProceso.CurrentRow.DataBoundItem as DataRowView;
                DataSetRuta.rutaRow fila = (DataSetRuta.rutaRow)vista.Row;
                this.CargarVentanaRuta(fila.ru_id, fila.ru_path, fila.ru_activa, fila.ru_principal, fila.tip_extension, fila.ru_descripcion);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        public int sec_proceso=-1;
        public int Sec_Proceso
        {
            get
            {
                return this.sec_proceso;
            }
        }

        private void buttonListo_Click(object sender, EventArgs e)
        {
            
            if (this.textBoxSecuencial.Text=="")
            {
                DialogResult result= MessageBox.Show("No ha seleccioando ningún proceso, desea cerrar la ventana?","Información",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.sec_proceso = int.Parse(this.textBoxSecuencial.Text);
                this.Close();
            }
        }

        private void FormBusquedaBacth_Ocr_Load(object sender, EventArgs e)
        {
            try
            {
                this.dataGridViewProcesos.DataSource = adaptadorbatch_ocr.GetDataByBatchAsignados();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
