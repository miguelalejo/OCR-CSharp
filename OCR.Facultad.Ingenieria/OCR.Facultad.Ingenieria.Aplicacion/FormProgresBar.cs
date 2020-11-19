using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using OCR;
using System.Collections;
using System.IO;
using OCR.Facultad.Ingenieria.Clases;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRadicadoTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetTipo_DocumentalTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases;
namespace OCR.Facultad.Ingenieria.Aplicacion
{
    public partial class FormProgresBar : Form
    {
        radicadoTableAdapter adaptadorradicado = new radicadoTableAdapter();
        tipo_documentalTableAdapter adaptadortipo_documental = new tipo_documentalTableAdapter();
        public FormProgresBar()
        {
            InitializeComponent();
        }
        int valor=0;
        public int Valor{
            get {
                return this.valor;
            }
            set {
                this.valor = value;
                //if (this.progressBar.Maximum >= this.valor)
                //{
                //    this.progressBar.Value = valor;
                //    this.statusBar.Text = "Progreso: " + valor.ToString() + "%";
                //}
            }
        }
        int maxvalor;
        public int MaxValor
        {
            get
            {
                return this.maxvalor;
            }
            set
            {
                this.maxvalor = value;
                this.progressBar.Maximum = maxvalor;  
                
            }
        }
        public void Cargar()
        {
            while (true)
            {
                if (this.valor > this.progressBar.Value)
                {
                    OnDone();
                }
                
            }
        }
        public void OnDone()
        {
            
                //this.progressBar.Value = valor;
            this.progressBar.PerformStep();
                //this.statusBar.Text = "Progreso: " + valor.ToString() + "%";              

                
            
        }
        public void Iniciar()
        {
            hilo = new Thread(Cargar);
            hilo.Start();
        }
        public void Terminar()
        {
            hilo.Abort();
        }

        Thread hilo;
     
        private void FormProgresBar_Load(object sender, EventArgs e)
        {
            
        }
        public void IniciaBack()
        {
            backgroundWorkerDoc.WorkerReportsProgress = true;
            backgroundWorkerDoc.RunWorkerAsync();
        }
        string extensionerror = "";
        public string ExtensionError
        {
            get {
                return this.extensionerror;
            }
        }
       // ConexionPDFODBC conexion = new ConexionPDFODBC(FormProcesamientoImagene.nombreODBC);
        public void ActualizaBanderaRegistros(string[] listaDirectorio)
        
        {
            try
            {


                for (int i = 0; i < listaDirectorio.Length; i++)
                {
                    FileInfo info = new FileInfo(listaDirectorio[i]);
                    adaptadorradicado.DeleteRadicado(info.Name);
                    string ext = info.Extension.Replace(".", "");
                    extensionerror = ext;
                    int secext = (int)adaptadortipo_documental.FillByTipoExtencion(ext);
                    adaptadorradicado.InsertRadicado("ASUNTIO", "USA", info.CreationTime, "DESC", info.DirectoryName, info.Extension, "DESC", 0, info.Name, info.Length, secext);
                    string nombrexmlarchivo = "XA" + info.Name.Replace(info.Extension, ".xml");
                    string rutaxmlarchivo = Path.Combine(info.DirectoryName, nombrexmlarchivo);
                    if (File.Exists(rutaxmlarchivo))
                    {
                        File.Delete(rutaxmlarchivo);
                    }
                    string nombremxlproceso = "XP" + info.Name.Replace(info.Extension, ".xml");
                    string rutaxmlproceso = Path.Combine(info.DirectoryName, nombremxlproceso);
                    if (File.Exists(rutaxmlproceso))
                    {
                        File.Delete(rutaxmlproceso);
                    }
                    string nombremxlconfig = "XC" + info.Name.Replace(" ", "").Replace(info.Extension, ".xml");
                    string rutaxmlconfig = Path.Combine(info.DirectoryName, nombremxlconfig);
                    if (File.Exists(rutaxmlconfig))
                    {
                        File.Delete(rutaxmlconfig);
                    }
                    this.valor++;
                    backgroundWorkerDoc.ReportProgress(this.valor);
                }
                extensionerror = "";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        public string[] ArchivosconRegistro(string rutaFiles, string[] listaBase, string[] listaDirectorio)
        {
            
                ArrayList lista = new ArrayList();
                for (int j = 0; j < listaDirectorio.Length; j++)
                {
                    bool exito = false;
                    for (int i = 0; i < listaBase.Length; i++)
                    {
                        string ruta = Path.Combine(rutaFiles, listaBase[i]);
                        if (ruta == listaDirectorio[j])
                        {
                            exito = true;
                            break;
                        }
                    }
                    if (exito)
                    {

                        if (File.Exists(listaDirectorio[j]))
                        {
                            lista.Add(listaDirectorio[j]);
                        }
                    }
                    this.valor++;
                    backgroundWorkerDoc.ReportProgress(this.valor);
                }
                string[] temp = ((string[])lista.ToArray(typeof(string)));
                return temp;
            
        }
        public string[] ArchivosconRegistroNoProcesados(string rutaFiles, string[] listaBase, string[] listaDirectorio)
        {
            ArrayList lista = new ArrayList();


            for (int j = 0; j < listaDirectorio.Length; j++)
            {
                bool exito = false;
                for (int i = 0; i < listaBase.Length; i++)
                {
                    string ruta = Path.Combine(rutaFiles, listaBase[i]);
                    if (ruta == listaDirectorio[j])
                    {
                        exito = true;
                        break;
                    }
                }
                if (exito)
                {

                    if (File.Exists(listaDirectorio[j]))
                    {
                        lista.Add(listaDirectorio[j]);
                    }
                }
                this.valor++;
                backgroundWorkerNoProcesado.ReportProgress(this.valor);
            }
            string[] temp = ((string[])lista.ToArray(typeof(string)));
            return temp;
        }
        string[] listaDirectorio;
        public string[] ListaDirectorio
        {
            get {
                return this.listaDirectorio;
            }
            set
            {
                this.listaDirectorio = value;
            }
        }
        string []listaBase;
         public string[] ListaBase
        {
            get {
                return this.listaBase;
            }
            set
            {
                this.listaBase = value;
            }
        }
         string rutaFiles;
         public string RutaFiles
         {
             get
             {
                 return this.rutaFiles;
             }
             set
             {
                 this.rutaFiles = value;
             }
         }
         string []lista;
         public string[] Lista
         {
             get
             {
                 return this.lista;
             }
             set
             {
                 this.lista = value;
             }
         }
         string cabecera;
         bool existeerror=false;
         public bool ExisteError
         {
             get {
                 return this.existeerror;
             }
         }
         string error;
         public string Error
         {
             get {
                 return this.error;
             }
         }

        private void backgroundWorkerDoc_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.valor = 0;
                cabecera = "Actualizando Bandera Registros : ";
                ActualizaBanderaRegistros(this.listaDirectorio);
                string[] sourceFiles = this.listaDirectorio;
                //conexion.ArchivosFlag("cod_archivo", "tb_archivos", "FLG_OCR", 1);
                this.valor = 0;
                cabecera = "Asociando Registros : ";
                this.lista = ArchivosconRegistro(rutaFiles, sourceFiles, this.listaDirectorio);

            }
            catch (Exception error)
            {
                backgroundWorkerDoc.WorkerReportsProgress = false;
                this.existeerror = true;
                this.error = error.Message;
              
            }
         
          
            
        }

        private void backgroundWorkerDoc_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            double porcenta = Convert.ToDouble(this.valor)*100 / Convert.ToDouble( this.maxvalor);
            this.Text = cabecera +" "+ Math.Round(porcenta,2) + " % ";
            progressBar.Value = e.ProgressPercentage;
            this.statusBar.Text = "Progreso: " + progressBar.Value.ToString() + " archivos procesados.";
 
        }

        private void backgroundWorkerDoc_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();

        }

        string ruta;
        public string Ruta
        {
            get {
                return this.ruta;
            }
            set {
                this.ruta = value;
            }
        }

        string rutaA;
        public string RutaA
        {
            get
            {
                return this.rutaA;
            }
            set
            {
                this.rutaA = value;
            }
        }

        string rutaB;
        public string RutaB
        {
            get
            {
                return this.rutaB;
            }
            set
            {
                this.rutaB = value;
            }
        }

        string extA;
        public string ExtA
        {
            get
            {
                return this.extA;
            }
            set
            {
                this.extA = value;
            }
        }

        string extB;
        public string ExtB
        {
            get
            {
                return this.extB;
            }
            set
            {
                this.extB = value;
            }
        }
        int nborrados;
        public int NBorrados
        {
            get
            {
                return this.nborrados;
            }
            set
            {
                this.nborrados = value;
            }
        }
        int nmov;
        public int NMov
        {
            get
            {
                return this.nmov;
            }
            set
            {
                this.nmov = value;
            }
        }
        public void IniciaBackMover()
        {
            backgroundWorkerCom.WorkerReportsProgress = true;
            backgroundWorkerCom.RunWorkerAsync();
        }
        string[] cargarNombresArchivos(string ruta, string ext)
        {
            ArrayList imageFilesNames = new ArrayList();

            string[] filesWithCurrentExtention = System.IO.Directory.GetFiles(ruta, ext);
            imageFilesNames.AddRange(filesWithCurrentExtention);

            return ((string[])imageFilesNames.ToArray(typeof(string)));
        }

        public int MoverFicheros(string ruta, string rutaA, string rutaB, string extA, string extB)
        {

            string[] sourceFilesCom = cargarNombresArchivos(rutaA, extA);
            string[] sourceFilesDes = cargarNombresArchivos(rutaB, extB);
            int contador = 0;
            for (int i = 0; i < sourceFilesCom.Length; i++)
            {
                for (int j = 0; j < sourceFilesDes.Length; j++)
                {
                    FileInfo a = new FileInfo(sourceFilesCom[i]);
                    string com = a.Name.Replace(a.Extension, "");
                    FileInfo b = new FileInfo(sourceFilesDes[j]);
                    string des = b.Name.Replace(b.Extension, "");
                    if (com == des)
                    {
                        FileInfo f = new FileInfo(sourceFilesDes[j]);
                        string dest = Path.Combine(ruta, f.Name);
                        if (!File.Exists(dest))
                        {
                            File.Move(sourceFilesDes[j], dest);
                        }
                        else
                        {
                            File.Delete(dest);
                            File.Move(sourceFilesDes[j], dest);
                        }
                        contador++;
                        continue;
                    }
                }
                this.valor++;
                backgroundWorkerCom.ReportProgress(i);
            }
            return contador;
        }
        public void IniciaBackBorrar()
        {
            backgroundWorkerComBorrar.WorkerReportsProgress = true;
            backgroundWorkerComBorrar.RunWorkerAsync();
        }
        public int BorrarFicheros(string rutaA, string rutaB, string extA, string extB)
        {
            int contador = 0;
            string[] sourceFilesCom = cargarNombresArchivos(rutaA, extA);
            
            string[] sourceFilesDes = cargarNombresArchivos(rutaB, extB);
            for (int i = 0; i < sourceFilesCom.Length; i++)
            {
                for (int j = 0; j < sourceFilesDes.Length; j++)
                {
                    FileInfo a = new FileInfo(sourceFilesCom[i]);
                    string com = a.Name.Replace(a.Extension, "");
                    FileInfo b = new FileInfo(sourceFilesDes[j]);
                    string des = b.Name.Replace(b.Extension, "");
                    if (com == des)
                    {

                        File.Delete(sourceFilesDes[j]);
                        contador++;
                        continue;
                    }
                }
                this.valor++;
                backgroundWorkerComBorrar.ReportProgress(i);
            }
            return contador;



        }

        private void backgroundWorkerCom_DoWork(object sender, DoWorkEventArgs e)
        {
            cabecera = "Moviendo Archivos : ";
            this.valor = 0;
           this.nmov= this.MoverFicheros(this.ruta, this.rutaA, this.rutaB, this.extA, this.extB);
        }

        private void backgroundWorkerCom_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            double porcenta = Convert.ToDouble(this.valor) * 100 / Convert.ToDouble(this.maxvalor);
            this.Text = cabecera + " " + Math.Round(porcenta, 2) + " % ";
            progressBar.Value = e.ProgressPercentage;
            this.statusBar.Text = "Progreso: " + progressBar.Value.ToString() + " archivos procesados.";
        }

        private void backgroundWorkerCom_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        private void backgroundWorkerComBorrar_DoWork(object sender, DoWorkEventArgs e)
        {
            cabecera = "Borrando Archivos : ";
            this.valor = 0;
           this.nborrados= this.BorrarFicheros(this.rutaA, this.rutaB, this.extA, this.extB);
        }

        private void backgroundWorkerComBorrar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            double porcenta = Convert.ToDouble(this.valor) * 100 / Convert.ToDouble(this.maxvalor);
            this.Text = cabecera + " " + Math.Round(porcenta, 2) + " % ";
            progressBar.Value = e.ProgressPercentage;
            this.statusBar.Text = "Progreso: " + progressBar.Value.ToString() + " archivos procesados.";
        }

        private void backgroundWorkerComBorrar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
        public void ActualizaBanderaRegistros(string[] listaDirectorio, int idflag)
        {

            for (int i = 0; i < listaDirectorio.Length; i++)
            {
                FileInfo info = new FileInfo(listaDirectorio[i]);
                string name = info.Name.Replace(info.Extension, ".tif");
                //conexion.UpdateFlagTBARCHIVOS(name, idflag);
                this.valor++;
                backgroundWorkerUpdate.ReportProgress(i);
            }
        }
        public void ActualizaBanderaRegistrosNoProcesados(string[] listaDirectorio, int idflag)
        {

            for (int i = 0; i < listaDirectorio.Length; i++)
            {
                FileInfo info = new FileInfo(listaDirectorio[i]);
                string name = info.Name.Replace(info.Extension, ".tif");
                //conexion.UpdateFlagTBARCHIVOS(name, idflag);
                this.valor++;
                backgroundWorkerNoProcesado.ReportProgress(i);
            }
        }
        int flag;
        public int Flag
        {
            get {
                return this.flag;

            }
            set {
                this.flag = value;
            }
        }

        private void backgroundWorkerUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
            cabecera = "Actualizando Bandera Archivos : ";
            this.valor = 0;
            //this.ActualizaBanderaRegistros(this.ListaDirectorio, flag);
            }
            catch (Exception error)
            {
                backgroundWorkerUpdate.WorkerReportsProgress = false;
                this.existeerror = true;
                this.error = error.Message;
              
            }
        }

        private void backgroundWorkerUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
        public void IniciaBackUpdate()
        {
            backgroundWorkerUpdate.WorkerReportsProgress = true;
            backgroundWorkerUpdate.RunWorkerAsync();
        }

        private void backgroundWorkerUpdate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            double porcenta = Convert.ToDouble(this.valor) * 100 / Convert.ToDouble(this.maxvalor);
            this.Text = cabecera + " " + Math.Round(porcenta, 2) + " % ";
            progressBar.Value = e.ProgressPercentage;
            this.statusBar.Text = "Progreso: " + progressBar.Value.ToString() + " archivos procesados.";
 
        }
        Fichero fichero;
        public Fichero Fichero
        {
            get {
                return this.fichero;
            }
            set {
                this.fichero = value;
            }
        }
        public void MoverFicheros()
        {

            string[] sourceFilesOri = cargarNombresArchivos(fichero.RutaOrigen, fichero.ExtOrigen);
            for (int i = 0; i < sourceFilesOri.Length; i++)
            {
                FileInfo f = new FileInfo(sourceFilesOri[i]);
                string dest = Path.Combine(fichero.RutaDestino, f.Name);
                if (!File.Exists(dest))
                {
                    File.Move(sourceFilesOri[i], dest);
                    fichero.NumeroCopiados++;

                }
                else
                {
                    File.Delete(dest);
                    File.Move(sourceFilesOri[i], dest);
                    fichero.NumeroReemplazados++;
                }
                this.valor++;
                backgroundWorkerResFicheros.ReportProgress(i);
            }
            fichero.NumeroArchivos = sourceFilesOri.Length;

        }
        public void CopiarFicheros()
        {
            string[] sourceFilesOri = cargarNombresArchivos(fichero.RutaOrigen, fichero.ExtOrigen);
            for (int i = 0; i < sourceFilesOri.Length; i++)
            {
                FileInfo f = new FileInfo(sourceFilesOri[i]);
                string dest = Path.Combine(fichero.RutaDestino, f.Name);
                if (!File.Exists(dest))
                {
                    File.Copy(sourceFilesOri[i], dest);
                    fichero.NumeroCopiados++;
                }
                else
                {
                    File.Copy(sourceFilesOri[i], dest, true);
                    fichero.NumeroReemplazados++;
                }
                this.valor++;
                backgroundWorkerResFicheros.ReportProgress(i);
            }
            fichero.NumeroArchivos = sourceFilesOri.Length;
        }
        public void IniciaBackFicheros()
        {
            backgroundWorkerResFicheros.WorkerReportsProgress = true;
            backgroundWorkerResFicheros.RunWorkerAsync();
        }
        private void backgroundWorkerResFicheros_DoWork(object sender, DoWorkEventArgs e)
        {
            cabecera = fichero.Accion+" Archivos : ";
            
            this.valor = 0;
            if (fichero.Accion == "Mover")
            {
                this.MoverFicheros();
            }
            else
            {
                this.CopiarFicheros();
            }
        }

        private void backgroundWorkerResFicheros_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            double porcenta = Convert.ToDouble(this.valor) * 100 / Convert.ToDouble(this.maxvalor);
            this.Text = cabecera + " " + Math.Round(porcenta, 2) + " % ";
            this.labelRutas.Text = "Desde " + fichero.RutaOrigen + " a " + fichero.RutaDestino;
            progressBar.Value = e.ProgressPercentage;
            this.statusBar.Text = "Progreso: " + progressBar.Value.ToString() + " archivos procesados.";
        }

        private void backgroundWorkerResFicheros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
        FicheroRango ficherorango;
        public FicheroRango FicheroRango
        {
            get {
                return ficherorango;
            }
            set {
                this.ficherorango = value;
            }
        }
        public void MoverFicherosRango()
        {

            string[] sourceFilesOri = cargarNombresArchivos(ficherorango.RutaOrigen, ficherorango.ExtOrigen,ficherorango.Desde,ficherorango.Hasta);
            for (int i = 0; i < sourceFilesOri.Length; i++)
            {
                FileInfo f = new FileInfo(sourceFilesOri[i]);
                string dest = Path.Combine(ficherorango.RutaDestino, f.Name);
                if (!File.Exists(dest))
                {
                    File.Move(sourceFilesOri[i], dest);
                    ficherorango.NumeroCopiados++;

                }
                else
                {
                    File.Delete(dest);
                    File.Move(sourceFilesOri[i], dest);
                    ficherorango.NumeroReemplazados++;
                }
                this.valor++;
                backgroundWorkerFicheroRango.ReportProgress(i);
            }
            ficherorango.NumeroArchivos = sourceFilesOri.Length;

        }
        public void CopiarFicherosRango()
        {
            string[] sourceFilesOri = cargarNombresArchivos(ficherorango.RutaOrigen, ficherorango.ExtOrigen, ficherorango.Desde, ficherorango.Hasta);
            for (int i = 0; i < sourceFilesOri.Length; i++)
            {
                FileInfo f = new FileInfo(sourceFilesOri[i]);
                string dest = Path.Combine(ficherorango.RutaDestino, f.Name);
                if (!File.Exists(dest))
                {
                    File.Copy(sourceFilesOri[i], dest);
                    ficherorango.NumeroCopiados++;
                }
                else
                {
                    File.Copy(sourceFilesOri[i], dest, true);
                    ficherorango.NumeroReemplazados++;
                }
                this.valor++;
                backgroundWorkerFicheroRango.ReportProgress(i);
            }
            ficherorango.NumeroArchivos = sourceFilesOri.Length;
        }
        string[] cargarNombresArchivos(string ruta, string ext,DateTime desde,DateTime hasta)
        {
            ArrayList imageFilesNames = new ArrayList();
            
            string[] filesWithCurrentExtention = System.IO.Directory.GetFiles(ruta, ext);
            for(int i=0;i<filesWithCurrentExtention.Length;i++)
            {
                FileInfo file = new FileInfo(filesWithCurrentExtention[i]);
                DateTime fechaini = new DateTime(desde.Year, desde.Month, desde.Day);
                DateTime fechafin = new DateTime(hasta.Year, hasta.Month, hasta.Day);
                if (fechaini.CompareTo(fechafin) != 0)
                {
                    fechaini = new DateTime(desde.Year, desde.Month, desde.Day,0,0,0);
                    fechafin = new DateTime(hasta.Year, hasta.Month, hasta.Day,23,59,59);
                    if (file.LastWriteTime.CompareTo(fechaini) >= 0 && file.LastWriteTime.CompareTo(fechafin) <= 0)
                    {
                        imageFilesNames.Add(filesWithCurrentExtention[i]);
                    }
                }
                else
                {
                    if (file.LastWriteTime.CompareTo(fechaini) >= 0)
                    {
                        imageFilesNames.Add(filesWithCurrentExtention[i]);
                    }
                }

            }

            return ((string[])imageFilesNames.ToArray(typeof(string)));
        }
        public void IniciaBackFicherosRango()
        {
            backgroundWorkerFicheroRango.WorkerReportsProgress = true;
            backgroundWorkerFicheroRango.RunWorkerAsync();
        }
        private void backgroundWorkerFicheroRango_DoWork(object sender, DoWorkEventArgs e)
        {
            cabecera = ficherorango.Accion + " Archivos : ";

            this.valor = 0;
            if (ficherorango.Accion == "Mover")
            {
                this.MoverFicherosRango();
            }
            else
            {
                this.CopiarFicherosRango();
            }
        }

        private void backgroundWorkerFicheroRango_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            double porcenta = Convert.ToDouble(this.valor) * 100 / Convert.ToDouble(this.maxvalor);
            this.Text = cabecera + " " + Math.Round(porcenta, 2) + " % ";
            this.labelRutas.Text = "Desde " + ficherorango.RutaOrigen + " a " + ficherorango.RutaDestino;
            progressBar.Value = e.ProgressPercentage;
            this.statusBar.Text = "Progreso: " + progressBar.Value.ToString() + " archivos procesados.";
        }

        private void backgroundWorkerFicheroRango_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        FicheroAccion ficheroaccion;
        public FicheroAccion FicheroAccion
        {
            get {
                return this.ficheroaccion;

            }
            set {
                this.ficheroaccion = value;
            }
        }
        public void MoverFicherosAccion()
        {
            string[] sourceFilesCom = cargarNombresArchivos(ficheroaccion.RutaOrigen, ficheroaccion.ExtOrigen);
            string[] sourceFilesDes = cargarNombresArchivos(ficheroaccion.RutaDestino, ficheroaccion.ExtDestino);
            for (int i = 0; i < sourceFilesCom.Length; i++)
            {
                for (int j = 0; j < sourceFilesDes.Length; j++)
                {
                    FileInfo a = new FileInfo(sourceFilesCom[i]);
                    string com = a.Name.Replace(a.Extension, "");
                    FileInfo b = new FileInfo(sourceFilesDes[j]);
                    string des = b.Name.Replace(b.Extension, "");
                    if (com == des)
                    {
                        FileInfo f = new FileInfo(sourceFilesDes[j]);
                        string dest = Path.Combine(ficheroaccion.RutaMover, f.Name);
                        if (!File.Exists(dest))
                        {
                            File.Copy(sourceFilesDes[j], dest);
                            File.Delete(sourceFilesDes[j]);
                            ficheroaccion.NumeroCopiados++;
                        }
                        else
                        {
                            File.Delete(dest);
                            File.Copy(sourceFilesDes[j], dest);
                            File.Delete(sourceFilesDes[j]);
                            ficheroaccion.NumeroReemplazados++;
                        }

                    }
                }
                this.valor++;
                backgroundWorkerFicheroAccion.ReportProgress(i);
            }
            ficheroaccion.NumeroArchivos = ficheroaccion.NumeroCopiados + ficheroaccion.NumeroReemplazados;
          
        }
        public void BorrarFicherosAccion()
        {
            string[] sourceFilesCom = cargarNombresArchivos(ficheroaccion.RutaOrigen, ficheroaccion.ExtOrigen);
            string[] sourceFilesDes = cargarNombresArchivos(ficheroaccion.RutaDestino, ficheroaccion.ExtDestino);
            for (int i = 0; i < sourceFilesCom.Length; i++)
            {
                for (int j = 0; j < sourceFilesDes.Length; j++)
                {
                    FileInfo a = new FileInfo(sourceFilesCom[i]);
                    string com = a.Name.Replace(a.Extension, "");
                    FileInfo b = new FileInfo(sourceFilesDes[j]);
                    string des = b.Name.Replace(b.Extension, "");
                    if (com == des)
                    {
                        File.Delete(sourceFilesDes[j]);
                        ficheroaccion.NumeroBorrados++;
                    }
                }
                this.valor++;
                backgroundWorkerFicheroAccion.ReportProgress(i);
            }
            ficheroaccion.NumeroArchivos = ficheroaccion.NumeroBorrados; 
        }
        public void IniciaBackFicherosAccion()
        {
            backgroundWorkerFicheroAccion.WorkerReportsProgress = true;
            backgroundWorkerFicheroAccion.RunWorkerAsync();
        }
        private void backgroundWorkerFicheroAccion_DoWork(object sender, DoWorkEventArgs e)
        {
            cabecera = ficheroaccion.Accion + " Archivos : ";
            this.valor = 0;
            if (ficheroaccion.Accion == "Mover")
            {
                this.MoverFicherosAccion();
            }
            else
            {
                this.BorrarFicherosAccion();
            }
        }

        private void backgroundWorkerFicheroAccion_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            double porcenta = Convert.ToDouble(this.valor) * 100 / Convert.ToDouble(this.maxvalor);
            this.Text = cabecera + " " + Math.Round(porcenta, 2) + " % ";
            if (ficheroaccion.Accion != "Borrar")
            {
                this.labelRutas.Text = "Desde " + ficheroaccion.RutaOrigen + " a " + ficheroaccion.RutaDestino;
            }
            progressBar.Value = e.ProgressPercentage;
            this.statusBar.Text = "Progreso: " + progressBar.Value.ToString() + " archivos procesados.";
     
        }
        private void backgroundWorkerFicheroAccion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
        public void IniciaBackNoProcesados()
        {
            backgroundWorkerNoProcesado.WorkerReportsProgress = true;
            backgroundWorkerNoProcesado.RunWorkerAsync();
        }

        private void backgroundWorkerNoProcesado_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.valor = 0;
                cabecera = "Actualizando Bandera Registros No Procesados: ";
                //ActualizaBanderaRegistrosNoProcesados(this.listaDirectorio,7);
                string[] sourceFiles = this.listaDirectorio;
                    //conexion.ArchivosFlag("cod_archivo", "tb_archivos", "FLG_OCR", 7);
                this.valor = 0;
                cabecera = "Asociando Registros : ";
                this.lista = ArchivosconRegistroNoProcesados(rutaFiles, sourceFiles, this.listaDirectorio);

            }
            catch (Exception error)
            {
                backgroundWorkerDoc.WorkerReportsProgress = false;
                this.existeerror = true;
                this.error = error.Message;

            }
        }

        private void backgroundWorkerNoProcesado_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            double porcenta = Convert.ToDouble(this.valor) * 100 / Convert.ToDouble(this.maxvalor);
            this.Text = cabecera + " " + Math.Round(porcenta, 2) + " % ";
            progressBar.Value = e.ProgressPercentage;
            this.statusBar.Text = "Progreso: " + progressBar.Value.ToString() + " archivos procesados.";
        }

        private void backgroundWorkerNoProcesado_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        private void statusBar_PanelClick(object sender, StatusBarPanelClickEventArgs e)
        {

        }


    }
}
