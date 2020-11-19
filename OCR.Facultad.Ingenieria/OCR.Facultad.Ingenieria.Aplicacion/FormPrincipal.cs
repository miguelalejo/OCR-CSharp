using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRutaTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRadicadoTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetOcrTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetBatchOcrTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetOcr_ExportadoTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetOcr_PaginaTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetOcr_LineaTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetOcr_EstadisticasTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases;
using System.IO;
using System.Collections;
using OCR.Facultad.Ingenieria.Clases;
using System.Diagnostics;
using OCR.Facultad.Ingenieria.Util;
using OCR.Facultad.Ingenieria.MangerBasesXml;
using OCR.Facultad.Ingenieria.Estadisticas;
using System.Threading;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetTipo_DocumentalTableAdapters;
namespace OCR.Facultad.Ingenieria.Aplicacion
{
    public partial class FormPrincipal : Form
    {
        rutaTableAdapter adaptadorruta = new rutaTableAdapter();
        radicadoTableAdapter adaptadorradicado = new radicadoTableAdapter();
        batch_ocrTableAdapter adaptadorbatch_ocr = new batch_ocrTableAdapter();
        ocrTableAdapter adaptadorocr = new ocrTableAdapter();
        ocr_exportadoTableAdapter adaptadorocr_exportado = new ocr_exportadoTableAdapter();
        ocr_lineaTableAdapter adaptadorocr_linea = new ocr_lineaTableAdapter();
        ocr_paginaTableAdapter adaptadorocr_pagina = new ocr_paginaTableAdapter();
        tipo_documentalTableAdapter adaptadortipo_documental = new tipo_documentalTableAdapter();
        public static bool autoarranque;
        public static bool enderezamiento;
        public static bool moverdocumentos;
        private static object abortedLockObject = new object();
        /// <summary>
        /// Variable tipo AutoResetEvent utilizada para bloquear dos o más hilos cuando intentan acceder de forma simultanea a un bloque de código.
        /// </summary>
        private static AutoResetEvent blockThread = new AutoResetEvent(true);
        ocr_estadisticasTableAdapter adaptadorocr_estadisticas = new ocr_estadisticasTableAdapter();
        string[] imageFileExtentions2 = new string[]{ "*.bmp", "*.dcx", "*.pcx", "*.png",
			"*.jpg", "*.jpeg", "*.jp2", "*.jpc", "*.jfif", "*.pdf", "*.tif", "*.tiff", "*.gif",
			"*.djvu", "*.djv", "*.jb2" };
        string[] imageFileExtentions = new string[] { "*.tif" };
        int nexitos;
        int nfracasos;
        int narchivos;
       
        volatile int npaginas;
        volatile int nhilos = 0;
        /// <summary>
        /// read image files names in the selected directory
        /// </summary> 
        /// <returns>array of files names in the selected directory</returns>
        string[] cargarNombresArchivos(string ruta)
        {
            ArrayList imageFilesNames = new ArrayList();
            for (int index = 0; index < imageFileExtentions.Length; index++)
            {
                string[] filesWithCurrentExtention = System.IO.Directory.GetFiles(ruta, imageFileExtentions[index]);
                imageFilesNames.AddRange(filesWithCurrentExtention);
            }
            return ((string[])imageFilesNames.ToArray(typeof(string)));
        }
        string[] cargarNombresArchivos(string[] SourceFiles, int numeroDocumentos)
        {
            if (SourceFiles.Length < numeroDocumentos)
            { numeroDocumentos = SourceFiles.Length; }
            string[] temp = new string[numeroDocumentos];
            for (int index = 0; index < numeroDocumentos; index++)
            {
                temp[index] = SourceFiles[index];
            }
            return temp;
        }
        string[] NombresArchivosComplemento(string[] SourceFilesA, string[] SourceFilesB)
        {
            List<string> listaA = SourceFilesA.ToList<string>();

            for (int j = 0; j < SourceFilesB.Length; j++)
            {
                listaA.Remove(SourceFilesB[j]);
            }
            return listaA.ToArray();

        }
        public FormPrincipal()
        {
            InitializeComponent();
        }
       
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                CargarAppConfig();
            }
            catch (Exception error)
            {
                MessageBox.Show(String.Format("Error al leer el archivo de configuración de la aplicación {0}",error.Message), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void CargarAppConfig()
        {
            this.checkBoxAutoArranque.Checked =FormPrincipal.autoarranque;
            this.checkBoxDeskew.Checked = FormPrincipal.enderezamiento;
            this.checkBoxMoverDoc.Checked = FormPrincipal.moverdocumentos;
        }
        public void CargarRutaPrincipal(string unaruta)
        {
            this.fileQuipuxWatcher.Path = unaruta;
        }

        private void fileQuipuxWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
           
        }

        private void fileQuipuxWatcher_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void fileQuipuxWatcher_Renamed(object sender, System.IO.RenamedEventArgs e)
        {

        }

        private void fileQuipuxWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }
        List<ArchivoProceso> lista = new List<ArchivoProceso>();
        DateTime fechainicio = new DateTime();
        private void buttonStart_Click(object sender, EventArgs e)
        {
            Procesar();
            
        }
        public void Procesar()
        {
            try
            {
                finalizo = false;
                this.timerAutoArranque.Enabled = false;
                this.nhilos = 0;
                this.narchivos = 0;
                this.nexitos = 0;
                this.nfracasos = 0;
                this.npaginas = 0;
                this.listaproceso = new List<ArchivoProceso>();
                fechainicio = DateTime.Now;
                this.listBoxProcesados.Items.Clear();
                lista = new List<ArchivoProceso>();
                this.progressBarProcesados.Value = 0;
                this.progressBarProcesados.Maximum = 0;
                Start();
                OnStart();
                if (this.lista.Count == 0)
                {
                    if (this.checkBoxAutoArranque.Checked)
                    {
                        finalizo = true;
                        this.timerAutoArranque.Enabled = true;
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Start()
        {
            try
            {
                this.timerRevisaProcesados.Enabled = false;
                CargaValidacionFicheros();
                DistribucionDeFicheros();
                this.narchivos = this.progressBarProcesados.Maximum;
                this.timerRevisaProcesados.Enabled = true;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void CargaValidacionFicheros()
        {
            
            FormProgresBar progbar = new FormProgresBar();
            DataSetRuta.rutaDataTable tablarutas = adaptadorruta.GetDataByRutasPrinBatchOcr();
            foreach (DataSetRuta.rutaRow filaruta in tablarutas)
            {
                string[] sourceFilesDir = this.cargarNombresArchivos(filaruta.ru_path);

                progbar.MaxValor = sourceFilesDir.Length;
                progbar.ListaDirectorio = sourceFilesDir;
                progbar.RutaFiles = filaruta.ru_path;
                progbar.IniciaBack();
                progbar.ShowDialog();
                if (progbar.ExisteError)
                {
                    if (progbar.ExtensionError != "")
                    {
                        MessageBox.Show("No se ha definido el Tipo documental " + progbar.ExtensionError);
                    }
                }
                DataSetBatchOcr.batch_ocrDataTable tablabatch = adaptadorbatch_ocr.GetDataByProcesoPorRutaPrin(filaruta.ru_id);
                foreach (DataSetBatchOcr.batch_ocrRow filabatch in tablabatch)
                {
                    for (int i = 0; i < sourceFilesDir.Length; i++)
                    {
                        lista.Add(new ArchivoProceso(sourceFilesDir[i], filabatch.ba_ocr_id, filaruta.ru_path,filabatch.ba_ocr_descripcion,i,0));
                    }
                }
            }
            this.progressBarProcesados.Maximum+= lista.Count;
        }
        List<ArchivoProceso> listaproceso = new List<ArchivoProceso>();
       
        public void DistribucionDeFicheros()
        {
            DataSetBatchOcr.batch_ocrDataTable tablabatch = adaptadorbatch_ocr.GetDataByBatchAsignados();
            foreach (DataSetBatchOcr.batch_ocrRow filabatch in tablabatch)
            {
                int nrutas = 0;
                TimeSpan horainicio=(TimeSpan)filabatch.ba_ocr_horainicio.TimeOfDay;
                TimeSpan horaactual=(TimeSpan)DateTime.Now.TimeOfDay;
                TimeSpan horafin = (TimeSpan)filabatch.ba_ocr_horafin.TimeOfDay;
                bool procesar = false;
                if (horainicio < horafin)
                {
                    if (horainicio < horaactual && horaactual < horafin)
                    {
                        procesar = true;
                    }
                }
                else
                {
                    if (horainicio < horaactual && horaactual > horafin)
                    {
                        procesar = true;
                    }
                    if (horaactual < horainicio && horaactual < horafin)
                    {
                        procesar = true;
                    }
                }
                
                if (horainicio==horafin | procesar)
                {
                    List<ArchivoProceso> listatemp = new List<ArchivoProceso>();

                    Predicate<ArchivoProceso> predicate = value => value.Proceso.Equals(filabatch.ba_ocr_id);
                    listatemp = lista.FindAll(predicate);
                    int nfiles = (filabatch.ba_ocr_nlotes <= listatemp.Count) ? filabatch.ba_ocr_nlotes : listatemp.Count;
                    List<string> listaxml = new List<string>();
                    for (int c = 0; c < nfiles; c++)
                    {
                        listatemp[c].SecProceso = c;
                        listaproceso.Add(listatemp[c]);
                        FileInfo info = new FileInfo(Path.Combine(listatemp[c].RutaPrincipal, listatemp[c].Nombre));
                        string nombretemp = info.Name.Replace(info.Extension, ".xml").Replace(" ", "");
                        string nombrexml = XmlOcr.InicializarXmlConfiguracion(listatemp[c].RutaPrincipal, nombretemp);
                        XmlOcr.ConfiguracionCabecera(nombrexml, info.Name,this.checkBoxDeskew.Checked, listatemp[c].DescripcionProceso, c, listatemp[c].RutaPrincipal);
                        DataSetRuta.rutaDataTable tablarutassec = adaptadorruta.GetDataByRutaSecBatch_Ocr(listatemp[c].Proceso);
                   
                        for (int k = 0; k < tablarutassec.Count; k++)
                        {
                            if (tablarutassec[k].ru_activa)
                            {
                                nrutas++;
                                XmlOcr.ConfiguracionRutas(nombrexml, k, tablarutassec[k].ru_path, tablarutassec[k].tip_extension.ToLower());
                            }
                        }
                        if (nrutas > 0)
                        {
                            listaxml.Add(nombrexml);
                            Predicate<ArchivoProceso> premove = value => value.SecArchivo.Equals(listatemp[c].SecArchivo) && value.Proceso.Equals(listatemp[c].Proceso) && value.Nombre.Equals(listatemp[c].Nombre) && value.RutaPrincipal.Equals(listatemp[c].RutaPrincipal);
                            lista.Remove(lista.Find(premove));
                        }
                    }
                    if (nrutas > 0)
                    {
                        for (int i = 0; i < nfiles; i++)
                        {
                            ProcessStartInfo startInfo = new ProcessStartInfo();
                            startInfo.FileName = filabatch.ba_ocr_path;
                            startInfo.Arguments = listaxml[i];
                            Process process = new Process();
                            process.StartInfo = startInfo;
                            process.Start();
                            listaproceso[i].Process = process;
                        }
                    }
                }
                
            }
        }

        private void timerRevisaProcesados_Tick(object sender, EventArgs e)
        {
            try
            {

                timerRevisaProcesados.Enabled = false;
                List<ArchivoProceso> listatemp = listaproceso;

                if (listatemp != null)
                {
                    int nfilesproces = listatemp.Count;

                    for (int c = 0; c < nfilesproces; c++)
                    {

                        if (lista.Count > 0 && lista.Contains(listaproceso[c]))
                        {
                            lista.Remove(listaproceso[c]);
                            break;
                        }

                        ArchivoProceso archivo = listaproceso[c];


                        FileInfo info = new FileInfo(Path.Combine(archivo.RutaPrincipal, archivo.Nombre));
                        string nombre = "XA" + info.Name.Replace(info.Extension, ".xml");
                        if (File.Exists(Path.Combine(info.DirectoryName, nombre)))
                        {
                            string pathxmlxa = Path.Combine(info.DirectoryName, nombre);
                            while (IsFileLocked(new FileInfo(pathxmlxa)))
                            {
                                continue;
                            }
                            //Info progreso

                            //listBox.Items.Add(listatemp[c].Nombre);

                            ThreadStart _ts = delegate
                            {
                                GuardarXmlBase(archivo);

                            };
                            Thread mainTableGetter = new Thread(_ts);
                            mainTableGetter.Name = "OCRGuardarXML";
                            mainTableGetter.Start();


                            DataSetBatchOcr.batch_ocrRow filabatch = adaptadorbatch_ocr.GetDataByBuscarBatchOcr(archivo.Proceso)[0];
                            TimeSpan horainicio = (TimeSpan)filabatch.ba_ocr_horainicio.TimeOfDay;
                            TimeSpan horaactual = (TimeSpan)DateTime.Now.TimeOfDay;
                            TimeSpan horafin = (TimeSpan)filabatch.ba_ocr_horafin.TimeOfDay;
                            bool procesar = false;
                            if (horainicio < horafin)
                            {
                                if (horainicio < horaactual && horaactual < horafin)
                                {
                                    procesar = true;
                                }
                            }
                            else
                            {
                                if (horainicio < horaactual && horaactual > horafin)
                                {
                                    procesar = true;
                                }
                                if (horaactual < horainicio && horaactual < horafin)
                                {
                                    procesar = true;
                                }
                            }

                            if (horainicio == horafin | procesar)
                            {

                                ArchivoProceso temp = archivo;
                                Predicate<ArchivoProceso> premoveproc = value => value.SecArchivo.Equals(archivo.SecArchivo) && value.Proceso.Equals(archivo.Proceso) && value.Nombre.Equals(archivo.Nombre) && value.RutaPrincipal.Equals(archivo.RutaPrincipal);
                                listatemp.Remove(listatemp.Find(premoveproc));

                                Predicate<ArchivoProceso> predicate = value => value.Proceso.Equals(archivo.Proceso);
                                ArchivoProceso archivotemp = lista.Find(predicate);
                                if (archivotemp != null)
                                {
                                    archivotemp.SecProceso = temp.SecProceso;

                                    Predicate<ArchivoProceso> premove = value => value.SecArchivo.Equals(archivotemp.SecArchivo) && value.Proceso.Equals(archivotemp.Proceso) && value.Nombre.Equals(archivotemp.Nombre) && value.RutaPrincipal.Equals(archivotemp.RutaPrincipal);
                                    lista.Remove(lista.Find(premove));
                                    FileInfo infotemp = new FileInfo(Path.Combine(archivotemp.RutaPrincipal, archivotemp.Nombre));
                                    string nombretemp = infotemp.Name.Replace(infotemp.Extension, ".xml").Replace(" ", "");

                                    string nombrexml = XmlOcr.InicializarXmlConfiguracion(archivotemp.RutaPrincipal, nombretemp);
                                    XmlOcr.ConfiguracionCabecera(nombrexml, infotemp.Name, false, archivotemp.DescripcionProceso, temp.SecProceso, archivotemp.RutaPrincipal);
                                    DataSetRuta.rutaDataTable tablarutassec = adaptadorruta.GetDataByRutaSecBatch_Ocr(archivotemp.Proceso);
                                    int nrutas = 0;
                                    for (int k = 0; k < tablarutassec.Count; k++)
                                    {
                                        if (tablarutassec[k].ru_activa)
                                        {
                                            nrutas++;
                                            XmlOcr.ConfiguracionRutas(nombrexml, k, tablarutassec[k].ru_path, tablarutassec[k].tip_extension.ToLower());
                                        }
                                    }
                                    if (nrutas > 0)
                                    {
                                        ProcessStartInfo startInfo = new ProcessStartInfo();
                                        startInfo.FileName = filabatch.ba_ocr_path;
                                        startInfo.Arguments = nombrexml;
                                        Process process = new Process();
                                        process.StartInfo = startInfo;
                                        process.Start();
                                        archivotemp.Process = process;
                                        listatemp.Add(archivotemp);
                                        listaproceso = new List<ArchivoProceso>();
                                        listaproceso = listatemp;
                                    }
                                    //lista.Remove(listaproceso[c]);

                                }
                                break;
                            }

                        }

                    }
                    timerRevisaProcesados.Enabled = true;

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }

        private void listBoxProcesados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonDetener_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkBoxAutoArranque.Checked)
                {
                    this.Detener();
                }
                else
                {
                    MessageBox.Show("Primero debe desactivar la casilla Auto Arranque.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Detener()
        {
            try
            {
                this.timerRevisaProcesados.Enabled = false;
                for (int i = 0; i < listaproceso.Count; i++)
                {
                    if (listaproceso[i].Process != null)
                    {
                        if (!listaproceso[i].Process.HasExited)
                        {
                            listaproceso[i].Process.Kill();
                        }
                    }

                }
                this.listaproceso = new List<ArchivoProceso>();
                this.lista = new List<ArchivoProceso>();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        volatile bool finalizo= true;
        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }
        public void GuardarXmlBase(ArchivoProceso archivo)
        {
            lock (abortedLockObject)
            {
                nhilos++;
                blockThread.WaitOne();
                finalizo = false;
                FileInfo info = new FileInfo(archivo.Nombre);
               

                int radicado = 0;
                try
                {
                    
                    radicado = (int)adaptadorradicado.QueryBuscarRadicado(info.DirectoryName, info.Name);
                    string filenombre = info.Name.Replace(info.Extension, "");
                    string temp = info.Name.Replace(info.Extension, "");
                    string nombredirxml = Path.Combine(archivo.RutaPrincipal, temp);
                    List<string> filesxml = new List<string>(Directory.GetFiles(nombredirxml, filenombre + "_pag*.xml"));

                    for (int i = 0; i < filesxml.Count; i++)
                    {
                        Predicate<string> predicate = value => value.Contains(filenombre + "_pag" + i.ToString() + ".xml");
                        string nombrexmlpag = Path.Combine(info.DirectoryName, filesxml.Find(predicate));
                        DataSetOcr_Pagina.ocr_paginaRow pagina = XmlParser.ParseXPagXmlOcr_Pagina(nombrexmlpag, radicado, archivo.Proceso);
                        adaptadorocr_pagina.InsertOcr_Pagina(pagina.ocr_pag_nume_radi, pagina.ocr_pag_batch_ocr, pagina.ocr_pag_fechainiproces, pagina.ocr_pag_fechafinproces,
                            pagina.ocr_pag_nlineas, pagina.ocr_pag_npalabras, pagina.ocr_pag_ncaracteres, pagina.ocr_pag_secpagina);
                        List<DataSetOcr_Linea.ocr_lineaRow> listalineas = XmlParser.ParseXPagXmlOcr(nombrexmlpag, radicado, archivo.Proceso, pagina.ocr_pag_secpagina);
                        foreach (DataSetOcr_Linea.ocr_lineaRow filalinea in listalineas)
                        {
                            adaptadorocr_linea.InsertOcr_Linea(filalinea.ocr_lin_nume_radi, filalinea.ocr_lin_batch_ocr, filalinea.ocr_lin_pag_secpagina, filalinea.ocr_lin_texto, (decimal)filalinea.ocr_lin_confidence,
                                filalinea.ocr_lin_blanks, filalinea.ocr_lin_lineaocr, filalinea.ocr_lin_linea, filalinea.ocr_lin_fuente, filalinea.ocr_lin_pointsize, filalinea.ocr_lin_tipodato,
                                filalinea.ocr_lin_secpalabra, (decimal)filalinea.ocr_lin_x, (decimal)filalinea.ocr_lin_y, (decimal)filalinea.ocr_lin_ancho, (decimal)filalinea.ocr_lin_largo);
                        }
                    }
                    string nombrexmlxa = Path.Combine(info.DirectoryName, "XA" + info.Name.Replace(info.Extension, ".xml"));
                    int contador = 0;
                    FileInfo infoxmlxa = new FileInfo(nombrexmlxa);
                    while (IsFileLocked(infoxmlxa) && contador < 3)
                    {
                        Thread.Sleep(1000);
                        contador++;
                    }
                    DataSetOcr.ocrRow ocr = XmlParser.ParseXAXmlOcr(nombrexmlxa, radicado, archivo.Proceso);

                    ocr.ocr_texto = "SINTEXTO";


                    adaptadorocr.InsertOcr(ocr.ocr_nume_radi, ocr.ocr_batch_ocr, ocr.ocr_fechamodificacion, ocr.ocr_fechacreacion, ocr.ocr_directorio,
                        ocr.ocr_nombre, ocr.ocr_profundidadbits, (decimal)ocr.ocr_horizontal, (decimal)ocr.ocr_vertical, (decimal)ocr.ocr_alto, (decimal)ocr.ocr_ancho, ocr.ocr_estado,
                        ocr.ocr_fechainiproces, ocr.ocr_fechafinproces, ocr.ocr_npaginas, ocr.ocr_npalabras, ocr.ocr_ncaracteres,
                        ocr.ocr_nlineas, ocr.ocr_texto, ocr.ocr_tipo_documental, ocr.ocr_tipo_documental_valor, ocr.ocr_tamanio);
                    if (ocr.ocr_estado)
                    {
                        string nombrexmlxp = Path.Combine(info.DirectoryName, "XP" + info.Name.Replace(info.Extension, ".xml"));
                        List<DataSetOcr_Exportado.ocr_exportadoRow> listaexp = XmlParser.ParseXPXmlOcr_Pagina(nombrexmlxp, radicado, archivo.Proceso);

                        foreach (DataSetOcr_Exportado.ocr_exportadoRow filaexp in listaexp)
                        {
                            adaptadorocr_exportado.InsertOcr_Exportado(filaexp.ocr_exp_ruta, filaexp.ocr_exp_batch_ocr, filaexp.ocr_exp_nume_radi, filaexp.ocr_exp_tamanio, filaexp.ocr_exp_path,
                                filaexp.ocr_exp_tipo_documental, filaexp.ocr_exp_tipo_documental_valor);

                        }

                        this.npaginas += ocr.ocr_npaginas;
                        string nombrexmlxe = Path.Combine(info.DirectoryName, "XE" + info.Name.Replace(info.Extension, ".xml"));
                        List<EstadisticaProcesamiento> listaest = Serealizar.DeserializeFromXML(nombrexmlxe);
                        foreach (EstadisticaProcesamiento filaest in listaest)
                        {
                            adaptadorocr_estadisticas.InsertOcr_Estadisticas(radicado, archivo.Proceso, (decimal)filaest.MemoriaTotal, (decimal)filaest.MemoriaCache,
                                (decimal)filaest.MemoriaDisponible, (decimal)filaest.MemoriaLibre, (decimal)filaest.MemKernelPaginado, (decimal)filaest.MemKernelNoPaginado,
                                (decimal)filaest.Identificadores, (decimal)filaest.Subprocesos, (decimal)filaest.PorcentajeUsoCPU, (decimal)filaest.PromedioLecuraDisco,
                                (decimal)filaest.PromedioEscrituraDisco, filaest.FechaProsesamiento, filaest.HoraProcesamiento, (decimal)filaest.EspacioEnDisco, (decimal)filaest.TamanioDisco);


                        }
                        List<string> listarutas = new List<string>();
                        List<string> listaformatosexp = new List<string>();
                        DataSetBatchOcr.batch_ocrRow filabatch = adaptadorbatch_ocr.GetDataByBuscarBatchOcr(archivo.Proceso)[0];
                        DataSetRuta.rutaDataTable tablarutassec = adaptadorruta.GetDataByRutaSecBatch_Ocr(archivo.Proceso);
                        for (int k = 0; k < tablarutassec.Count; k++)
                        {
                            listarutas.Add(tablarutassec[k].ru_path);
                            listaformatosexp.Add(tablarutassec[k].tip_extension);
                        }

                        OnSuccessFile(archivo.RutaPrincipal, filabatch.ba_ocr_path, listarutas, listaformatosexp, info.Name, ocr.ocr_fechamodificacion, ocr.ocr_fechacreacion, ocr.ocr_profundidadbits, ocr.ocr_fechainiproces, ocr.ocr_fechafinproces,
                            archivo.Proceso, ocr.ocr_npaginas, ocr.ocr_ncaracteres, ocr.ocr_npalabras, ocr.ocr_nlineas, ocr.ocr_horizontal, ocr.ocr_vertical);
                        OnSuccess(info);

                    }
                    else
                    {
                        
                        ocr = new DataSetOcr.ocrDataTable().NewocrRow();

                        ocr.ocr_texto = "SINTEXTO";
                        ocr.ocr_estado = false;
                        string extencion = info.Extension.Replace(".", "").ToUpper();
                        int idextencion = 0;
                        idextencion = (int)adaptadortipo_documental.FillByTipoExtencion(extencion);
                        

                        adaptadorocr.InsertOcr(radicado, archivo.Proceso, ocr.ocr_fechamodificacion, ocr.ocr_fechacreacion, info.DirectoryName,
                            info.Name, ocr.ocr_profundidadbits, (decimal)ocr.ocr_horizontal, (decimal)ocr.ocr_vertical, (decimal)ocr.ocr_alto, (decimal)ocr.ocr_ancho, ocr.ocr_estado,
                            ocr.ocr_fechainiproces, ocr.ocr_fechafinproces, ocr.ocr_npaginas, ocr.ocr_npalabras, ocr.ocr_ncaracteres,
                            ocr.ocr_nlineas, ocr.ocr_texto,idextencion, extencion, ocr.ocr_tamanio);
                          OnError(info);
                    }

                }
                catch
                {
                    try
                    {
                        
                        string extencion = info.Extension.Replace(".", "").ToUpper();
                        int idextencion = 0;
                        idextencion = (int)adaptadortipo_documental.FillByTipoExtencion(extencion);


                        adaptadorocr.InsertOcr(radicado, archivo.Proceso, DateTime.Now, DateTime.Now, info.DirectoryName,
                            info.Name, 0, 0, 0, 0, 0, false, DateTime.Now, DateTime.Now, 0, 0, 0, 0, "SINTEXTO"
                            , idextencion, extencion,0);
                          //    OnError(info);
                    }
                    catch 
                    {

                    }
                    finally
                    {
                        OnError(info);
                    }
                }
                finally {
                    finalizo = true;
                    blockThread.Set();
                    nhilos--;
                }
            }

        }
        private void OnSuccessFile(string rutaorigen,string rutaproceso,List<string> rutasdestino,List<string> formatosexportacion,string nombrearchivo,
            DateTime fechamodificacion,DateTime fechacreacion,int profundidadenbits,DateTime fechainiproceso,DateTime fechafinproceso,int idproceso,
            int npaginas,int ncaracteres,int npalabras,int nlineas,float horizontal,float vertical)
        {
            try
            {
                this.BeginInvoke(new MethodInvoker(delegate()
                {
                    this.listBoxFormatosExportacion.Items.Clear();
                    this.listBoxRutasDestino.Items.Clear();
                    this.textBoxRutaOrigen.Text = rutaorigen;
                    this.textBoxRutaProceso.Text = rutaproceso;
                    this.listBoxRutasDestino.Items.AddRange(rutasdestino.ToArray());
                    this.listBoxFormatosExportacion.Items.AddRange(formatosexportacion.ToArray());
                    this.labelANombre.Text = nombrearchivo;
                    this.maskedTextBoxAFmodificacion.Text = fechamodificacion.ToString();
                    this.maskedTextBoxAFCreacion.Text = fechacreacion.ToString();
                    this.labelAProfundidadBits.Text = profundidadenbits.ToString();
                    this.maskedTextBoxPFinProceso.Text = fechafinproceso.ToString();
                    this.maskedTextBoxPInicioProceso.Text = fechainiproceso.ToString();
                    this.labelPIdproceso.Text = idproceso.ToString();
                    this.labelANpaginas.Text = npaginas.ToString();
                    this.labelANpalabras.Text = npalabras.ToString();
                    this.labelANlineas.Text = nlineas.ToString();
                    this.labelANcaracteres.Text = ncaracteres.ToString();
                    this.labelAHorizontal.Text = horizontal.ToString();
                    this.labelAVertical.Text = vertical.ToString();
                }));
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OnStart()
        {
            try
            {
                this.BeginInvoke(new MethodInvoker(delegate()
                {
                    if (this.narchivos > 0)
                    {
                        this.labelnrarchivos.Text = this.narchivos.ToString();
                        this.labelnprocesados.Text = this.nexitos.ToString();
                        this.labelporprocesados.Text = (double)(this.nexitos * 100 / this.narchivos) + "%";
                        this.labelpornoprocesados.Text = (double)((this.nfracasos) * 100 / this.narchivos) + "%";
                        this.labelnpaginas.Text = this.npaginas.ToString();
                        this.labeldias.Text = DateTime.Now.Subtract(fechainicio).Days.ToString();
                        this.labelhoras.Text = DateTime.Now.Subtract(fechainicio).Hours.ToString();
                        this.labelminutos.Text = DateTime.Now.Subtract(fechainicio).Minutes.ToString();
                        this.labelsegundos.Text = DateTime.Now.Subtract(fechainicio).Seconds.ToString();
                    }

                }));
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OnSuccess(FileInfo uinfo)
        {
            try
            {
                this.BeginInvoke(new MethodInvoker(delegate()
                {
                    this.nexitos++;
                    this.labelnrarchivos.Text = this.narchivos.ToString();
                    this.labelnprocesados.Text = this.nexitos.ToString();
                    this.labelporprocesados.Text = Math.Round(((double)this.nexitos * 100 / (double)this.narchivos),2) + "%";
                    this.labelpornoprocesados.Text = Math.Round(((double)(this.nfracasos) * 100 / (double)this.narchivos),2) + "%";
                    this.labelnpaginas.Text = this.npaginas.ToString();
                    this.labeldias.Text = DateTime.Now.Subtract(fechainicio).Days.ToString();
                    this.labelhoras.Text = DateTime.Now.Subtract(fechainicio).Hours.ToString();
                    this.labelminutos.Text = DateTime.Now.Subtract(fechainicio).Minutes.ToString();
                    this.labelsegundos.Text = DateTime.Now.Subtract(fechainicio).Seconds.ToString();
                    this.progressBarProcesados.Value++;
                    this.listBoxProcesados.Items.Add(uinfo.Name);
                    if (this.checkBoxMoverDoc.Checked)
                    {
                        MoverDoc(uinfo, true);
                    }
                    if (listaproceso.Count == 0)
                    {

                        if (!this.checkBoxAutoArranque.Checked)
                        {
                            if (nhilos == 0)
                            {
                                MessageBox.Show("Proceso Terminado con Exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            if (this.lista.Count == 0)
                            {
                                if (nhilos == 0)
                                {
                                    this.timerAutoArranque.Enabled = true;
                                }
                            }
                        }
                    }

                }));
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void MoverDoc(FileInfo uinfo,bool procesado)
        {
            try
            {
                if (this.checkBoxMoverDoc.Checked)
                {
                    string rutaprocesados=ClassAppAplicacion.GetProcesadosOcr();
                    string rutanoprocesados = ClassAppAplicacion.GetNoProcesadosOcr();
                    if (procesado)
                    {
                        string dirname = uinfo.DirectoryName + rutaprocesados;
                        if (!Directory.Exists(dirname))
                        {
                            Directory.CreateDirectory(dirname);
                        }
                        string dirpro=uinfo.DirectoryName+ rutaprocesados;
                        File.Copy(uinfo.FullName, Path.Combine(dirpro, uinfo.Name),true);
                        string folderxml="\\"+uinfo.Name.Replace(uinfo.Extension,"");
                        string xmldir=uinfo.DirectoryName+folderxml;
                        string xmldestino= uinfo.DirectoryName+ClassAppAplicacion.GetXMLProcesados();
                        MoverDirectorio(xmldir, xmldestino, folderxml);
                        MoverArchivosConfiguracion(uinfo, xmldestino);
                        Directory.Delete(xmldir, true);
                        File.Delete(uinfo.FullName);
                    }
                    else
                    {
                        string dirnopro = uinfo.DirectoryName+ rutanoprocesados;
                        if (!Directory.Exists(dirnopro))
                        {
                             Directory.CreateDirectory(dirnopro);
                        }
                        
                        File.Copy(uinfo.FullName, Path.Combine(dirnopro, uinfo.Name), true);
                        string folderxml = "\\" + uinfo.Name.Replace(uinfo.Extension, "");
                        string xmldir = uinfo.DirectoryName + folderxml;
                        string xmldestino = uinfo.DirectoryName + ClassAppAplicacion.GetXMLProcesados();
                        MoverDirectorio(xmldir, xmldestino, folderxml);
                        MoverArchivosConfiguracion(uinfo, xmldestino);
                        Directory.Delete(xmldir, true);
                        File.Delete(uinfo.FullName);
                    }
                }
            }
            catch(Exception error) {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
        }
        public void MoverDirectorio(string uorigen,string udestino,string ufolder)
        {
            try
            {
                if (Directory.Exists(uorigen))
                {

                    string[] listafiles = Directory.GetFiles(uorigen, "*.*", SearchOption.TopDirectoryOnly);
                    if (listafiles.Length > 0)
                    {
                        if (!Directory.Exists(udestino))
                        {
                            Directory.CreateDirectory(udestino);
                        }

                        DirectoryInfo dir = new DirectoryInfo(udestino);
                        DirectoryInfo subdir = Directory.CreateDirectory(udestino + ufolder);
                        foreach (string filename in listafiles)
                        {
                            FileInfo info = new FileInfo(filename);
                            File.Copy(filename, Path.Combine(subdir.FullName, info.Name), true);
                            File.Delete(filename);
                        }


                    }

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public List<string> ListaArchivosConfiguracion(FileInfo uinfo)
        {
            List<string> lista = new List<string>();
            lista.Add("XC" + uinfo.Name.Replace(uinfo.Extension, ".xml"));
            lista.Add("XA" + uinfo.Name.Replace(uinfo.Extension, ".xml"));
            lista.Add("XE" + uinfo.Name.Replace(uinfo.Extension, ".xml"));
            lista.Add( "XP" + uinfo.Name.Replace(uinfo.Extension, ".xml"));
            return lista;
        }
        public void MoverArchivosConfiguracion(FileInfo info, string udestion)
        {
            try
            {
                List<string> listaxml = ListaArchivosConfiguracion(info);
                foreach (string filexml in listaxml)
                {
                    if (File.Exists(Path.Combine(info.DirectoryName, filexml)))
                    {
                        File.Copy(Path.Combine(info.DirectoryName, filexml), Path.Combine(udestion, filexml), true);
                        File.Delete(Path.Combine(info.DirectoryName, filexml));
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnError(FileInfo uinfo)
        {
            try
            {

                this.BeginInvoke(new MethodInvoker(delegate()
                {
                    this.nfracasos++;
                    this.labelnrarchivos.Text = this.narchivos.ToString();
                    this.labelnnoprocesados.Text = this.nfracasos.ToString();
                    this.labelporprocesados.Text = Math.Round(((double)this.nexitos * 100 / (double)this.narchivos), 2) + "%";
                    this.labelpornoprocesados.Text = Math.Round(((double)(this.nfracasos) * 100 / (double)this.narchivos), 2) + "%";
                    this.labelnpaginas.Text = this.npaginas.ToString();
                    this.labeldias.Text = DateTime.Now.Subtract(fechainicio).Days.ToString();
                    this.labelhoras.Text = DateTime.Now.Subtract(fechainicio).Hours.ToString();
                    this.labelminutos.Text = DateTime.Now.Subtract(fechainicio).Minutes.ToString();
                    this.labelsegundos.Text = DateTime.Now.Subtract(fechainicio).Seconds.ToString();
                    this.progressBarProcesados.Value++;
                    this.listBoxNoProcesados.Items.Add(uinfo.Name);
                    MoverDoc(uinfo, false);
                    if (listaproceso.Count == 0)
                    {
                        if (!this.checkBoxAutoArranque.Checked)
                        {
                            if (nhilos == 0)
                            {
                                this.timerRevisaProcesados.Enabled = false;
                                MessageBox.Show("Proceso Terminado con Exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            if (this.lista.Count == 0)
                            {
                                if (nhilos == 0)
                                {
                                    this.timerAutoArranque.Enabled = true;
                                }
                            }
                        }
                    }
                }));
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
               
        }

        private void timerCargarBase_Tick(object sender, EventArgs e)
        {

        }

        

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool error = false;
                error = ClassAppAplicacion.Guardar("AutoArranque", this.checkBoxAutoArranque.Checked.ToString());
                error = ClassAppAplicacion.Guardar("Deskew", this.checkBoxDeskew.Checked.ToString());
                error = ClassAppAplicacion.Guardar("MoverDoc", this.checkBoxMoverDoc.Checked.ToString());
                autoarranque = this.checkBoxAutoArranque.Checked;
                enderezamiento = this.checkBoxDeskew.Checked;
                moverdocumentos = this.checkBoxMoverDoc.Checked;
                if (!error)
                {
                    MessageBox.Show("Error al guardar en el archivo de configuración de la aplicación ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Configuración almacenada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timerAutoArranque_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.checkBoxAutoArranque.Checked)
                {
                    if (this.listaproceso.Count == 0 && this.lista.Count == 0 && finalizo && this.nhilos == 0)
                    {
                        Procesar();
                    }
                }
            }
            catch (Exception error)
            {
                timerAutoArranque.Enabled = false;
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxAutoArranque_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxAutoArranque.Checked)
            {
                this.timerAutoArranque.Enabled = true;
                this.buttonProcesar.Enabled = false;
            }
            else
            {
                this.timerAutoArranque.Enabled = false;
                this.buttonProcesar.Enabled = true;
            }
        }

        private void checkBoxDeskew_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBoxOcr_Enter(object sender, EventArgs e)
        {

        }

        private void groupBoxArhcivosProcesados_Enter(object sender, EventArgs e)
        {

        }

        private void groupBoxestado_Enter(object sender, EventArgs e)
        {

        }

        private void labelANpalabras_Click(object sender, EventArgs e)
        {

        }
        

    }
}
