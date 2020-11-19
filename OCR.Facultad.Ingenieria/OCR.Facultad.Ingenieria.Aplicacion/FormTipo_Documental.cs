using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetTipo_DocumentalTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases;
namespace OCR.Facultad.Ingenieria.Aplicacion
{
    public partial class FormTipo_Documental : Form
    {
        tipo_documentalTableAdapter adaptadortipo_documental = new tipo_documentalTableAdapter();
       
        public FormTipo_Documental()
        {
            InitializeComponent();
        }

       

        private void FormTipo_Documental_Load(object sender, EventArgs e)
        {
            DataSetTipo_Documental.tipo_documentalDataTable tabla=adaptadortipo_documental.GetData();
            if (tabla.Rows.Count > 0)
            {
                this.CargarGrid();
            }
            else
            {
                MessageBox.Show("No existen Registros");
            }
        }

        private void toolStripButtonTransmitir_Click(object sender, EventArgs e)
        {
            if (ValidarVentana())
            {
                try
                {
                    this.LeerVentana();
                    this.CargarGrid();
                    this.LimpiarVentana();
                    MessageBox.Show("El tipo documental fue añadido correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception error)
                {
                    if (error.Message.Contains("Duplicate entry"))
                    {
                        MessageBox.Show("La extensión ya esta registrada en la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.textBoxExtension.Focus();
                    }
                    else {
                        MessageBox.Show(error.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }

        }
        public bool ValidarVentana()
        {
            this.errorProvider.Clear();
            if (this.textBoxExtension.Text == "")
            {
                this.errorProvider.SetError(this.textBoxExtension,"La extensión no puede conetener un valor vacío.");
                return false;
            }
            if (this.textBoxDescripcion.Text == "")
            {
                this.errorProvider.SetError(this.textBoxDescripcion, "La descripción del tipo documental no puede estar vacía.");
                return false;
            }
            if (this.textBoxExtension.Text.Contains(" "))
            {
                MessageBox.Show("La extensión del arhcivo no puede contener espacios en blanco, ingrese una extensión válida.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.textBoxExtension.Focus();
                return false;
            }
            return true;

        }
        public void LeerVentana()
        {
            
                adaptadortipo_documental.InsertTipo_Documental(this.textBoxExtension.Text, this.textBoxDescripcion.Text,this.checkBoxImagen.Checked);
            
        }
        public void CargarGrid()
        {
            this.dataGridViewRegistros.DataSource = adaptadortipo_documental.GetData();            
        }
        public void LimpiarVentana()
        {
            this.textBoxSecuencial.Text = "";
            this.textBoxDescripcion.Text = "";
            this.textBoxExtension.Text = "";
            this.checkBoxImagen.Checked = false;
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
                DataSetTipo_Documental.tipo_documentalRow fila = (DataSetTipo_Documental.tipo_documentalRow)vista.Row;
                this.CargarVentana(fila.tip_nume_tip, fila.tip_extension, fila.tip_descripcion,fila.tip_imagen);
                EnableControlesElimiarModificar(true);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CargarVentana(int secuencial,string extension,string descripcion,bool esimagen)
        {
            this.textBoxSecuencial.Text = secuencial.ToString();
            this.textBoxExtension.Text = extension;
            this.textBoxDescripcion.Text = descripcion;
            this.labelSecuencial.Visible = true;
            this.textBoxSecuencial.Visible = true;
            this.checkBoxImagen.Checked = esimagen;
        }

        private void toolStripButtonLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarVentana();
        }

        private void toolStripButtonModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarVentana())
                {
                    this.ActualizarSecuencial();
                    this.CargarGrid();
                    this.LimpiarVentana();
                    MessageBox.Show("El tipo documental fue modificado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ActualizarSecuencial()
        {
            adaptadortipo_documental.UpdateTipo_Documental(this.textBoxExtension.Text, this.textBoxDescripcion.Text,this.checkBoxImagen.Checked, int.Parse(this.textBoxSecuencial.Text));
        }

        private void toolStripButtonEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea eliminar el Tipo Documental?.", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (this.adaptadortipo_documental.ExisteTipoDocumentalBatch(int.Parse(this.textBoxSecuencial.Text)).Value == 0)
                    {
                        this.EliminarSecuencial();
                        this.CargarGrid();
                        this.LimpiarVentana();
                        MessageBox.Show("El tipo documental fue eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El tipo documental esta asociadio a un ruta en un proceso batch, primero debe eliminar esta asociación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            adaptadortipo_documental.DeleteTipo_Documental(int.Parse(this.textBoxSecuencial.Text));
        }

        private void toolStripButtonBuscar_Click(object sender, EventArgs e)
        {

        }

       
        
    }
}
