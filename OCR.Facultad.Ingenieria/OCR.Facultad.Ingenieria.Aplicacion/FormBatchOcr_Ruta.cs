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
    public partial class FormBatchOcr_Ruta : Form
    {
        public FormBatchOcr_Ruta()
        {
            InitializeComponent();
        }
        rutaTableAdapter adaptadorruta = new rutaTableAdapter();
        tipo_documentalTableAdapter adaptadortipo_documental = new tipo_documentalTableAdapter();
        batch_ocrTableAdapter adaptadorbatch_ocr = new batch_ocrTableAdapter();
        batch_ocr_rutaTableAdapter adaptadorbatch_ocr_ruta = new batch_ocr_rutaTableAdapter();
        private void FormBatchOcr_Ruta_Load(object sender, EventArgs e)
        {
            try
            {
                this.Limpiar();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxTipoDocumental_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        List<DataSetRuta.rutaRow> listarutas = new List<DataSetRuta.rutaRow>();
        private void textBoxTipoSecuencial_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataSetRuta.rutaDataTable tabla = adaptadorruta.GetDataByRuta_TipoDocumental(int.Parse(this.textBoxTipoSecuencial.Text));
                DataSetRuta.rutaDataTable temp = new DataSetRuta.rutaDataTable();
                if (listarutas.Count > 0)
                {
                    foreach (DataSetRuta.rutaRow fila in tabla)
                    {
                        Predicate<DataSetRuta.rutaRow> predicate = value => value.ru_id.Equals(fila.ru_id);
                        DataSetRuta.rutaRow rutatemp = listarutas.Find(predicate);
                        if (rutatemp == null)
                        {
                            temp.ImportRow(fila);
                        }

                    }
                    this.bindingSourceRuta.DataSource = temp;
                }
                else
                {
                    this.bindingSourceRuta.DataSource = tabla;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxRutasPorSeleccionar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataRowView vista = (this.bindingSourceRuta.Current) as DataRowView;
                if (vista != null)
                {

                    DataSetRuta.rutaRow fila = (DataSetRuta.rutaRow)vista.Row;
                    this.CargarRuta(fila.ru_id, fila.ru_path, fila.ru_activa, fila.tip_extension);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public void CargarRuta(int secuencial, string ruta, bool activa,string tipo_documental)
        {
            this.textBoxRutaPath.Text = ruta;
            this.textBoxRutaSecuencial.Text = secuencial.ToString();
            this.checkBoxRutaActiva.Checked = activa;
            this.textBoxRutaTipo_Documental.Text = tipo_documental;
        }

        private void checkBoxRutaActiva_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBoxRutaActiva.Text=(this.checkBoxRutaActiva.Checked)?"Si":"No";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listBoxRutasPorSeleccionar.SelectedIndex > -1)
                {
                    DataRowView vista = this.listBoxRutasPorSeleccionar.SelectedItem as DataRowView;
                    DataSetRuta.rutaRow filaruta = (DataSetRuta.rutaRow)vista.Row;
                    this.listarutas.Add(filaruta);
                    this.bindingSourceRutaSeleccionadas.DataSource = this.listarutas.ToArray();
                    this.bindingSourceRutaSeleccionadas.ResumeBinding();

                    textBoxTipoSecuencial_TextChanged(sender, new EventArgs());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (object item in this.listBoxRutasPorSeleccionar.Items)
                {
                    DataRowView vista = item as DataRowView;
                    DataSetRuta.rutaRow filaruta = (DataSetRuta.rutaRow)vista.Row;
                    this.listarutas.Add(filaruta);
                }
                this.bindingSourceRutaSeleccionadas.DataSource = this.listarutas.ToArray();
                this.listBoxRutasSeleccionadas.Refresh();
                textBoxTipoSecuencial_TextChanged(sender, new EventArgs());
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.listBoxRutasSeleccionadas.SelectedIndex > -1)
                {
                    this.listarutas.Remove(this.listBoxRutasSeleccionadas.SelectedItem as DataSetRuta.rutaRow);
                    this.bindingSourceRutaSeleccionadas.DataSource = this.listarutas.ToArray();
                    this.listBoxRutasSeleccionadas.Refresh();
                }
                textBoxTipoSecuencial_TextChanged(sender, new EventArgs());
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemoveAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.listarutas = new List<DataSetRuta.rutaRow>();
                this.bindingSourceRutaSeleccionadas.DataSource = this.listarutas.ToArray();
                this.listBoxRutasSeleccionadas.Refresh();
                textBoxTipoSecuencial_TextChanged(sender, new EventArgs());
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxRutasSeleccionadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSetRuta.rutaRow fila = (this.bindingSourceRutaSeleccionadas.Current) as DataSetRuta.rutaRow;
            if (fila != null)
            {                
                this.CargarRuta(fila.ru_id, fila.ru_path, fila.ru_activa,fila.tip_extension);
            }

        }

        private void toolStripButtonTransmitir_Click(object sender, EventArgs e)
        {

            if (ValidarVentana())
            {
                try
                {
                    this.LeerVentana();
                    this.Limpiar();
                    MessageBox.Show("La asociación de las rutas documentales con el proceso batch fue creada satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        public bool ValidarVentana()
        {
            this.errorProvider.Clear();
            if (this.comboBoxProceso.Text == "")
            {
                this.errorProvider.SetError(this.comboBoxProceso, "Debe seleccionar un proceso válido.");
                this.comboBoxProceso.Focus();
                return false;
            }
            if (this.comboBoxRutaPrin.Text == "")
            {
                this.errorProvider.SetError(this.comboBoxRutaPrin, "Debe seleccionar una ruta principal válida.");
                this.comboBoxRutaPrin.Focus();
                return false;
            }
            if (this.comboBoxTipoDocumental.Text == "")
            {
                this.errorProvider.SetError(this.comboBoxTipoDocumental, "Debe seleccionar un tipo documental válido.");
                this.comboBoxTipoDocumental.Focus();
                return false;
            }
            return true;
        }
        public void LeerVentana()
        {
         
               
                    if(listarutas.Count>0)
                    {
                        foreach (DataSetRuta.rutaRow ruta in listarutas)
                        {
                            adaptadorbatch_ocr_ruta.Insert(int.Parse(this.textBoxRutaPrinSecuencial.Text), ruta.ru_id, int.Parse(this.textBoxProcesoSec.Text));
                        }
                    }
                    else{
                        MessageBox.Show("Debe seleccionar almenos una ruta secundaria.","Información",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    }
               
           
        }
        public void Limpiar()
        {
            this.bindingSourceRutaPrincipal.DataSource = adaptadorruta.GetDataByRutasPrincipales();
            this.bindingSourceTipo_Documental.DataSource = adaptadortipo_documental.GetDataByTipoDocumental_Ruta();
            this.bindingSourceRuta.DataSource = adaptadorruta.GetDataByRuta_TipoDocumental(int.Parse(this.textBoxTipoSecuencial.Text));
            this.bindingSourceBatchOcr.DataSource = adaptadorbatch_ocr.GetDataByProcesoSinRuta();
            this.listarutas = new List<DataSetRuta.rutaRow>();
            this.listarutas.Remove(this.listBoxRutasSeleccionadas.SelectedItem as DataSetRuta.rutaRow);
            this.bindingSourceRutaSeleccionadas.DataSource = this.listarutas.ToArray();
            this.listBoxRutasSeleccionadas.Refresh();
            this.listBoxRutasPorSeleccionar_SelectedIndexChanged(this.listBoxRutasPorSeleccionar, new EventArgs());
           // this.textBoxProcesoDescripcion.Text = "";
            //this.textBoxRutaDescripcion.Text = "";
            //this.textBoxTipoDesc.Text = "";
        }

        private void toolStripButtonLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

    

        private void listBoxRutasSeleccionadas_DoubleClick(object sender, EventArgs e)
        {
            if (this.listBoxRutasSeleccionadas.SelectedIndex > -1)
            {
                this.listarutas.Remove(this.listBoxRutasSeleccionadas.SelectedItem as DataSetRuta.rutaRow);
                this.bindingSourceRutaSeleccionadas.DataSource = this.listarutas.ToArray();
                this.listBoxRutasSeleccionadas.Refresh();
            } textBoxTipoSecuencial_TextChanged(sender, new EventArgs());
        }

        private void listBoxRutasPorSeleccionar_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.listBoxRutasPorSeleccionar.SelectedIndex > -1)
                {
                    DataRowView vista = this.listBoxRutasPorSeleccionar.SelectedItem as DataRowView;
                    DataSetRuta.rutaRow filaruta = (DataSetRuta.rutaRow)vista.Row;
                    this.listarutas.Add(filaruta);
                    this.bindingSourceRutaSeleccionadas.DataSource = this.listarutas.ToArray();
                    this.bindingSourceRutaSeleccionadas.ResumeBinding();

                    textBoxTipoSecuencial_TextChanged(sender, new EventArgs());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButtonBuscar_Click(object sender, EventArgs e)
        {
            FormBusquedaBacth_Ocr buscar = new FormBusquedaBacth_Ocr();
            buscar.ShowDialog();
           
        }

        private void toolStripButtonModificar_Click(object sender, EventArgs e)
        {

        }
       


       

        
    }
}
