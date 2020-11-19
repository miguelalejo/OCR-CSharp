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
    public partial class FormBatchOcr_RutaModificacion : Form
    {
        public FormBatchOcr_RutaModificacion()
        {
            InitializeComponent();
        }

        
        rutaTableAdapter adaptadorruta = new rutaTableAdapter();
        tipo_documentalTableAdapter adaptadortipo_documental = new tipo_documentalTableAdapter();
        batch_ocrTableAdapter adaptadorbatch_ocr = new batch_ocrTableAdapter();
        batch_ocr_rutaTableAdapter adaptadorbatch_ocr_ruta = new batch_ocr_rutaTableAdapter();
        private void FormBatchOcr_RutaModificacion_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cargar();
                this.textBoxProcesoSec_TextChanged(this.textBoxTipoDesc, new EventArgs());
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Cargar()
        {
            this.bindingSourceBatchOcr.DataSource = adaptadorbatch_ocr.GetDataByProcesoConRuta();
            this.bindingSourceTipo_Documental.DataSource = adaptadortipo_documental.GetDataByTipoDocumental_Ruta();
            
           
        }

       
        List<DataSetRuta.rutaRow> listarutas = new List<DataSetRuta.rutaRow>();
        private void textBoxTipoSecuencial_TextChanged(object sender, EventArgs e)
        {
            
            DataSetRuta.rutaDataTable tabla = adaptadorruta.GetDataByRuta_TipoDocumental(int.Parse(this.textBoxTipoSecuencial.Text));
            DataSetRuta.rutaDataTable temp = new DataSetRuta.rutaDataTable();
            if (listarutas.Count > 0)
            {
                foreach (DataSetRuta.rutaRow fila in tabla)
                {
                    Predicate<DataSetRuta.rutaRow> predicate = value => value.ru_id.Equals(fila.ru_id);
                    DataSetRuta.rutaRow rutatemp=listarutas.Find(predicate);
                    if (rutatemp== null)
                    {
                        temp.ImportRow(fila);
                    }

                }
                this.bindingSourceRuta.DataSource = temp;
            }
            else {
                this.bindingSourceRuta.DataSource = tabla;
            }
        }

        private void listBoxRutasPorSeleccionar_SelectedIndexChanged(object sender, EventArgs e)
        {
                       
            DataRowView vista = ( this.bindingSourceRuta.Current) as DataRowView;
            if (vista != null)
            {

                DataSetRuta.rutaRow fila = (DataSetRuta.rutaRow)vista.Row;
                this.CargarRuta(fila.ru_id, fila.ru_path, fila.ru_activa,fila.tip_extension);
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
            if (this.listBoxRutasPorSeleccionar.SelectedIndex > -1)
            {
                DataRowView vista =this.listBoxRutasPorSeleccionar.SelectedItem as DataRowView;
                DataSetRuta.rutaRow filaruta = (DataSetRuta.rutaRow)vista.Row;
                this.listarutas.Add(filaruta);
                this.bindingSourceRutaSeleccionadas.DataSource = this.listarutas.ToArray();
                this.bindingSourceRutaSeleccionadas.ResumeBinding();
                
                textBoxTipoSecuencial_TextChanged(sender, new EventArgs());
            }
        }

        private void buttonAddAll_Click(object sender, EventArgs e)
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

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (this.listBoxRutasSeleccionadas.SelectedIndex > -1)
            {
                this.listarutas.Remove(this.listBoxRutasSeleccionadas.SelectedItem as DataSetRuta.rutaRow);
                this.bindingSourceRutaSeleccionadas.DataSource = this.listarutas.ToArray();
                this.listBoxRutasSeleccionadas.Refresh();
            } textBoxTipoSecuencial_TextChanged(sender, new EventArgs());
        }

        private void buttonRemoveAll_Click(object sender, EventArgs e)
        {
            this.listarutas = new List<DataSetRuta.rutaRow>();
            this.bindingSourceRutaSeleccionadas.DataSource = this.listarutas.ToArray();
            this.listBoxRutasSeleccionadas.Refresh();
            textBoxTipoSecuencial_TextChanged(sender, new EventArgs());
        }

        private void listBoxRutasSeleccionadas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButtonTransmitir_Click(object sender, EventArgs e)
        {
            if (ValidarVentana())
            {
                try
                {
                    this.LeerVentana();
                    this.Limpiar();
                    MessageBox.Show("La asociación de las rutas documentales con el proceso batch fue modificada satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        public void LeerVentana()
        {
         
               
                    if(listarutas.Count>0)
                    {
                        adaptadorbatch_ocr_ruta.DeleteBatchOcr_Ruta(int.Parse(this.textBoxProcesoSec.Text));
                        foreach (DataSetRuta.rutaRow ruta in listarutas)
                        {
                            
                            adaptadorbatch_ocr_ruta.Insert(int.Parse(this.textBoxRutaPrinSecuencial.Text), ruta.ru_id, int.Parse(this.textBoxProcesoSec.Text));
                        }
                    }
                    else{
                        MessageBox.Show("Debe seleccionar almenos una ruta secundaria.","Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
               
          
        }
        public void Limpiar()
        {
            
            this.listarutas = new List<DataSetRuta.rutaRow>();
            this.listarutas.Remove(this.listBoxRutasSeleccionadas.SelectedItem as DataSetRuta.rutaRow);
            this.bindingSourceRutaSeleccionadas.DataSource = this.listarutas.ToArray();
            this.listBoxRutasSeleccionadas.Refresh();            
            this.textBoxProcesoDescripcion.Text = "";
            this.textBoxRutaDescripcion.Text = "";
            this.textBoxTipoDesc.Text = "";


        }

        private void toolStripButtonLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.Cargar();
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
            int index = 0;
            
            foreach (DataSetBatchOcr.batch_ocrRow fila in (DataSetBatchOcr.batch_ocrDataTable)bindingSourceBatchOcr.DataSource)
            {
                if (fila.ba_ocr_id == buscar.Sec_Proceso)
                {
                    this.comboBoxProceso.SelectedIndex = index;
                    break;
                }
                index++;
            }
           
        }

        private void textBoxProcesoSec_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.textBoxProcesoSec.Text != "")
                {
                    this.bindingSourceRutaPrincipal.DataSource = adaptadorruta.GetDataByRutasPrincipalesM(int.Parse(this.textBoxProcesoSec.Text));
                    this.listarutas = new List<DataSetRuta.rutaRow>();
                    DataSetRuta.rutaDataTable rutassec = adaptadorruta.GetDataByRutas_BatchOcr(int.Parse(this.textBoxProcesoSec.Text));
                    foreach (DataSetRuta.rutaRow fila in rutassec)
                    {
                        listarutas.Add(fila);
                    }
                    this.bindingSourceRutaSeleccionadas.DataSource = this.listarutas.ToArray();
                    this.listBoxRutasSeleccionadas.Refresh();
                    if (this.textBoxTipoSecuencial.Text != "")
                    {
                        this.bindingSourceRuta.DataSource = adaptadorruta.GetDataByRuta_TipoDocumental(int.Parse(this.textBoxTipoSecuencial.Text));
                        this.listBoxRutasPorSeleccionar_SelectedIndexChanged(this.listBoxRutasPorSeleccionar, new EventArgs());
                        textBoxTipoSecuencial_TextChanged(sender, new EventArgs());
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButtonModificar_Click(object sender, EventArgs e)
        {
            
            if (ValidarVentana())
            {
                try{
                this.LeerVentana();
                //this.Limpiar();
                this.Cargar();
                      MessageBox.Show("La asociación de las rutas documentales con el proceso batch fue modificada satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void toolStripMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButtonTransmitir_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripButtonEliminar_Click(object sender, EventArgs e)
        {
            
            DialogResult result=MessageBox.Show("¿Desea eliminar el Proceso Batch y las Rutas Documentales asociadas?.", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                try
                {
                    this.EliminarBatch();
                    
                    this.Limpiar();
                    this.Cargar();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

        }
        public void EliminarBatch()
        {
            adaptadorbatch_ocr_ruta.DeleteBatchOcr_Ruta(int.Parse(this.textBoxProcesoSec.Text));
        }
       

    }
}
