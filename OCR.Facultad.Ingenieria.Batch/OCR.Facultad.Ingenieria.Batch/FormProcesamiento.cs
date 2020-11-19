using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using OCR.Facultad.Ingenieria.LibreriasOpenPDFOCR;
using System.IO;
using System.Threading;
using OCR.Facultad.Ingenieria.Batch.Util;
using System.Diagnostics;
using OCR.Facultad.Ingenieria.Estadisticas;
namespace OCR.Facultad.Ingenieria.Batch
{
    public partial class FormProcesamiento : Form
    {
        private System.Diagnostics.PerformanceCounter pMemoriaCache;
        private System.Diagnostics.PerformanceCounter pMemoriaDisponible;
        private System.Diagnostics.PerformanceCounter pMemoriaTotal;
        private System.Diagnostics.PerformanceCounter pMemKernelPaginado;
        private System.Diagnostics.PerformanceCounter pMemKernelNoPaginado;
        private System.Diagnostics.PerformanceCounter pIdentificadores;
        private System.Diagnostics.PerformanceCounter pSubprocesos;
        private System.Diagnostics.PerformanceCounter pPorcentajeUsoCPU;
        private System.Diagnostics.PerformanceCounter pPromedioLecuraDisco;
        private System.Diagnostics.PerformanceCounter pPromedioEscrituraDisco;
        
        public FormProcesamiento()
        {
            InitializeComponent();
            
        }
        string[] args;

        public string[] Args
        {
            get {
                return this.args;
            }
            set { this.args = value; }
        }
        Thread hiloProcesamiento;


        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult resul = openFileDialogArchivo.ShowDialog();
            if (resul == DialogResult.OK)
            {
                ProcesarArchivoOcrXml(openFileDialogArchivo.FileName, new FileInfo(openFileDialogArchivo.FileName).DirectoryName);
               
            }   
        }
        public void ProcesarArchivoOcrXml(string unombre,string unfolder)
        {
            try
            {
                ProcesoArchivo.nombrearchivo = new FileInfo(unombre).Name;
                hiloProcesamiento = new Thread((ThreadStart)delegate
                {
                    this.StatusBar_ShowInfo("Inicializando...");
                    PDFOCROptimized.ocr_fin_proceso += new SetFinProcesoOcr(PDFOCROptimized_ocr_fin_proceso);
                    PDFOCROptimized.ocr_info += new SetInfo(PDFOCROptimized_ocr_info);
                    PDFOCROptimized.ocr_maxvalue += new SetMaxValue(PDFOCROptimized_ocr_maxvalue);
                    PDFOCROptimized.ocr_porcentaje += new SetPercent(PDFOCROptimized_ocr_porcentaje);
                    PDFOCROptimized.ProcesarOCR(unombre, unfolder, configuracion.Proceso.Deskew);
                    PDFOCROptimized.ocr_porcentaje -= new SetPercent(PDFOCROptimized_ocr_porcentaje);
                    PDFOCROptimized.ocr_maxvalue -= new SetMaxValue(PDFOCROptimized_ocr_maxvalue);
                    PDFOCROptimized.ocr_info -= new SetInfo(PDFOCROptimized_ocr_info);
                    PDFOCROptimized.ocr_fin_proceso -= new SetFinProcesoOcr(PDFOCROptimized_ocr_fin_proceso);
                    SerealizarEstadisticasInfo();
                    this.StatusBar_ShowInfo("Finalizado");
                });
                hiloProcesamiento.Start();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                FileInfo file = new FileInfo(Path.Combine(ProcesoArchivo.directorio, ProcesoArchivo.nombrearchivo));
                string nombrexml = file.Name.Replace(file.Extension, ".xml");
                string nombrearchivoxml = XmlOcr.InicializarXmlArchivo(file.DirectoryName, nombrexml);
                XmlOcr.ArchivoOcr(nombrearchivoxml, 0, 0, 0, 0, DateTime.Now, DateTime.Now, false);
                this.Close();

            }
            

        }
        public void ProcesarArchivoOcrXml()
        {
            try
            {
                hiloProcesamiento = new Thread((ThreadStart)delegate
                {
                    this.StatusBar_ShowInfo("Inicializando...");
                    PDFOCROptimized.ocr_fin_proceso += new SetFinProcesoOcr(PDFOCROptimized_ocr_fin_proceso);
                    PDFOCROptimized.ocr_info += new SetInfo(PDFOCROptimized_ocr_info);
                    PDFOCROptimized.ocr_maxvalue += new SetMaxValue(PDFOCROptimized_ocr_maxvalue);
                    PDFOCROptimized.ocr_porcentaje += new SetPercent(PDFOCROptimized_ocr_porcentaje);
                    PDFOCROptimized.ProcesarOCR(ProcesoArchivo.nombrearchivo, ProcesoArchivo.nombrefolder, configuracion.Proceso.Deskew);
                    PDFOCROptimized.ocr_porcentaje -= new SetPercent(PDFOCROptimized_ocr_porcentaje);
                    PDFOCROptimized.ocr_maxvalue -= new SetMaxValue(PDFOCROptimized_ocr_maxvalue);
                    PDFOCROptimized.ocr_info -= new SetInfo(PDFOCROptimized_ocr_info);
                    PDFOCROptimized.ocr_fin_proceso -= new SetFinProcesoOcr(PDFOCROptimized_ocr_fin_proceso);
                    SerealizarEstadisticasInfo();
                    this.StatusBar_ShowInfo("Finalizado");
                    
                    
                });
                hiloProcesamiento.Start();
                hiloProcesamiento.Join();
                //this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                FileInfo file = new FileInfo(Path.Combine(ProcesoArchivo.directorio,ProcesoArchivo.nombrearchivo));
                string nombrexml = file.Name.Replace(file.Extension, ".xml");
                string nombrearchivoxml = XmlOcr.InicializarXmlArchivo(file.DirectoryName, nombrexml);
                XmlOcr.ArchivoOcr(nombrearchivoxml, 0, 0, 0, 0, DateTime.Now, DateTime.Now,false);
                this.Close();
 
            }


        }
        List<EstadisticaProcesamiento> listaestadisticas = new List<EstadisticaProcesamiento>();
        public void SerealizarEstadisticasInfo()
        {
            this.timerEstadisticas.Enabled = false;
            AddEstadistica();
            string nombrexmles=Path.Combine(ProcesoArchivo.directorio,"XE"+ProcesoArchivo.nombrearchivo.Replace(ProcesoArchivo.extencion,".xml"));
            Serealizar.SerializeToXML(listaestadisticas,nombrexmles);
        }
        public void AddEstadistica()
        {
            if (enablePerformance)
            {
                var pcinfo = new Microsoft.VisualBasic.Devices.ComputerInfo();
                long memoriatotal = (long)pcinfo.TotalPhysicalMemory / MBVALUE;

                long memoriacache = this.pMemoriaCache.RawValue / MBVALUE;
                long memoriadisponible = this.pMemoriaDisponible.RawValue / MBVALUE;
                long memorialibre = memoriatotal - memoriadisponible;
                long memkernelpaginado = (long)this.pMemKernelPaginado.NextValue() / MBVALUE;
                long memkernelnopaginado = (long)this.pMemKernelNoPaginado.NextValue() / MBVALUE;
                long identificadores = this.pIdentificadores.RawValue;
                long subprocesos = this.pSubprocesos.RawValue;
                long porcentajeusocpu = (long)this.pPorcentajeUsoCPU.NextValue();
                long promediolecuradisco = (long)this.pPromedioLecuraDisco.RawValue / MBVALUE;
                long promedioescrituradisco = (long)this.pPromedioEscrituraDisco.RawValue / MBVALUE;
                long espacioendisco = 0;
                long tamaniodisco = 0;
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo d in drives)
                {
                    if (d.RootDirectory.Name == ProcesoArchivo.root)
                    {
                        tamaniodisco = d.TotalSize / GBVALUE;
                        espacioendisco = d.TotalFreeSpace / GBVALUE;

                    }
                }

                listaestadisticas.Add(new EstadisticaProcesamiento(memoriatotal, memoriacache, memoriadisponible, memorialibre,
                    memkernelpaginado, memkernelnopaginado, identificadores, subprocesos, porcentajeusocpu, promediolecuradisco, promedioescrituradisco, DateTime.Now, DateTime.Now.TimeOfDay, espacioendisco, tamaniodisco));
            }
            else
            {
                listaestadisticas.Add(new EstadisticaProcesamiento());
            }
        }
        void PDFOCROptimized_ocr_fin_proceso(bool uerror)
        {
            try
            {
                if (!uerror)
                {
                    List<ArchivoProceso> listaarchivos = new List<ArchivoProceso>();
                    if (configuracion.Listarutas.Count > 0)
                    {
                        int sec = 0;
                        foreach (RutaExportacion ruta in configuracion.Listarutas)
                        {
                            string tempname = ProcesoArchivo.nombrearchivo.Replace(ProcesoArchivo.formatoarchivo, "." + ruta.Formato);
                            listaarchivos.Add(new ArchivoProceso(Path.Combine(ruta.Pathdestino, tempname), new FormatoExp(sec++, ruta.Formato)));
                        }

                        int val = PDFOCROptimized.ExportarFormato(Path.Combine(configuracion.Proceso.Pathorigen, ProcesoArchivo.nombrearchivo), ProcesoArchivo.nombrefolder, new Proceso(ProcesoArchivo.idproceso, true), listaarchivos, configuracion.Proceso.Deskew);
                        if (val == -1)
                        {
                            throw new Exception(String.Format("Error al Exportar el documento {0}\\{1}",ProcesoArchivo.directorio,ProcesoArchivo.nombrearchivo) );
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                FileInfo file = new FileInfo(Path.Combine(ProcesoArchivo.directorio, ProcesoArchivo.nombrearchivo));
                string nombrexml = file.Name.Replace(file.Extension, ".xml");
                string nombrearchivoxml = XmlOcr.InicializarXmlArchivo(file.DirectoryName, nombrexml);
                XmlOcr.ArchivoOcr(nombrearchivoxml, 0, 0, 0, 0, DateTime.Now, DateTime.Now, false);
                this.Close();

            }
        }

        void PDFOCROptimized_ocr_info(int npagina,string ninfo)
        {
            this.BeginInvoke(new MethodInvoker(delegate()
            {
                if (npagina > 0)
                    this.statusBarOcr.Text = string.Format(ProcesoArchivo.mensajeinfo, npagina, ninfo);
                else
                    this.statusBarOcr.Text = ninfo;
            }));
          
        }
        void PDFOCROptimized_ocr_maxvalue(int maxvalue)
        {
            this.BeginInvoke(new MethodInvoker(delegate()
            {
                progressBarOcr.Maximum = maxvalue;
                ProcesoArchivo.paginas = maxvalue;
            }));
        }
        void PDFOCROptimized_ocr_porcentaje(int percent)
        {
            this.BeginInvoke(new MethodInvoker(delegate()
               {
                   progressBarOcr.Value = percent;
                   Titulo_ShowInfo(percent);
                   ProcesoArchivo.pagina = percent;                  
               }));
           
        
        }
        void StatusBar_ShowInfo(string mensaje)
        {
            this.BeginInvoke(new MethodInvoker(delegate()
            {
                this.statusBarOcr.Text = mensaje;
                if (mensaje == "Finalizado")
                {
                    this.Close();
                }
            }));
        }

        void Titulo_ShowInfo(int npagina)
        {
            this.BeginInvoke(new MethodInvoker(delegate()
            {
                decimal porcentaje = Math.Round(Convert.ToDecimal(100 * npagina) / Convert.ToDecimal(ProcesoArchivo.paginas), 2);
                Object[]argsmensaje=new object[4];
                argsmensaje[0] = ProcesoArchivo.nombrearchivo;
                argsmensaje[1] = npagina;
                argsmensaje[2] = ProcesoArchivo.paginas;
                argsmensaje[3] = porcentaje;
                this.Text = string.Format(ProcesoArchivo.mensajetitulo, argsmensaje);
            }));
        }
        void Titulo_ShowInfoNombre()
        {
            this.BeginInvoke(new MethodInvoker(delegate()
            {
                this.Text = string.Format(ProcesoArchivo.mensajetitulonombre, ProcesoArchivo.nombrearchivo);
            }));
        }
        void Titulo_ShowInfoProceso()
        {
            this.BeginInvoke(new MethodInvoker(delegate()
            {
                this.labelIdProceso.Text = string.Format(ProcesoArchivo.mensajeproceso, ProcesoArchivo.idproceso);
            }));
        }
        ConfiguracionProceso configuracion;
        static bool enablePerformance;
        private void FormProcesamiento_Load(object sender, EventArgs e)
        {
           
            enablePerformance = (ClassAppAplicacion.GetEnablePerformance().ToLower() == "yes" | ClassAppAplicacion.GetEnablePerformance().ToLower() == "si") ? true : false;
            try
            {
                if (!Directory.Exists("temptif"))
                {
                    Directory.CreateDirectory("temptif");
                }
                if (enablePerformance)
                {

                    this.pMemoriaCache = new System.Diagnostics.PerformanceCounter();
                    this.pMemoriaDisponible = new System.Diagnostics.PerformanceCounter();
                    this.pMemoriaTotal = new System.Diagnostics.PerformanceCounter();
                    this.pMemKernelPaginado = new System.Diagnostics.PerformanceCounter();
                    this.pMemKernelNoPaginado = new System.Diagnostics.PerformanceCounter();
                    this.pIdentificadores = new System.Diagnostics.PerformanceCounter();
                    this.pSubprocesos = new System.Diagnostics.PerformanceCounter();
                    this.pPorcentajeUsoCPU = new System.Diagnostics.PerformanceCounter();
                    this.pPromedioLecuraDisco = new System.Diagnostics.PerformanceCounter();
                    this.pPromedioEscrituraDisco = new System.Diagnostics.PerformanceCounter();
                    // 
                    // pMemoriaCache
                    // 
                    //this.pMemoriaCache.CategoryName = "Memoria";
                    //this.pMemoriaCache.CounterName = "Bytes de caché";
                    this.pMemoriaCache.CategoryName = ClassAppAplicacion.PMemoriaCacheCategoryName();
                    this.pMemoriaCache.CounterName = ClassAppAplicacion.PMemoriaCacheCounterName();
                    // 
                    // pMemoriaDisponible
                    // 
                    //this.pMemoriaDisponible.CategoryName = "Memoria";
                    //this.pMemoriaDisponible.CounterName = "Bytes disponibles";
                    this.pMemoriaDisponible.CategoryName = ClassAppAplicacion.PMemoriaDisponibleCategoryName();
                    this.pMemoriaDisponible.CounterName = ClassAppAplicacion.PMemoriaDisponibleCounterName();
                    // 
                    // pMemoriaTotal
                    // 
                    //this.pMemoriaTotal.CategoryName = "Memoria";
                    //this.pMemoriaTotal.CounterName = "% de bytes confirmados en uso";
                    this.pMemoriaTotal.CategoryName = ClassAppAplicacion.PMemoriaTotalCategoryName();
                    this.pMemoriaTotal.CounterName = ClassAppAplicacion.PMemoriaTotalCounterName();
                    // 
                    // pMemKernelPaginado
                    // 
                    //this.pMemKernelPaginado.CategoryName = "Memoria";
                    //this.pMemKernelPaginado.CounterName = "Bytes de bloque no paginado";
                    this.pMemKernelPaginado.CategoryName = ClassAppAplicacion.PMemKernelPaginadoCategoryName();
                    this.pMemKernelPaginado.CounterName = ClassAppAplicacion.PMemKernelPaginadoCounterName();
                    // 
                    // pMemKernelNoPaginado
                    // 
                    //this.pMemKernelNoPaginado.CategoryName = "Memoria";
                    //this.pMemKernelNoPaginado.CounterName = "Bytes de bloque no paginado";
                    this.pMemKernelNoPaginado.CategoryName = ClassAppAplicacion.PMemKernelNoPaginadoCategoryName();
                    this.pMemKernelNoPaginado.CounterName = ClassAppAplicacion.PMemKernelNoPaginadoCounterName();
                    // 
                    // pIdentificadores
                    // 
                    //this.pIdentificadores.CategoryName = "Sistema";
                    //this.pIdentificadores.CounterName = "Longitud de la cola del procesador";
                    this.pIdentificadores.CategoryName = ClassAppAplicacion.PIdentificadoresCategoryName();
                    this.pIdentificadores.CounterName = ClassAppAplicacion.PIdentificadoresCounterName();
                    // 
                    // pSubprocesos
                    // 
                    //this.pSubprocesos.CategoryName = "Sistema";
                    //this.pSubprocesos.CounterName = "Subprocesos";
                    this.pSubprocesos.CategoryName = ClassAppAplicacion.PSubprocesosCategoryName();
                    this.pSubprocesos.CounterName = ClassAppAplicacion.PSubprocesosCounterName();
                    // 
                    // pPorcentajeUsoCPU
                    // 
                    //this.pPorcentajeUsoCPU.CategoryName = "Processor";
                    //this.pPorcentajeUsoCPU.CounterName = "% Processor Time";
                    //this.pPorcentajeUsoCPU.InstanceName = "_Total";
                    this.pPorcentajeUsoCPU.CategoryName = ClassAppAplicacion.PPorcentajeUsoCPUCategoryName();
                    this.pPorcentajeUsoCPU.CounterName = ClassAppAplicacion.PPorcentajeUsoCPUCounterName();
                    this.pPorcentajeUsoCPU.InstanceName = ClassAppAplicacion.PPorcentajeUsoCPUInstanceName();
                    // 
                    // pPromedioLecuraDisco
                    // 
                    //this.pPromedioLecuraDisco.CategoryName = "Disco lógico";
                    //this.pPromedioLecuraDisco.CounterName = "Bytes de lectura de disco/s";
                    //this.pPromedioLecuraDisco.InstanceName = "_Total";
                    this.pPromedioLecuraDisco.CategoryName = ClassAppAplicacion.PPromedioLecuraDiscoCategoryName();
                    this.pPromedioLecuraDisco.CounterName = ClassAppAplicacion.PPromedioLecuraDiscoCounterName();
                    this.pPromedioLecuraDisco.InstanceName = ClassAppAplicacion.PPromedioLecuraDiscoInstanceName();
                    // 
                    // pPromedioEscrituraDisco
                    // 
                    //this.pPromedioEscrituraDisco.CategoryName = "Disco físico";
                    //this.pPromedioEscrituraDisco.CounterName = "Bytes de escritura en disco/s";
                    //this.pPromedioEscrituraDisco.InstanceName = "_Total";
                    this.pPromedioEscrituraDisco.CategoryName = ClassAppAplicacion.PPromedioEscrituraDiscoCategoryName();
                    this.pPromedioEscrituraDisco.CounterName = ClassAppAplicacion.PPromedioEscrituraDiscoCounterName();
                    this.pPromedioEscrituraDisco.InstanceName = ClassAppAplicacion.PPromedioEscrituraDiscoInstanceName();


                    ((System.ComponentModel.ISupportInitialize)(this.pMemoriaCache)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(this.pMemoriaDisponible)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(this.pMemoriaTotal)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(this.pMemKernelPaginado)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(this.pMemKernelNoPaginado)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(this.pIdentificadores)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(this.pSubprocesos)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(this.pPorcentajeUsoCPU)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(this.pPromedioLecuraDisco)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(this.pPromedioEscrituraDisco)).BeginInit();
                }
            }
            catch
            {
                enablePerformance = false;
            }
            PDFOCROptimized.langdir = ClassAppAplicacion.GetPathLang();            
            PDFOCROptimized.language = ClassAppAplicacion.GetLanguage();
            if (ClassAppAplicacion.GetLanguage() == "")
            {
                PDFOCROptimized.language = "spa";
            }
            PDFOCROptimized.enableMODI = (ClassAppAplicacion.GetEnableMODI().ToLower() == "yes" | ClassAppAplicacion.GetEnableMODI().ToLower() == "si") ? true : false;
            //MessageBox.Show(PDFOCROptimized.langdir);
           //args = new string[1];
           // MessageBox.Show(args[0]);
           //args[0] = "C:\\TIFS\\XMLConfig24NOskew_test - copia (2).xml";
           //args[0] = "XMLConfigPrueba.xml";
            if (args.Length == 1)
            {


                
                
                if (File.Exists(@args[0]))
                {
                    DirectoryInfo fileconfig = new DirectoryInfo(args[0]);
                   
                        configuracion = ConfiguracionXml.ParseXmlConfiguracion(args[0]);
                        this.Titulo_ShowInfoProceso();
                        FileInfo archivoinfo=new FileInfo(Path.Combine(configuracion.Proceso.Pathorigen,configuracion.Proceso.Nombrearchivo));
                        ProcesoArchivo.idproceso = configuracion.Proceso.Sec_Proceso;
                        ProcesoArchivo.nombrearchivo = configuracion.Proceso.Nombrearchivo;
                        ProcesoArchivo.formatoarchivo = archivoinfo.Extension;
                        string temp=archivoinfo.Name.Replace(archivoinfo.Extension,"");
                        string nombredirxml= Path.Combine(configuracion.Proceso.Pathorigen,temp);
                        Directory.CreateDirectory(nombredirxml);    
                        ProcesoArchivo.nombrefolder = nombredirxml;
                        ProcesoArchivo.directorio = archivoinfo.DirectoryName;
                        ProcesoArchivo.root = archivoinfo.Directory.Root.Name;
                        ProcesoArchivo.extencion = archivoinfo.Extension;
                        this.Location = ProcesoArchivo.SitioVentana(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height, ProcesoArchivo.idproceso, this.Height + 10, this.Width + 10);
                        ProcesarArchivoOcrXml(Path.Combine(configuracion.Proceso.Pathorigen, ProcesoArchivo.nombrearchivo), ProcesoArchivo.nombrefolder);
                        this.Titulo_ShowInfoNombre();
                    
                }
                else
                {
                    MessageBox.Show("No existe archivo");
                }
            }
        }
        private void FormProcesamiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            PDFOCROptimized.Cancelado = true;
            if(hiloProcesamiento!=null)
            {
                hiloProcesamiento.Abort();
            }
        }
        const long MBVALUE= 1048576;
        const long GBVALUE = 1073741824;
      
        

        private void timerEstadisticas_Tick(object sender, EventArgs e)
        {
            this.timerEstadisticas.Enabled = false;
            AddEstadistica();
            this.timerEstadisticas.Enabled = true;
        }

        private void statusBarOcr_PanelClick(object sender, StatusBarPanelClickEventArgs e)
        {

        }
      

    }
}
