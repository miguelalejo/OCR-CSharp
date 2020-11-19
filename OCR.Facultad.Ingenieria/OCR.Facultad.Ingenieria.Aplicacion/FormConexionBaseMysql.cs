using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetServerTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases;
using System.Configuration;
using OCR.Facultad.Ingenieria.Util;
using OCR.Facultad.Ingenieria.Reportes;

namespace OCR.Facultad.Ingenieria.Aplicacion
{
    public partial class FormConexionBaseMysql : Form
    {
        serverTableAdapter adapadorServer = new serverTableAdapter();
        
        public FormConexionBaseMysql()
        {
            InitializeComponent();
            
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarVentana())
                {
                    bool isconexion = ConexionMysql.Test(this.textBoxIp.Text, Convert.ToInt16(this.numericUpDownPuerto.Value), this.textBoxUsuario.Text, textBoxContrasenia.Text, this.comboBoxBaseDatos.Text);

                    if (isconexion)
                    {
                        //this.comboBoxBaseDatos.DataSource = ConexionMysql.BasesDeDatos(this.textBoxIp.Text, Convert.ToInt16(this.numericUpDownPuerto.Value), this.textBoxUsuario.Text, textBoxContrasenia.Text, this.comboBoxBaseDatos.Text);
                        MessageBox.Show("Conexion Establecida con Exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Conexion No Establecida con Exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


  
        private void FormConexionBaseMysql_Load(object sender, EventArgs e)
        {
            try
            {
                cargarDatos();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        bool reiniciar;
        public bool Reiniciar
        {
            get { return this.reiniciar; }
        }
        private void toolStripButtonTransmitir_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarVentana())
                {
                    bool isconexion = ConexionMysql.Test(this.textBoxIp.Text, Convert.ToInt16(this.numericUpDownPuerto.Value), this.textBoxUsuario.Text, textBoxContrasenia.Text, this.comboBoxBaseDatos.Text);
                    bool esvalida = ConexionMysql.ValidarTablasBase(this.textBoxIp.Text, Convert.ToInt16(this.numericUpDownPuerto.Value), this.textBoxUsuario.Text, textBoxContrasenia.Text, this.comboBoxBaseDatos.Text);
                    bool esalmacenado = false;
                    if (isconexion && esvalida)
                    {
                        bool existeMysql = ConexionMysql.ExisteServer(this.textBoxIp.Text, (int)this.numericUpDownPuerto.Value, this.textBoxUsuario.Text, this.textBoxContrasenia.Text, this.comboBoxBaseDatos.Text);
                        if (existeMysql)
                        {  
                                    esalmacenado= ConexionMysql.UpdateServidor(this.textBoxIp.Text, (int)this.numericUpDownPuerto.Value, this.textBoxUsuario.Text,this.textBoxContrasenia.Text, Util.Encriptar.EncriptarMD5(this.textBoxContrasenia.Text, int.Parse(ClassAppAplicacion.GetKeyPublicaMysql())), this.comboBoxBaseDatos.Text, "Mysql");
                                    if (esalmacenado)
                                    {
                                        this.GuardarConfiguracion();
                                        this.reiniciar = true;    
                                        MessageBox.Show("La configuración del Servidor Mysql fue almacenada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else {
                                        MessageBox.Show("No se pudo guardar la información en la base.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    
                                              
                            
                        }
                        else
                        {
                            
                            esalmacenado= ConexionMysql.GuardarServidor(this.textBoxIp.Text, (int)this.numericUpDownPuerto.Value, this.textBoxUsuario.Text, this.textBoxContrasenia.Text, Util.Encriptar.EncriptarMD5(this.textBoxContrasenia.Text, int.Parse(ClassAppAplicacion.GetKeyPublicaMysql())), this.comboBoxBaseDatos.Text, "Mysql");
                            if (esalmacenado)
                            {
                                this.GuardarConfiguracion();
                                this.reiniciar = true;    
                                MessageBox.Show("La configuración del Servidor Mysql fue almacenada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se pudo guardar la información en la base.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        if (esvalida)
                        {
                            MessageBox.Show("Conexion No Establecida con Exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        if (!esvalida)
                        {
                            MessageBox.Show("Las tablas en la base no coinciden con las requeridas por el sistema.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        public void GuardarConfiguracion()
        {
            try
            {
                string formatoconexion = "server={0};User Id={1};Persist Security Info=True;password={2};database={3};";

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.ConnectionStrings.ConnectionStrings.Count > 0)
                {
                    string cadenaconexion=String.Format(formatoconexion, this.textBoxIp.Text, this.textBoxUsuario.Text, this.textBoxContrasenia.Text, this.comboBoxBaseDatos.Text);
                    config.ConnectionStrings.ConnectionStrings["OCR.Facultad.Ingenieria.ManagerBases.Properties.Settings.ocrConnectionString"].ConnectionString = cadenaconexion;
                    config.ConnectionStrings.ConnectionStrings["OCR.Facultad.Ingenieria.ManagerBases.Properties.Settings.ocrConnectionString"].ProviderName = "MySql.Data.MySqlClient";
                    config.Save(ConfigurationSaveMode.Modified, true);
                    ConfigurationManager.RefreshSection("connectionStrings");
                    //ConfiguracionManagerBases.GuardarConfiguracion(cadenaconexion);
                    //ConfiguracionReportes.GuardarConfiguracion(cadenaconexion);
                }
                else
                {

                    config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(
                                                                  "OCR.Facultad.Ingenieria.ManagerBases.Properties.Settings.ocrConnectionString",
                                                                  String.Format(formatoconexion, this.textBoxIp.Text, this.textBoxUsuario.Text, this.textBoxContrasenia.Text, this.comboBoxBaseDatos.Text), "MySql.Data.MySqlClient"
                                                                                 ));
                    config.Save(ConfigurationSaveMode.Modified, true);
                    ConfigurationManager.RefreshSection("connectionStrings");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        public bool ValidarVentana()
        {
            this.errorProvider.Clear();
            if (this.textBoxUsuario.Text == "")
            {
                this.errorProvider.SetError(this.textBoxUsuario, "El campo no puede contener valores nulos.");
                return false;
            }
            if (this.textBoxContrasenia.Text == "")
            {
                this.errorProvider.SetError(this.textBoxContrasenia, "El campo contraseña debe tener un valor.");
                return false;
            }
            if (this.comboBoxBaseDatos.Text == "")
            {
                this.errorProvider.SetError(this.comboBoxBaseDatos, "Seleccione una base de datos válida.");
                return false; 
            }
            return true;
        }
           
        private void cargarDatos()
        {
            DataSetServer.serverDataTable tabla= new DataSetServer.serverDataTable();
            int nfilas = adapadorServer.SelectServerTipo(tabla,"Mysql");
           
            if (nfilas>0) {
                DataSetServer.serverRow fila = tabla[0] as DataSetServer.serverRow;
                this.textBoxIp.Text = fila.ser_ip_ser.ToString();
                this.numericUpDownPuerto.Value = fila.ser_puerto_ser;
                this.textBoxUsuario.Text = fila.ser_user_ser.ToString();
                this.textBoxContrasenia.Text = Util.Encriptar.DesEncriptarMD5(fila.ser_contrasenia_ser.ToString(),int.Parse(ClassAppAplicacion.GetKeyPublicaMysql()));
                this.comboBoxBaseDatos.Text = fila.ser_nombre_base_ser.ToString();
            }
            else
            {
                this.textBoxIp.Text = "";
                this.textBoxUsuario.Text = "";
                this.textBoxContrasenia.Text = "";
                MessageBox.Show("Servidor Mysql no registrado en BD");
            }

        }

        private void comboBoxBaseDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxBaseDatos_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (ValidarVentana())
                {
                    bool isconexion = ConexionMysql.Test(this.textBoxIp.Text, Convert.ToInt16(this.numericUpDownPuerto.Value), this.textBoxUsuario.Text, textBoxContrasenia.Text, this.comboBoxBaseDatos.Text);

                    if (isconexion)
                    {
                        this.comboBoxBaseDatos.DataSource = ConexionMysql.BasesDeDatos(this.textBoxIp.Text, Convert.ToInt16(this.numericUpDownPuerto.Value), this.textBoxUsuario.Text, textBoxContrasenia.Text, this.comboBoxBaseDatos.Text);
                    }
                    else
                    {
                        this.comboBoxBaseDatos.DataSource = null;
                        this.comboBoxBaseDatos.Text = "Seleccione:";
                        MessageBox.Show("Conexion No Establecida con Exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
