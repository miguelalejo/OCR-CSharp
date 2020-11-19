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
using OCR.Facultad.Ingenieria.ManagerBases;
using System.IO;
namespace OCR.Facultad.Ingenieria.Aplicacion
{
    public partial class FormRuta : Form
    {
        rutaTableAdapter adaptadorruta = new rutaTableAdapter();
        tipo_documentalTableAdapter adaptadortipo_documental = new tipo_documentalTableAdapter();
        public FormRuta()
        {
            InitializeComponent();
        }

        private void toolStripButtonLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarVentana();
        }
        public void LimpiarVentana()
        {
            this.textBoxRuta.Text = "";
            this.checkBoxActiva.Checked = false;
            this.checkBoxPrincipal.Checked = false;
            EnableControlesElimiarModificar(false);
            this.textBoxRutaDescripcion.Text = "";
            this.CargarCombo();
        }
        public void EnableControlesElimiarModificar(bool valor)
        {
            this.textBoxSecuencial.Visible = valor;
            this.labelSecuencial.Visible = valor;
            this.toolStripButtonTransmitir.Enabled = !valor;
            this.toolStripButtonEliminar.Enabled = valor;
            this.toolStripButtonModificar.Enabled = valor;
        }

        private void buttonExaminar_Click(object sender, EventArgs e)
        {
            DialogResult resul = this.folderBrowserDialog.ShowDialog();
            if (resul == DialogResult.OK)
            {
                this.textBoxRuta.Text = this.folderBrowserDialog.SelectedPath;
            }
        }

        private void toolStripButtonTransmitir_Click(object sender, EventArgs e)
        {
            if (this.ValidarVentana())
            {
                try
                {
                    this.LeerVentana();
                    this.CargarGrid();
                    this.LimpiarVentana();
                    MessageBox.Show("La ruta documental fue añadida correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (this.textBoxRuta.Text == "")
            {
                this.errorProvider.SetError(this.textBoxRuta, "La el path de la ruta documental no puede estar vacía.");
                return false;
            }
            
            if (this.textBoxRutaDescripcion.Text == "")
            {
                this.errorProvider.SetError(this.textBoxRutaDescripcion, "La descripción de la ruta docuemntal no puede estar vacía.");
                return false;
            }
            if (this.comboBoxTipo_Documental.Text == "")
            {
                this.errorProvider.SetError(this.comboBoxTipo_Documental, "Seleccione un tipo documental válido.");
                return false;
            }
            if (!Directory.Exists(this.textBoxRuta.Text))
            {
                MessageBox.Show("La ruta seleccionada no existe, ingrese una ruta válida.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.textBoxRuta.Focus();
                return false;
            }
            return true;
           
        }

        private void FormRuta_Load(object sender, EventArgs e)
        {
            try
            {
                DataSetRuta.rutaDataTable tabla = adaptadorruta.GetData();
                if (tabla.Rows.Count > 0)
                {
                    this.CargarGrid();

                }
                else
                {
                    MessageBox.Show("No existen Registros");
                }
                this.CargarCombo();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LeerVentana()
        {
                      
                    adaptadorruta.InsertRuta(this.textBoxRuta.Text, this.checkBoxActiva.Checked, this.checkBoxPrincipal.Checked, (int)this.comboBoxTipo_Documental.SelectedValue,this.textBoxRutaDescripcion.Text); 
               
           
        }
        public void CargarGrid()
        {
            this.dataGridViewRegistros.DataSource = adaptadorruta.GetData();
        }
        public void CargarCombo()
        {
            try
            {
                this.comboBoxTipo_Documental.DataSource = adaptadortipo_documental.GetData();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButtonModificar_Click(object sender, EventArgs e)
        {
            if (this.ValidarVentana())
            {
                try
                {
                    if (adaptadorruta.ExisteRutaBacth(int.Parse(this.textBoxSecuencial.Text)).Value == 0)
                    {
                        this.ActualizarSecuencial();
                        this.CargarGrid();
                        this.LimpiarVentana();
                        MessageBox.Show("La ruta documental fue modificada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("La ruta esta asociada a un proceso batch, primero debe eliminar esta asociación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        public void ActualizarSecuencial()
        {
            if (adaptadorruta.EsPrincipal(int.Parse(this.textBoxSecuencial.Text))==true)
            {
                adaptadorruta.UpdateRuta(this.textBoxRuta.Text, this.checkBoxActiva.Checked, this.checkBoxPrincipal.Checked, (int)this.comboBoxTipo_Documental.SelectedValue, this.textBoxRutaDescripcion.Text,int.Parse(this.textBoxSecuencial.Text));
            }
            else
            {
                
                    adaptadorruta.UpdateRuta(this.textBoxRuta.Text, this.checkBoxActiva.Checked, this.checkBoxPrincipal.Checked, (int)this.comboBoxTipo_Documental.SelectedValue, this.textBoxRutaDescripcion.Text,int.Parse(this.textBoxSecuencial.Text));
               
            }
        }

        private void toolStripButtonEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea eliminar la Ruta Documental?.", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
             if (result == DialogResult.Yes)
             {
                 try
                 {
                     if (adaptadorruta.ExisteRutaBacth(int.Parse(this.textBoxSecuencial.Text)).Value==0)
                     {
                         this.EliminarSecuencial();
                         this.CargarGrid();
                         this.LimpiarVentana();
                         MessageBox.Show("La ruta documental fue eliminada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                     else
                     {
                         MessageBox.Show("La ruta esta asociada a un proceso batch, primero debe eliminar esta asociación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }

                 }
                 catch (Exception error)
                 {
                     MessageBox.Show(error.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                 }
             }
        }
        public void EliminarSecuencial()
        {
            adaptadorruta.DeleteRuta(int.Parse(this.textBoxSecuencial.Text));
        }

        private void dataGridViewRegistros_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRowView vista = this.dataGridViewRegistros.CurrentRow.DataBoundItem as DataRowView;
                DataSetRuta.rutaRow fila = (DataSetRuta.rutaRow)vista.Row;
                this.CargarVentana(fila.ru_id, fila.ru_path, fila.ru_activa, fila.ru_principal, fila.ru_tipo_documental, fila.ru_descripcion);
                EnableControlesElimiarModificar(true);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }
        public void CargarVentana(int secuencial, string ruta, bool activa,bool principal,int id_tipo_documental,string descripcion )
        {
            this.textBoxSecuencial.Text = secuencial.ToString();
            this.textBoxRuta.Text = ruta;
            this.checkBoxActiva.Checked = activa;
            this.checkBoxPrincipal.Checked=principal;
            this.comboBoxTipo_Documental.SelectedValue = id_tipo_documental;
            this.labelSecuencial.Visible = true;
            this.textBoxSecuencial.Visible = true;
            this.textBoxRutaDescripcion.Text = descripcion;
        }

        private void toolStripButtonBuscar_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewRegistros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
