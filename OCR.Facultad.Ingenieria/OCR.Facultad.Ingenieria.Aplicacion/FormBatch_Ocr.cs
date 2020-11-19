using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetBatchOcrTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases;
using System.IO;

namespace OCR.Facultad.Ingenieria.Aplicacion
{
    public partial class FormBatch_Ocr : Form
    {
        public FormBatch_Ocr()
        {
            InitializeComponent();
        }
        batch_ocrTableAdapter adaptadorbatch_ocr = new  batch_ocrTableAdapter();
        private void FormBatch_Ocr_Load(object sender, EventArgs e)
        {
            try
            {
                DataSetBatchOcr.batch_ocrDataTable tabla = adaptadorbatch_ocr.GetData();
                if (tabla.Rows.Count > 0)
                {
                    this.CargarGrid();
                }
                else
                {
                    MessageBox.Show("No existen Registros");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CargarGrid()
        {
            this.dataGridViewRegistros.DataSource = adaptadorbatch_ocr.GetData(); 
        }
        public void LimpiarVentana()
        {
            this.textBoxSecuencial.Text = "";
            this.textBoxDescripcion.Text = "";
            this.numericUpDownProcesos.Value=1;
            this.dateTimePickerFin.Value = DateTime.Now;
            this.dateTimePickerInicio.Value = DateTime.Now;
            this.textBoxRuta.Text = "";
            EnableControlesElimiarModificar(false);
        }
        public void EnableControlesElimiarModificar(bool valor)
        {
            this.textBoxSecuencial.Visible = valor;
            this.labelSecuencial.Visible = valor;
            this.toolStripButtonTransmitir.Enabled = !valor;
            this.toolStripButtonEliminar.Enabled = valor;
            this.toolStripButtonModificar.Enabled = valor;
        }

        private void dataGridViewRegistros_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRowView vista = this.dataGridViewRegistros.CurrentRow.DataBoundItem as DataRowView;
                DataSetBatchOcr.batch_ocrRow fila = (DataSetBatchOcr.batch_ocrRow)vista.Row;
                this.CargarVentana(fila.ba_ocr_id, fila.ba_ocr_nlotes, fila.ba_ocr_path, fila.ba_ocr_descripcion, fila.ba_ocr_horainicio, fila.ba_ocr_horafin);
                EnableControlesElimiarModificar(true);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CargarVentana(int secuencial, int nroprocesos, string ruta, string descripcion, DateTime horainicio, DateTime horafin)
        {
            this.textBoxSecuencial.Text = secuencial.ToString();
            this.numericUpDownProcesos.Value = nroprocesos;
            this.textBoxRuta.Text = ruta;
            this.textBoxDescripcion.Text = descripcion;
            this.dateTimePickerInicio.Value= horainicio;
            this.dateTimePickerFin.Value  = horafin;
            this.labelSecuencial.Visible = true;
            this.textBoxSecuencial.Visible = true;
        }
        public void LeerVentana()
        {
            adaptadorbatch_ocr.InsertBatchOcr(this.textBoxDescripcion.Text, this.textBoxRuta.Text, Convert.ToInt32(this.numericUpDownProcesos.Value), this.dateTimePickerInicio.Value, this.dateTimePickerFin.Value);
        }
        public void ActualizarSecuencial()
        {
            adaptadorbatch_ocr.UpdateBatchOcr(this.textBoxDescripcion.Text,this.textBoxRuta.Text,Convert.ToInt16(this.numericUpDownProcesos.Value),this.dateTimePickerInicio.Value,this.dateTimePickerFin.Value, int.Parse(this.textBoxSecuencial.Text));
        }
        private void toolStripButtonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Desea eliminar el Proceso Batch?.", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (adaptadorbatch_ocr.ExisteBatch(int.Parse(this.textBoxSecuencial.Text)).Value == 0)
                    {
                        this.EliminarSecuencial();
                        this.CargarGrid();
                        this.LimpiarVentana();
                        MessageBox.Show("El Proceso Batch fue eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El Proceso Batch esta asociado a una ruta documental, primero debe eliminar esta asociación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }
        public void EliminarSecuencial()
        {
            adaptadorbatch_ocr.DeleteBatchOcr(int.Parse(this.textBoxSecuencial.Text));
        }

        private void toolStripButtonTransmitir_Click(object sender, EventArgs e)
        {
            this.errorProvider.Clear();
            if (ValidarVentana())
            {
                try
                {
                    this.LeerVentana();
                    this.CargarGrid();
                    this.LimpiarVentana();
                    MessageBox.Show("El Proceso Batch fue añadido correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        public bool ValidarVentana()
        {
            if (this.textBoxRuta.Text == "")
            {
                this.errorProvider.SetError(this.textBoxRuta, "La ruta no puede estar vacía.");
                return false;
            }
            else
            {
                if (this.textBoxDescripcion.Text == "")
                {
                    this.errorProvider.SetError(this.textBoxDescripcion, "La descripción del proceso batch no puede estar vacía.");
                    return false;
                }
                else
                {
                    if (!File.Exists(this.textBoxRuta.Text))
                    {
                        MessageBox.Show("El path seleccionado no existe, eliga una ruta válida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.textBoxRuta.Focus();
                        return false;
                    }
                    return true;
                }
            }
        }
        private void toolStripButtonModificar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ActualizarSecuencial();
                this.CargarGrid();
                this.LimpiarVentana();
                MessageBox.Show("El proceso Batch fue modificado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButtonBuscar_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarVentana();
        }

        private void buttonExaminar_Click(object sender, EventArgs e)
        {
            DialogResult resul = this.openFileDialogBatch.ShowDialog();
            if (resul == DialogResult.OK)
            {
                this.textBoxRuta.Text = this.openFileDialogBatch.FileName;
            }
        }


    }
}
