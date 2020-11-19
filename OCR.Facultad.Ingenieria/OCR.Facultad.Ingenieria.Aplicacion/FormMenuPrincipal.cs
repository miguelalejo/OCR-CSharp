using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.Reportes;
using System.Diagnostics;
using System.Web;
using System.Security.Permissions;
using System.IO;

namespace OCR.Facultad.Ingenieria.Aplicacion
{
    public partial class FormMenuPrincipal : Form
    {
        public FormMenuPrincipal()
        {
            InitializeComponent();
            this.tabPapeWPF.ClickBotonWPF += new EventHandler(tabPapeWPF_Click);
            this.menuBotonWPF.ClickMenuBotonWPF += new EventHandler(menuBotonWPF_ClickMenuBotonWPF);
            this.reportesWPF.ClickBotonWPF += new EventHandler(reportesWPF_ClickBotonWPF);
            this.ayudaWPF.ClickBotonWPF += new EventHandler(ayudaWPF_ClickBotonWPF);
        }

        void ayudaWPF_ClickBotonWPF(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Controls.Button boton = (System.Windows.Controls.Button)sender;
                if (boton.Name == "butonmantecnico")
                {
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = "manuales\\Documentation.chm";
                    Process proceso = new Process();
                    proceso.StartInfo = info;
                    proceso.Start();

                }
                if (boton.Name == "butonmanusuario")
                {
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = "manuales\\ManualUsuario.docx";
                    Process proceso = new Process();
                    proceso.StartInfo = info;
                    proceso.Start();            

                
                }
                if (boton.Name == "butonmaninstalacion")
                {
                   ProcessStartInfo info = new ProcessStartInfo();
                   info.FileName = "manuales\\ManualInstalacion.docx";
                    Process proceso = new Process();
                    proceso.StartInfo = info;
                    proceso.Start();

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        void reportesWPF_ClickBotonWPF(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Controls.Button boton = (System.Windows.Controls.Button)sender;
                if (boton.Name == "FormRepoestadisticas")
                {
                    FormRepoestadisticas reporte = new FormRepoestadisticas();
                    reporte.ShowDialog();
                }
                if (boton.Name == "FormRepoestprocesamiento")
                {
                    FormRepoestprocesamiento reporte = new FormRepoestprocesamiento();
                    reporte.ShowDialog();
                }
                if (boton.Name == "FormRepoprocesados")
                {
                    FormRepoprocesados reporte = new FormRepoprocesados();
                    reporte.ShowDialog();
                }
                if (boton.Name == "FormRepotiempo")
                {
                    FormRepotiempo reporte = new FormRepotiempo();
                    reporte.ShowDialog();
                }
                if (boton.Name == "FormRepotiempoprocesamiento")
                {
                    FormRepotiempoprocesamiento reporte = new FormRepotiempoprocesamiento();
                    reporte.ShowDialog();
                }
                if (boton.Name == "FormTablarutasprincipales")
                {
                    FormTablarutasprincipales reporte = new FormTablarutasprincipales();
                    reporte.ShowDialog();
                }
                if (boton.Name == "FormTablarutassecundarias")
                {
                    FormTablarutassecundarias reporte = new FormTablarutassecundarias();
                    reporte.ShowDialog();
                }
                if (boton.Name == "FormTablarutasactivas")
                {
                    FormTablarutasactivas reporte = new FormTablarutasactivas();
                    reporte.ShowDialog();
                }

                if (boton.Name == "FormTablarutasinactivas")
                {
                    FormTablarutasinactivas reporte = new FormTablarutasinactivas();
                    reporte.ShowDialog();
                }
                if (boton.Name == "FormTablanumeroexportados")
                {
                    FormTablanumeroexportados reporte = new FormTablanumeroexportados();
                    reporte.ShowDialog();
                }
                if (boton.Name == "FormTablarutastipodocumental")
                {
                    FormTablarutastipodocumental reporte = new FormTablarutastipodocumental();
                    reporte.ShowDialog();
                }
                if (boton.Name == "FormTablaexportadosbatch")
                {
                    FormTablaexportadosbatch reporte = new FormTablaexportadosbatch();
                    reporte.ShowDialog();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
           
          
            
            
            
            
            
        }

        void menuBotonWPF_ClickMenuBotonWPF(object sender, EventArgs e)
        {
            System.Windows.Controls.Button boton = (System.Windows.Controls.Button)sender;
            if (boton.Name == "butonayuda")
            {
               
                this.elementHostTabPage.Visible = false;
                this.elementHostReportes.Visible = false;
                this.elementHostAyuda.Visible = true;

            }
            if (boton.Name == "butonreportes")
            {
               
                this.elementHostAyuda.Visible = false;
                this.elementHostTabPage.Visible= false;
                this.elementHostReportes.Visible = true;
               
                

            }
            if (boton.Name == "butonprocesamiento")
            {
           
                this.elementHostAyuda.Visible = false;                
                this.elementHostReportes.Visible = false;
                this.elementHostTabPage.Visible = true;

            }
        }

        void tabPapeWPF_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Controls.Button boton = (System.Windows.Controls.Button)sender;
                if (boton.Name == "butonmysql")
                {
                    FormConexionBaseMysql fmysql = new FormConexionBaseMysql();
                    fmysql.ShowDialog();
                    if (fmysql.Reiniciar)
                    {
                        DialogResult result= MessageBox.Show("La configuración ha cambiado, para que los cambios tengan efecto debe reiniciar la aplicación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            Application.Restart();
                        }
                        //Environment.Exit();
                    }

                }

                if (boton.Name == "butontiposdocumentales")
                {
                    FormTipo_Documental ftipo_documental = new FormTipo_Documental();
                    ftipo_documental.ShowDialog();
                }
                if (boton.Name == "butonrutas")
                {
                    FormRuta fruta = new FormRuta();
                    fruta.ShowDialog();
                }

                if (boton.Name == "butonprocesosbatch")
                {
                    FormBatch_Ocr fbatch_ocr = new FormBatch_Ocr();
                    fbatch_ocr.ShowDialog();
                }
                if (boton.Name == "butonaddrutasprocesos")
                {
                    FormBatchOcr_Ruta faddbatch_ruta = new FormBatchOcr_Ruta();
                    faddbatch_ruta.ShowDialog();
                }
                if (boton.Name == "butonmodrutasprocesos")
                {
                    FormBatchOcr_RutaModificacion fmodbatch_ruta = new FormBatchOcr_RutaModificacion();
                    fmodbatch_ruta.ShowDialog();
                }
                if (boton.Name == "butonprocesar")
                {
                    FormPrincipal fprincipal = new FormPrincipal();
                    fprincipal.Show();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

         }

        void FormMenuPrincipal_Click(object sender, EventArgs e)
        {
            
        }
        

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            try {
                if (!Directory.Exists("temptif"))
                {
                    Directory.CreateDirectory("temptif");
                }
                CargarAppConfig();
            }
            catch (Exception error)
            {
                MessageBox.Show(String.Format("Error al leer el archivo de configuración de la aplicación {0}", error.Message), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void CargarAppConfig()
        {
            FormPrincipal.autoarranque = Boolean.Parse(ClassAppAplicacion.GetAutoArranque());
            FormPrincipal.enderezamiento = Boolean.Parse(ClassAppAplicacion.GetDeskew());
            FormPrincipal.moverdocumentos = Boolean.Parse(ClassAppAplicacion.GetMoverDoc());
        }
        
    }
}
