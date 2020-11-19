using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using AMA.Util;
using System.Threading;
using System.Drawing;
using PdfSharp.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ONX.Cmn;
using System.Security.Permissions;
using System.Data;
using System.Xml;
using Microsoft.Office.Interop.Word;
namespace OCR.Facultad.Ingenieria.LibreriasOpenPDFOCR
{

    public delegate void SetMaxValue(int maxvalue);
    public delegate void SetPercent(int percent);
    public delegate void SetInfo(int pagina,string info);
    public delegate void SetFinProcesoOcr(bool error);
   
    public enum EstadoProcesoOcr : int
    {
        [EnumStringAttribute("Cargando Imagen")]
        pcargando = 0,
        [EnumStringAttribute("Iniciando Enderezamiento Imagen")]
        piniendimg = 1,
        [EnumStringAttribute("Finalizado Enderezamiento Imagen")]
        pfinendimg = 2,
        [EnumStringAttribute("Iniciando Reconcimiento Ocr")]
        piniocr = 3,
        [EnumStringAttribute("Finalizado Reconocimiento Ocr")]
        pfinocr = 4,
        [EnumStringAttribute("Iniciando Exportación Xml")]
        pinixml = 5,
        [EnumStringAttribute("Finalizado Exportación Xml")]
        pfinxml = 6,
        [EnumStringAttribute("Iniciando Borrado Tipos Documentales")]
        piniborradotip = 7,
        [EnumStringAttribute("FinalizadoBorrado Tipos Documentales")]
        pfinborradotip = 8,
        [EnumStringAttribute("Iniciando Exportación Txt")]
        pinitxt = 9,
        [EnumStringAttribute("Finalizado Exportación Txt")]
        pfintxt = 10,
        [EnumStringAttribute("Iniciando Exportación Pdf")]
        pinipdf = 11,
        [EnumStringAttribute("Finalizado Exportación Pdf")]
        pfinpdf = 12,
        [EnumStringAttribute("Iniciando Exportación Doc")]
        pinidoc = 13,
        [EnumStringAttribute("Finalizado Exportación Doc")]
        pfindoc = 14,
        [EnumStringAttribute("Iniciando Exportación Xls")]
        pinixls = 15,
        [EnumStringAttribute("Finalizado Exportación Xls")]
        pfinxls = 16,
        [EnumStringAttribute("Iniciando Exportación Docx")]
        pinidocx = 17,
        [EnumStringAttribute("Finalizado Exportación Docx")]
        pfindocx = 18,
        [EnumStringAttribute("Iniciando Exportación Xlsx")]
        pinixlsx = 19,
        [EnumStringAttribute("Finalizado Exportación Xlsx")]
        pfinxlsx = 20,
        [EnumStringAttribute("Iniciando Metadata Ocr Imagen")]
        pinimetaimg = 21,
        [EnumStringAttribute("Finalizado Metadata Ocr Imagen")]
        pfinmetaimg = 22

    }
    public enum FormatoExportacion : int
    {
        [EnumStringAttribute("xml")]
        XML = 0,
        [EnumStringAttribute("pdf")]
        PDF = 1,
        [EnumStringAttribute("txt")]
        TXT = 2,
        [EnumStringAttribute("xlsx")]
        XLSX = 3,
        [EnumStringAttribute("docx")]
        DOCX = 4,
        [EnumStringAttribute("xls")]
        XLS = 5,
        [EnumStringAttribute("doc")]
        DOC = 6   

        
    }
    /// <summary>
    /// Clase con métodos utilizados para el Reconocimiento Optico de Caracteres
    /// </summary>
    public class PDFOCROptimized
    {
       /// <summary>
       /// Ruta relativa del paquete de lenguaje utilizado para el proceso ocr.
       /// </summary>
        public static string langdir;
        public static string language;
        public static bool enableMODI;
        static int tifidnumber;
        public static event SetPercent ocr_porcentaje;
        public static event SetMaxValue ocr_maxvalue;
        public static event SetInfo ocr_info;
        public static event SetFinProcesoOcr ocr_fin_proceso;
        static volatile bool cancelado;
        static List<string> listatemptif = new List<string>();
        /// <summary>
        /// Propiedad utilizada como método de cancielación de docuemntos en proceso OCR
        /// </summary>
        public static bool Cancelado
        {
            get
            {
                return cancelado;
            }
            set {
                cancelado = value;
            }

        }
        /// <summary>
        /// Variable tipo Object utilizada para bloquear dos o más hilos cuando intentan acceder de forma simultanea a un bloque de código.
        /// </summary>
        private static object _abortedLockObject = new object();
        /// <summary>
        /// Variable tipo AutoResetEvent utilizada para bloquear dos o más hilos cuando intentan acceder de forma simultanea a un bloque de código.
        /// </summary>
        private static AutoResetEvent _blockThread = new AutoResetEvent(true);
        /// <summary>
        /// Variable utilizada para definir la máxima separación dentro de las coincidencias de caracteres digitales reconocidos.
        /// </summary>
        static int correcionlinea = 10;
        /// <summary>
        /// Salto de línea en texto UNICODE.
        /// </summary>
        private static string saltolinea = (char.ConvertFromUtf32(13) + char.ConvertFromUtf32(10));
        /// <summary>
        /// <para>Realiza el Reconocimiento Óptico de Carateres(OCR), para un documento TIF.</para>
        /// <para>El resultado es un par de documentos(PDF Y TXT), con contenido UNICODE del texto extraido luego del proceso OCR.</para>
        /// </summary>
        /// <param name="unTIFsource">Ruta del documento recurso TIF.</param>
        /// <param name="unPDFOutput">Ruta del documento resultado PDF.</param>
        /// <param name="unTXTOutput">Ruta del documento resultado TXT.</param>
        /// <param name="isdeskew">Si es TRUE, realiza el enderezamiento automático de las páginas del documento TIF.</param>
        /// <returns>Número de páginas procesadas luego del proceso OCR.</returns>
        /// <example>Como realizar el Reconocimiento Óptico de Caracteres de un documento TIF
        /// <code>
        /// int paginas = PDFOCROptimized.ProcesarOCRPDFTXT(@"C:\prueba.tif",@"C:\prueba.pdf",@"C:\prueba.txt",true);
        /// </code>
        /// <list type="bullet">
        /// <listheader>Observaciones:</listheader>
        /// <item>Nótese que la llamada se realiza a un método estático.</item>
        /// </list>
        /// </example>
        /// <example>Llamadas a métodos mediante la ejecución de hilos
        /// <code>
        ///public static int ProcesarOCRPDFTXT(string unTIFsource, string unPDFOutput, string unTXTOutput, bool isdeskew)
        ///{
        /// ......
        /// ThreadStart _ts = delegate
        ///    {
        ///    try
        ///    {
        ///        OCRPDFTXTTHREAD(unTIFsource, unPDFOutput, unTXTOutput, isdeskew, out npaginas);
        ///    }
        ///    catch (Exception error)
        ///    {
        ///        _blockThread.Set();
        ///        excepcion = new ExceptionThreadOCR(true, error.Message);
        ///    }
        /// };
        /// Thread mainTableGetter = new Thread(_ts);
        /// mainTableGetter.Name = "OCRPDFTXTTHREADAsync";
        /// mainTableGetter.Start();
        /// mainTableGetter.Join();
        ///.......
        ///}
        /// </code>
        /// <list type="bullet">
        /// <item>El método anterior es un fragmento de código contenido en el método ProcesarOCRPDFTXT,  realiza la llamada a otro método a traves de la ejecución de un hilo de programación.</item>
        /// </list>
        /// </example> 
        /// <exception cref="LibreriasOpenPDFOCR.ExceptionThreadOCR">Captura las excepciones disparadas por los hilos de programación.</exception>
        public static int ProcesarOCR(string unimagesource, string unfolderoutput, bool isdeskew)
        {
                        
            int npaginas = 0;
            OcrInfo ocrinfo = new OcrInfo();
            bool iserror=false;
            BorrarArchivosFolderXml(unimagesource, unfolderoutput);
            ExceptionThreadOCR excepcion = new ExceptionThreadOCR();
            ExceptionThreadOCRErrors excepciondir = new ExceptionThreadOCRErrors();           
            ThreadStart _tsimage = delegate
            {
                try
                {
                    npaginas = IMAGEPROCESSINGTHREAD(unimagesource, unfolderoutput, isdeskew);
                }
                catch (NullReferenceException error)
                {
                    _blockThread.Set();
                    excepciondir = new ExceptionThreadOCRErrors(true, error.Message);
                    iserror = true;
                }
                catch (IOException error)
                {
                    _blockThread.Set();
                    excepciondir = new ExceptionThreadOCRErrors(true, error.Message);
                    iserror = true;
                }
                catch (Exception error)
                {
                    _blockThread.Set();
                    excepcion = new ExceptionThreadOCR(true, error.Message);
                    iserror = true;
                }

            };
            Thread mainImageGetter = new Thread(_tsimage);
            mainImageGetter.Name = "OCRIMAGEPROCESSINGTHREADAsync";
            mainImageGetter.Start();
            mainImageGetter.Join();
            
            
            ThreadStart _ts = delegate
            {
                try
                {
                    OCRXMLTHREAD(unimagesource, unfolderoutput, out ocrinfo);
                }
                catch (NullReferenceException error)
                {
                    _blockThread.Set();
                    excepciondir = new ExceptionThreadOCRErrors(true, error.Message);
                    iserror = true;
                }
                catch (IOException error)
                {
                    _blockThread.Set();
                    excepciondir = new ExceptionThreadOCRErrors(true, error.Message);
                    iserror = true;
                }
                catch (Exception error)
                {
                    _blockThread.Set();
                    excepcion = new ExceptionThreadOCR(true, error.Message);
                    iserror = true;
                }
                
            };
            Thread mainTableGetter = new Thread(_ts);
            mainTableGetter.Name = "OCRPDFTXTTHREADAsync";
            mainTableGetter.Start();
            mainTableGetter.Join();
            GC.GetTotalMemory(true);
            if (mainTableGetter != null)
            {
                mainTableGetter = null;
            }
            System.GC.Collect();
            if (excepcion.IsException)
            {
                throw excepcion;
                iserror = true;
            }
            if (excepciondir.IsException)
            {
                throw excepciondir;
                iserror = true;
            }
            //GC.ReRegisterForFinalize(this);
            GC.WaitForPendingFinalizers();
            try
            {
                foreach (string nombretemp in listatemptif)
                {
                    File.Delete(nombretemp);
                }
            }
            catch (Exception error)
            {
 
            }
            ocr_fin_proceso(iserror);
            FileInfo file = new FileInfo(unimagesource);
            string nombrexml = file.Name.Replace(file.Extension, ".xml");
            string nombrearchivoxml = XmlOcr.InicializarXmlArchivo(file.DirectoryName, nombrexml);

            CabeceraInfo cabecerainfo = CabeceraInfo.GetCabeceraInfo(unimagesource);
            XmlOcr.ArchivoCabecera(nombrearchivoxml, cabecerainfo.Nombre, cabecerainfo.Directorio, cabecerainfo.Tamanio,cabecerainfo.Extencion, cabecerainfo.Fechacreacion, cabecerainfo.Fechamodificacion);
            ImagenInfo imageninfo = ImagenInfo.GetInfoImagen(UtilImage.NonLockingOpen(unimagesource));
            XmlOcr.ArchivoImagen(nombrearchivoxml, imageninfo.Ancho, imageninfo.Alto, imageninfo.Vertical, imageninfo.Horizontal, imageninfo.Profundidadbits);
            XmlOcr.ArchivoOcr(nombrearchivoxml, ocrinfo.NCaracteres, ocrinfo.NPalabras, ocrinfo.NLineas, ocrinfo.NPaginas, ocrinfo.FechaInicio, ocrinfo.FechaFin, !iserror);
            return npaginas;
        }
        /// <summary>
        /// Realiza el Reconocimiento Óptico de Carateres(OCR), para un documento TIF.
        /// Este método se ejecuta como un hilo dentro del método PRINCIPAL.
        /// </summary>
        /// <param name="unTIFsource">Ruta del documento recurso TIF.</param>
        /// <param name="unPDFOutput">Ruta del documento resultado PDF.</param>
        /// <param name="unTXTOutput">Ruta del documento resultado TXT.</param>
        /// <param name="isdeskew">Si es TRUE, realiza el enderezamiento automático de las páginas del documento TIF.</param>
        /// <param name="npaginas">Salida: Retorna el número de paginas del documento recurso TIF.</param>
        /// <example>Ejemplo ProcesarOCRPDFTXT
        /// <code>
        /// PDFOCROptimized.ProcesarOCRPDFTXT(@"C:\prueba.tif",@"C:\prueba.pdf",@"C:\prueba.txt",true);
        /// </code>
        /// <list type="bullet">
        /// <listheader>Observaciones:</listheader>
        /// <item>Nótese que la llamada se realiza a un método estático.</item>
        /// <item>Este método realiza llamadas a otros métodos a traves de la ejecución de hilos de programación</item>
        /// </list>
        /// </example>        
        private static void OCRPDFTXTTHREAD(string unTIFsource, string unPDFOutput, string unTXTOutput, bool isdeskew, out int npaginas)
        {          

            int npag = 0;
            PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();
            StringBuilder btextodoc = new StringBuilder();
            using (TiffManager tifman = new TiffManager(unTIFsource))
            {
                npag = tifman.PageNumber;
               
                for (int i = 0; i < npag; i++)
                {
                   
                    Bitmap imagetmep = new Bitmap(tifman.GetSpecificPage(i));
                    if (isdeskew)
                    {
                        
                        EncoderParameters parm = new EncoderParameters(1);
                        EncoderParameter pa = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionLZW);
                        parm.Param[0] = pa;
                        imagetmep = PixelImageManager.SaveGIFWithNewColorTable((imagetmep), 256, true);
                        if (cancelado) {
                            npaginas = -1;
                            return ;                            
                        }
                        imagetmep = AForgeDeskew.DeskewImagen(imagetmep);
                    }
                    using (Bitmap imagetest = imagetmep)
                    {
                        PdfSharp.Pdf.PdfPage page = document.AddPage();
                        XGraphics gfx = XGraphics.FromPdfPage(page);
                        XImage imgsharp = XImage.FromGdiPlusImage((Image)imagetest);
                        PdfSharp.PageSize siz = page.Size;
                        page.Height = imgsharp.PixelHeight;
                        page.Width = imgsharp.PixelWidth;
                        
                        using (tessnet2.Tesseract ocr = new tessnet2.Tesseract())
                        {
                            
                            lock (_abortedLockObject)
                            {
                                if (cancelado)
                                {
                                    npaginas = -1;
                                    return;
                                }
                                _blockThread.WaitOne();
                                int total = ocr.Init(langdir, language, false); // To use correct tessdata
                                ocr.SetVariable("tessedit_char_whitelist", ""); // If digit only                                
                                List<tessnet2.Word> result = null;
                                Thread FirstThread = new Thread((ThreadStart)delegate
                                {

                                    result = ocr.DoOCR(imagetest, System.Drawing.Rectangle.Empty);

                                });
                                FirstThread.Start();
                                FirstThread.Join();
                                _blockThread.Set();
                                
                                int linea = 0;
                                List<BloqueTexto> listalinea = null;
                                BloqueTexto bloquea = null;
                                int indicelinea = 0;
                                foreach (tessnet2.Word word in result)
                                {
                                    string espacioblanco = " ";
                                    for (int k = 0; k < word.Blanks - 1; k++)
                                    {
                                        espacioblanco += " ";
                                    }
                                    if (cancelado)
                                    {
                                        npaginas = -1;
                                        return;
                                    }
                                    if (linea == 0)
                                    {
                                        indicelinea = word.LineIndex;
                                        listalinea = new List<BloqueTexto>();
                                        bloquea = new BloqueTexto(word.Left, word.Right, word.Top, word.Bottom, word.PointSize, word.Text);
                                        linea++;                                        
                                    }
                                    BloqueTexto bloqueb = new BloqueTexto(word.Left, word.Right, word.Top, word.Bottom, word.PointSize, word.Text);
                                    if (word.LineIndex==indicelinea)
                                    {
                                        //if (bloqueb.EsBloqueLinea(bloquea, bloqueb, PDFOCROptimized.correcionlinea))
                                        if (bloqueb.H <= 75)
                                        {
                                            listalinea.Add(bloqueb);
                                        }
                                        else
                                        {
                                            List<tessnet2.Character> cadena = word.CharList;
                                            List<BloqueTexto> listacad = new List<BloqueTexto>();
                                            for (int k = 0; k < cadena.Count; k++)
                                            {
                                                tessnet2.Character caracter = cadena[k];
                                                BloqueTexto textlin = new BloqueTexto(caracter.Left, caracter.Right, caracter.Top, caracter.Bottom, caracter.Value.ToString());
                                                if (textlin.H <= 65)
                                                {
                                                    double x = textlin.X;
                                                    double y = textlin.Y;
                                                    double w = textlin.W;
                                                    double h = textlin.H;
                                                    XFont font = new XFont("Verdana", h, XFontStyle.Regular);
                                                    RectangleF rec = new RectangleF((float)x, (float)y, (float)w, (float)h);
                                                    gfx.DrawString(textlin.texto, font, XBrushes.Black, new XRect(x, y, w, h), XStringFormats.TopCenter);
                                                }
                                            }

                                        }
                                    }
                                    else
                                    {
                                        indicelinea = word.LineIndex;
                                        bloquea = bloqueb;
                                        double alturap = BloqueTexto.MaximaAlturaPromedio(listalinea);
                                        for (int j = 0; j < listalinea.Count; j++)
                                        {
                                            double x = listalinea[j].X;
                                            double y = listalinea[j].Y;
                                            double w = listalinea[j].W;
                                            double h = alturap;
                                            double pointsize = word.PointSize;
                                            XFont font = new XFont("Verdana", h, XFontStyle.Regular);
                                            // Draw the text                
                                            if (listalinea[j].H <= 75)
                                            {
                                                RectangleF rec = new RectangleF((float)x, (float)y, (float)w, (float)h);
                                                gfx.DrawString(listalinea[j].texto, font, XBrushes.Black, new XRect(x, y, w, h), XStringFormats.TopCenter);
                                            }

                                        }
                                        listalinea = new List<BloqueTexto>();
                                        if (bloquea.H <= 75)
                                        {
                                            listalinea.Add(bloquea);
                                        }
                                        else
                                        {
                                            List<tessnet2.Character> cadena = word.CharList;
                                            List<BloqueTexto> listacad = new List<BloqueTexto>();
                                            for (int k = 0; k < cadena.Count; k++)
                                            {   
                                                tessnet2.Character caracter = cadena[k];
                                                BloqueTexto textlin = new BloqueTexto(caracter.Left, caracter.Right, caracter.Top, caracter.Bottom, caracter.Value.ToString());
                                                if (textlin.H <= 65)
                                                {
                                                    double x = textlin.X;
                                                    double y = textlin.Y;
                                                    double w = textlin.W;
                                                    double h = textlin.H;
                                                    XFont font = new XFont("Verdana", h, XFontStyle.Regular);
                                                    RectangleF rec = new RectangleF((float)x, (float)y, (float)w, (float)h);
                                                    gfx.DrawString(textlin.texto, font, XBrushes.Black, new XRect(x, y, w, h), XStringFormats.TopCenter);
                                                }
                                            }

                                        }
                                        btextodoc.Append(saltolinea);
                                    }
                                    btextodoc.Append(espacioblanco + word.Text);
                                }
                                ocr.Dispose();

                            }
                        }
                        if (cancelado)
                        {
                            npaginas = -1;
                            return;
                        }
                        gfx.DrawImage(imgsharp, 0, 0, imgsharp.PixelWidth, imgsharp.PixelHeight);
                        gfx.Save();
                        gfx.Dispose();
                        imagetest.Dispose();
                        imgsharp.Dispose();
                        btextodoc.Append(saltolinea);
                        System.GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                    
                }
                StreamWriter writertxt = new StreamWriter(unTXTOutput, false);
                writertxt.Write(btextodoc);
                writertxt.Close();
                document.Save(unPDFOutput);
                tifman.Dispose();
                System.GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            npaginas = npag;
            ThreadStart _ts = delegate { PDFOCROptimized.ResizePDFOCR(unPDFOutput); };
            Thread mainGetter = new Thread(_ts);
            mainGetter.Start();
            //mainGetter.Join();
            if (mainGetter != null)
            {
                mainGetter = null;
            }
            System.GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        /// <summary>
        /// Permite el redimencionamiento a formato A4 de un documento PDF.
        /// </summary>
        /// <param name="unPDFOutput">Ruta del documento PDF.</param>
        /// <example>Ejemplo ResizePDFOCR
        /// <code>
        /// PDFOCROptimized.ResizePDFOCR(@"C:\prueba.pdf");
        /// </code>
        /// <list type="bullet">
        /// <listheader>Observaciones:</listheader>
        /// <item>Nótese que la llamada se realiza a un método estático.</item>
        /// <item>La salida es el mismo documento "C:\prueba.pdf", pero con formato A4.</item>
        /// </list>
        /// </example>       
        public static void ResizePDFOCR(string unPDFOutput)
        {
            try
            {
                FileInfo info = new FileInfo(unPDFOutput);
                string nombre = "temp" + info.Name;
                iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 0, 0, 0, 0);
                iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(nombre, FileMode.Create, FileAccess.Write));
                iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(unPDFOutput);

                try
                {
                    for (int i = 0; i < reader.NumberOfPages; i++)
                    {
                        if (cancelado)
                        {
                            return;
                        }
                        float Scaleh = doc.PageSize.Height / reader.GetPageSize((i + 1)).Height;
                        float Scalew = doc.PageSize.Width / reader.GetPageSize((i + 1)).Width;
                        doc.NewPage();
                        doc.Open();
                        iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
                        iTextSharp.text.pdf.PdfImportedPage page = writer.GetImportedPage(reader, (i + 1));
                        cb.AddTemplate(page, Scalew, 0, 0, Scaleh, 0, 0);
                    }
                    reader.Close();
                    doc.Close();
                    File.Copy(nombre, unPDFOutput, true);
                    File.Delete(nombre);
                }
                catch
                {
                    if (File.Exists(nombre))
                    {
                        if (doc.IsOpen())
                        {
                            doc.Close();
                        }
                        File.Delete(nombre);
                    }
                }

                System.GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch { }
        }
        /// <summary>
        /// Realiza el Reconocimiento Óptico de Carateres(OCR), para un documento TIF.
        /// Este método se ejecuta como un hilo dentro del método PRINCIPAL.
        /// </summary>
        /// <param name="unTIFsource">Ruta del documento recurso TIF.</param>
        /// <param name="unPDFOutput">Ruta del documento resultado PDF.</param>
        /// <param name="unTXTOutput">Ruta del documento resultado TXT.</param>
        /// <param name="isdeskew">Si es TRUE, realiza el enderezamiento automático de las páginas del documento TIF.</param>
        /// <param name="npaginas">Salida: Retorna el número de paginas del documento recurso TIF.</param>
        /// <example>Ejemplo ProcesarOCRPDFTXT
        /// <code>
        /// PDFOCROptimized.ProcesarOCRPDFTXT(@"C:\prueba.tif",@"C:\prueba.pdf",@"C:\prueba.txt",true);
        /// </code>
        /// <list type="bullet">
        /// <listheader>Observaciones:</listheader>
        /// <item>Nótese que la llamada se realiza a un método estático.</item>
        /// <item>Este método realiza llamadas a otros métodos a traves de la ejecución de hilos de programación</item>
        /// </list>
        /// </example>        
        private static void OCRXMLTHREAD(string unimgesource, string unfolderoutput, out OcrInfo ocrinfo)
        {
            ocrinfo = new OcrInfo();
            ocrinfo.FechaInicio = DateTime.Now;
            int npag = listatemptif.Count;
            FileInfo file = new FileInfo(unimgesource);
            string nombrexml = file.Name.Replace(file.Extension, "_pag{0}.xml");
            ocr_info(0, EstadoProcesoOcr.pcargando.GetStringValue());
            for (int i = 0; i < listatemptif.Count; i++)
            {

                ocr_maxvalue(npag);

                string nombretif = file.Name.Replace(file.Extension, "{0}_pag{1}" + "."+ImageFormat.Tiff);
                string nombretiftemp = string.Format("temptif" + "\\" + nombretif, tifidnumber, i);
                Bitmap imagetmep =(Bitmap)UtilImage.NonLockingOpen(nombretiftemp);
                string filexml = string.Format(unfolderoutput + "\\" + nombrexml, i);
                XmlOcr.InicializarXmlPagina(filexml);
                int ncaracteres = 0;
                int npalabras = 0;
                int nlineas = 0;
                BloqueTextoTessnet ibloques = new BloqueTextoTessnet();
                DateTime fechainicproc = DateTime.Now;

                using (Bitmap imagetest = imagetmep)
                {
                    using (tessnet2.Tesseract ocr = new tessnet2.Tesseract())
                    {

                        lock (_abortedLockObject)
                        {
                            if (cancelado)
                            {
                                ocrinfo.NPaginas = -1;
                                return;
                            }
                            _blockThread.WaitOne();
                            int total = ocr.Init(langdir, language, false); // To use correct tessdata
                            ocr.SetVariable("tessedit_char_whitelist", ""); // If digit only                                
                            List<tessnet2.Word> result = null;
                            ocr_info(i + 1, EstadoProcesoOcr.piniocr.GetStringValue());
                            Thread FirstThread = new Thread((ThreadStart)delegate
                            {

                                result = ocr.DoOCR(imagetest, System.Drawing.Rectangle.Empty);

                            });
                            FirstThread.Start();
                            FirstThread.Join();
                            _blockThread.Set();



                            ocr_info(i + 1, EstadoProcesoOcr.pfinocr.GetStringValue());
                            ocr_porcentaje(i + 1);
                            int linea = 0;
                            List<BloqueTexto> lista = null;
                            BloqueTexto bloquea = null;
                            int indicelinea = 0;

                            ocr_info(i + 1, EstadoProcesoOcr.pinixml.GetStringValue());
                            foreach (tessnet2.Word word in result)
                            {
                                lista = ibloques.LineasTextoPorPalabra(word);

                                ncaracteres += word.Text.Length;
                                string espacioblanco = " ";
                                for (int k = 0; k < word.Blanks - 1; k++)
                                {
                                    espacioblanco += " ";
                                }
                                if (cancelado)
                                {
                                    ocrinfo.NPaginas = -1;
                                    return;
                                }
                                if (linea == 0)
                                {

                                    indicelinea = word.LineIndex;
                                    bloquea = new BloqueTexto(word.Left, word.Right, word.Top, word.Bottom, word.PointSize, word.Text);
                                    linea++;
                                }
                                for (int j = 0; j < lista.Count; j++)
                                {
                                    XmlOcr.CuerpoPagina(filexml, lista[j].SecPalabra, UtilXmlOcr.TypeCodeString(lista[j].texto), lista[j].Pointsize, lista[j].X, lista[j].Y, lista[j].H, lista[j].W, lista[j].Linea, word.LineIndex, word.FontIndex, word.Confidence, word.Blanks, lista[j].Texto);
                                    npalabras++;
                                    nlineas = lista[j].Linea;
                                }



                            }
                            ocr.Dispose();
                        }
                    }
                    if (cancelado)
                    {
                        ocrinfo.NPaginas = -1;
                        return;
                    }
                    imagetest.Dispose();
                    System.GC.Collect();
                    GC.WaitForPendingFinalizers();

                    XmlOcr.CabeceraPagina(filexml, i, ncaracteres, npalabras, nlineas, fechainicproc, DateTime.Now);
                    ocrinfo.NCaracteres += ncaracteres;
                    ocrinfo.NPalabras += npalabras;
                    ocrinfo.NLineas += nlineas;

                }
                ocr_info(i + 1, EstadoProcesoOcr.pfinxml.GetStringValue());                
                System.GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            ocrinfo.FechaFin = DateTime.Now;
            ocrinfo.NPaginas = npag;
        }
        public static MODI.MiLANGUAGES GetLanguage(string lang)
        {
            switch (lang)
            {

                case "esp":
                    return MODI.MiLANGUAGES.miLANG_SPANISH;
                    break;
                case "eng":
                    return MODI.MiLANGUAGES.miLANG_ENGLISH;
                    break;
                case "fra":
                    return MODI.MiLANGUAGES.miLANG_FRENCH;
                    break;
                default:
                    return MODI.MiLANGUAGES.miLANG_SPANISH;
                    break;


            }
        }
        private static int IMAGEPROCESSINGTHREAD(string unimgesource, string unfolderoutput, bool isdeskew)
        {
            tifidnumber = new Random().Next(1, 100);
            int npag = 0;
            FileInfo file = new FileInfo(unimgesource);
            ocr_info(0, EstadoProcesoOcr.pcargando.GetStringValue());
            using (TiffManager tifman = new TiffManager(unimgesource))
            {
                npag = tifman.PageNumber;
                ocr_maxvalue(npag);
                for (int i = 0; i < npag; i++)
                {
                    
                    Bitmap imagetmep = new Bitmap(tifman.GetSpecificPage(i));

                    if (isdeskew)
                    {
                        ocr_info(i + 1, EstadoProcesoOcr.piniendimg.GetStringValue());
                        EncoderParameters parm = new EncoderParameters(1);
                        EncoderParameter pa = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionLZW);
                        parm.Param[0] = pa;
                        imagetmep = PixelImageManager.SaveGIFWithNewColorTable((imagetmep), 256, true);
                        if (cancelado)
                        {                        
                            return 0;
                        }
                        imagetmep = AForgeDeskew.DeskewImagen(imagetmep);
                        ocr_info(i + 1, EstadoProcesoOcr.pfinendimg.GetStringValue());
                        
                    }
                    ocr_info(i + 1, EstadoProcesoOcr.pinimetaimg.GetStringValue());
                    //MODI Añadir Información OCR                    
                    string nombretif = file.Name.Replace(file.Extension, "{0}_pag{1}" +"."+ ImageFormat.Tiff);
                    string nombretiftemp = string.Format("temptif" + "\\" + nombretif, tifidnumber, i);
                    if (File.Exists(nombretiftemp))
                    {
                        File.Delete(nombretiftemp);
                    }
                    
                    //UtilImage.NonLockingSave(imagetmep, nombretiftemp, ImageFormat.Bmp);
                    if (enableMODI)
                    {

                        int potenciawidth = UtilImage.PotenciaMenor(imagetmep.Width);
                        int potenciaheight = UtilImage.PotenciaMenor(imagetmep.Height);
                        if (potenciaheight == potenciawidth)
                        {
                            if (imagetmep.Width > imagetmep.Height)
                            {
                                potenciaheight--;
                            }
                            if (imagetmep.Width < imagetmep.Height)
                            {
                                potenciawidth--;
                            }
                        }


                        Image imagenres = UtilImage.resizeImage(imagetmep, new Size(Convert.ToInt32(Math.Pow(2, potenciawidth)), Convert.ToInt32(Math.Pow(2, potenciaheight))));

                        imagenres.Save(nombretiftemp, ImageFormat.Tiff);
                        //Bitmap bmp = new Bitmap(Math.Max(imagetmep.Width, 1024), Math.Max(imagetmep.Height, 768));
                        //Graphics gfxResize = Graphics.FromImage(bmp);
                        //gfxResize.DrawImage(imagetmep, new System.Drawing.Rectangle(0, 0, imagetmep.Width, imagetmep.Height));
                        //bmp.Save(nombretiftemp , ImageFormat.Bmp);
                        listatemptif.Add(nombretiftemp);

                        MODI.Document md = new MODI.Document();
                        MODI.Image image = null;
                        try
                        {

                            md.Create(nombretiftemp);

                            md.OCR(GetLanguage(language), true, true);
                            image = (MODI.Image)md.Images[0];
                            MODI.Layout layout = image.Layout;


                        }
                        catch (Exception ex)
                        {
                            Console.Beep();
                        }
                        finally
                        {
                            md.Close(true);
                            image = null;
                            GC.Collect(); GC.WaitForPendingFinalizers();
                            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(md);
                            md = null;
                            GC.Collect();
                        }
                    }
                    else
                    {
                        imagetmep.Save(nombretiftemp, ImageFormat.Tiff);
                        listatemptif.Add(nombretiftemp);
                    }
                    System.GC.Collect();
                    GC.WaitForPendingFinalizers();


                    ocr_info(i + 1, EstadoProcesoOcr.pfinmetaimg.GetStringValue());
                }
                


            }
            
            System.GC.Collect();
            GC.WaitForPendingFinalizers();
            return npag;
        }        
        public static List<tessnet2.Word> FiltroOCR(List<tessnet2.Word> listaword,List<tessnet2.Word> listamodi)
        {
            return null;
        }
        public static void BorrarArchivosFormatos(List<ArchivoProceso> listaarchivos)
        {
            ocr_info(0, EstadoProcesoOcr.piniborradotip.GetStringValue());  
            foreach (ArchivoProceso archivo in listaarchivos)
            {
                FormatoExp formato = archivo.Formato;
                string valor = formato.Valor.ToLower();
                string valortxt = FormatoExportacion.TXT.GetStringValue().ToLower();
                string valorpdf = FormatoExportacion.PDF.GetStringValue().ToLower();
                string valordoc = FormatoExportacion.DOC.GetStringValue().ToLower();
                string valorxls = FormatoExportacion.XLS.GetStringValue().ToLower();
                string valordocx = FormatoExportacion.DOCX.GetStringValue().ToLower();
                string valorxlsx = FormatoExportacion.XLSX.GetStringValue().ToLower();
                if (valor == valortxt)
                {
                    File.Delete(archivo.Path);
                }
                if (valor == valorpdf)
                {
                    File.Delete(archivo.Path);

                }
                if (valor == valordoc)
                {
                    File.Delete(archivo.Path);
                }
                if (valor == valordocx)
                {
                    File.Delete(archivo.Path);
                }
                if (valor == valorxls)
                {
                    File.Delete(archivo.Path);
                }
                if (valor == valorxlsx)
                {
                    File.Delete(archivo.Path);
                }
            }
            ocr_info(0, EstadoProcesoOcr.piniborradotip.GetStringValue());
        }
        public static void BorrarArchivosFolderXml(string unimgesource, string unombredirxml)
        {
            FileInfo fileinfo = new FileInfo(unimgesource);
            string filenombre = fileinfo.Name.Replace(fileinfo.Extension, "");
            List<string> filesxml = new List<string>(Directory.GetFiles(unombredirxml, filenombre + "_pag*.xml"));

            for (int i = 0; i < filesxml.Count; i++)
            {
                Predicate<string> predicate = value => value.Contains(filenombre + "_pag" + i.ToString() + ".xml");
                string nombrexmlpag = Path.Combine(fileinfo.DirectoryName, filesxml.Find(predicate));
                if (File.Exists(nombrexmlpag))
                {
                    File.Delete(nombrexmlpag);
                }
            }

        }
        public static int ExportarFormato(string unfilename, string unfolderxml, Proceso proceso, List<ArchivoProceso> listaarchivos,bool isdeskew)
        {
            try
            {
                int npaginas = 0;
                FileInfo fileinfo = new FileInfo(unfilename);
                string filenombre = fileinfo.Name.Replace(fileinfo.Extension, "");
                List<string> filesxml = new List<string>(Directory.GetFiles(unfolderxml, filenombre + "_pag*.xml"));
                List<ArchivoProceso> lista = new List<ArchivoProceso>();
                BorrarArchivosFormatos(listaarchivos);
                string valortxt = FormatoExportacion.TXT.GetStringValue().ToLower();
                string valorpdf = FormatoExportacion.PDF.GetStringValue().ToLower();
                string valordoc = FormatoExportacion.DOC.GetStringValue().ToLower();
                string valordocx = FormatoExportacion.DOCX.GetStringValue().ToLower();
                string valorxls = FormatoExportacion.XLS.GetStringValue().ToLower();
                string valorxlsx = FormatoExportacion.XLSX.GetStringValue().ToLower();
                string valorxml = FormatoExportacion.XML.GetStringValue().ToLower();
                ExceptionThreadOCR excepcion = new ExceptionThreadOCR();
                ExceptionThreadOCRErrors excepciondir = new ExceptionThreadOCRErrors();
                List<BloqueTexto> listabloqueword = new List<BloqueTexto>();
                foreach (ArchivoProceso archivo in listaarchivos)
                {
                    FormatoExp formato = archivo.Formato;
                    string valor = formato.Valor.ToLower();
                   
                    
                    for (int i = 0; i < filesxml.Count; i++)
                    {
                        
                        string nombrefilexml = filenombre + "_pag" + i.ToString() + ".xml";
                        Predicate<string> predicate = value => value.Contains(nombrefilexml);
                        List<BloqueTexto> listabloque = BloqueTextoXml.ParseXmlBloqueTexto(filesxml.Find(predicate));
                        
                        
                        ThreadStart _ts = delegate
                        {
                            try
                            {

                                
                                if (valor.Contains(valortxt))
                                {
                                    ocr_info(i + 1, EstadoProcesoOcr.pfintxt.GetStringValue());
                                    XMLTXTTHREAD(archivo.Path, listabloque, out npaginas);
                                    ocr_info(i + 1, EstadoProcesoOcr.pfintxt.GetStringValue());
                                }
                                if (valor.Contains(valorxml))
                                {
                                    ocr_info(i + 1, EstadoProcesoOcr.pinixml.GetStringValue());
                                    XMLXMLTHREAD(archivo.Path, Path.Combine(unfolderxml, nombrefilexml), i, out npaginas);
                                    ocr_info(i + 1, EstadoProcesoOcr.pfinxml.GetStringValue());
                                }
                                if (valor.Contains(valorpdf))
                                {
                                    ocr_info(i + 1, EstadoProcesoOcr.pinipdf.GetStringValue());
                                    XMLPDFTHREAD(unfilename, archivo.Path, listabloque, i, isdeskew, out npaginas);
                                    ocr_info(i + 1, EstadoProcesoOcr.pfinpdf.GetStringValue());

                                }
                                if (valor.Equals(valordoc))
                                {
                                    listabloqueword.AddRange(listabloque);
                                    //ocr_info(i + 1, EstadoProcesoOcr.pinidoc.GetStringValue());
                                    //XMLDOCTHREAD(archivo.Path, listabloque, out npaginas);
                                    //ocr_info(i + 1, EstadoProcesoOcr.pfindoc.GetStringValue());
                                }
                                if (valor.Equals(valordocx))
                                {
                                    listabloqueword.AddRange(listabloque);
                                    //ocr_info(i + 1, EstadoProcesoOcr.pinidocx.GetStringValue());
                                    //XMLDOCTHREAD(archivo.Path, listabloque, out npaginas);
                                    //ocr_info(i + 1, EstadoProcesoOcr.pfindocx.GetStringValue());
                                }
                                if (valor.Equals(valorxls))
                                {
                                    ocr_info(i + 1, EstadoProcesoOcr.pinixls.GetStringValue());
                                    XMLXLSTHREAD(archivo.Path, listabloque, i + 1, filesxml.Count, out npaginas);
                                    ocr_info(i + 1, EstadoProcesoOcr.pfinxls.GetStringValue());
                                }
                                if (valor.Equals(valorxlsx))
                                {
                                    ocr_info(i + 1, EstadoProcesoOcr.pinixlsx.GetStringValue());
                                    XMLXLSTHREAD(archivo.Path, listabloque, i + 1, filesxml.Count, out npaginas);
                                    ocr_info(i + 1, EstadoProcesoOcr.pfinxlsx.GetStringValue());
                                }
                            }
                            catch (NullReferenceException error)
                            {
                                _blockThread.Set();
                                excepciondir = new ExceptionThreadOCRErrors(true, error.Message);
                            }

                            catch (IOException error)
                            {
                                _blockThread.Set();
                                excepciondir = new ExceptionThreadOCRErrors(true, error.Message);
                            }
                            catch (Exception error)
                            {
                                _blockThread.Set();
                                excepcion = new ExceptionThreadOCR(true, error.Message);
                            }

                        };
                        Thread mainTableGetter = new Thread(_ts);
                        mainTableGetter.Name = "OCRPDFTXTTHREADAsync";
                        mainTableGetter.Start();
                        mainTableGetter.Join();

                        GC.GetTotalMemory(true);
                        if (mainTableGetter != null)
                        {
                            mainTableGetter = null;
                        }
                        System.GC.Collect();
                        if (excepcion.IsException)
                        {
                            throw excepcion;
                        }
                        if (excepciondir.IsException)
                        {
                            throw excepciondir;
                        }

                        GC.WaitForPendingFinalizers();


                    }
                    if (!valor.Equals(valordocx) && !valor.Equals(valordoc))
                    {
                        FileInfo archivoinfo = new FileInfo(archivo.Path);
                        lista.Add(new ArchivoProceso(archivo.Path, archivoinfo.Length, formato));
                    }
                }
                foreach (ArchivoProceso archivo in listaarchivos)
                {
                    FormatoExp formato = archivo.Formato;
                    string valor = formato.Valor.ToLower();

                    ThreadStart _tsword = delegate
                    {
                        try
                        {

                            if (valor.Equals(valordoc))
                            {
                                ocr_info(1, EstadoProcesoOcr.pinidoc.GetStringValue());
                                XMLDOCTHREAD(archivo.Path, listabloqueword, out npaginas);
                                ocr_info(filesxml.Count, EstadoProcesoOcr.pfindoc.GetStringValue());
                            }
                            if (valor.Equals(valordocx))
                            {
                                ocr_info(1, EstadoProcesoOcr.pinidocx.GetStringValue());
                                XMLDOCTHREAD(archivo.Path, listabloqueword, out npaginas);
                                ocr_info(filesxml.Count, EstadoProcesoOcr.pfindocx.GetStringValue());
                            }
                        }

                        catch (NullReferenceException error)
                        {
                            _blockThread.Set();
                            excepciondir = new ExceptionThreadOCRErrors(true, error.Message);
                        }

                        catch (IOException error)
                        {
                            _blockThread.Set();
                            excepciondir = new ExceptionThreadOCRErrors(true, error.Message);
                        }
                        catch (Exception error)
                        {
                            _blockThread.Set();
                            excepcion = new ExceptionThreadOCR(true, error.Message);
                        }

                    };
                    Thread mainTableGetterWord = new Thread(_tsword);
                    mainTableGetterWord.Name = "OCRPDFTXTTHREADAsync";
                    mainTableGetterWord.Start();
                    mainTableGetterWord.Join();

                    GC.GetTotalMemory(true);
                    if (mainTableGetterWord != null)
                    {
                        mainTableGetterWord = null;
                    }
                    System.GC.Collect();
                    if (excepcion.IsException)
                    {
                        throw excepcion;
                    }
                    if (excepciondir.IsException)
                    {
                        throw excepciondir;
                    }

                    GC.WaitForPendingFinalizers();

                    if (valor.Equals(valordocx) || valor.Equals(valordoc))
                    {
                        FileInfo archivoinfo = new FileInfo(archivo.Path);
                        lista.Add(new ArchivoProceso(archivo.Path, archivoinfo.Length, formato));
                    }
                }


                GENERARPROCESOXML(unfilename, proceso, lista);
                npaginas = filesxml.Count;
                return npaginas;

            }
            catch (Exception erro)
            {

                return -1;
            }
           
        }
        private static bool numeroPagina(String s,int pagina)
        {
            if(s.Contains("_pag"+pagina.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int ExportarTXT(string untxtoutput,List<BloqueTexto> listabloque)
        {

            int npaginas = 0;

            ExceptionThreadOCR excepcion = new ExceptionThreadOCR();
            ExceptionThreadOCRErrors excepciondir = new ExceptionThreadOCRErrors();
            ThreadStart _ts = delegate
            {
                try
                {
                    XMLTXTTHREAD(untxtoutput, listabloque, out npaginas);
                }
                catch (NullReferenceException error)
                {
                    _blockThread.Set();
                    excepciondir = new ExceptionThreadOCRErrors(true, error.Message);
                }
                catch (IOException error)
                {
                    _blockThread.Set();
                    excepciondir = new ExceptionThreadOCRErrors(true, error.Message);
                }
                catch (Exception error)
                {
                    _blockThread.Set();
                    excepcion = new ExceptionThreadOCR(true, error.Message);
                }

            };
            Thread mainTableGetter = new Thread(_ts);
            mainTableGetter.Name = "OCRPDFTXTTHREADAsync";
            mainTableGetter.Start();
            mainTableGetter.Join();
            GC.GetTotalMemory(true);
            if (mainTableGetter != null)
            {
                mainTableGetter = null;
            }
            System.GC.Collect();
            if (excepcion.IsException)
            {
                throw excepcion;
            }
            if (excepciondir.IsException)
            {
                throw excepciondir;
            }
            //GC.ReRegisterForFinalize(this);
            GC.WaitForPendingFinalizers();
            return npaginas;
        }
        private static void XMLTXTTHREAD(string untxtoutput, List<BloqueTexto> listabloque, out int npaginas)
        {
            int npag = 1;
            StringBuilder btextodoc = new StringBuilder();
            int lineaanteriror = 0;
            for (int i = 0; i < listabloque.Count; i++)
            {
                if (i == 0)
                {
                    lineaanteriror = listabloque[i].LineaOcr;
                }
                string espacioblanco = " ";
                for (int k = 0; k < listabloque[i].Blanks - 1; k++)
                {
                    espacioblanco += " ";
                }
                if (cancelado)
                {
                    npaginas = -1;
                    return;
                }
                if (lineaanteriror != listabloque[i].LineaOcr)
                {
                    btextodoc.Append(saltolinea);
                    lineaanteriror = listabloque[i].LineaOcr;

                }
                btextodoc.Append(espacioblanco + listabloque[i].Texto);
            }
            btextodoc.Append(saltolinea);
            StreamWriter writertxt = new StreamWriter(untxtoutput, true);
            writertxt.Write(btextodoc);
            writertxt.Close();
            System.GC.Collect();
            GC.WaitForPendingFinalizers();
            npaginas = npag;
        }
        private static void XMLXMLTHREAD(string unxmloutput, string unxmlfile,int npagina, out int npaginas)
        {
            if (npagina == 0)
            {
                XmlOcr.InicializarXmlExportado(unxmloutput);
            }
            int npag = 1;
            XmlOcr.CuerpoPaginaExportado(unxmloutput, unxmlfile);            
            System.GC.Collect();
            GC.WaitForPendingFinalizers();
            npaginas = npag;
        }
        private static void XMLDOCTHREAD(string undocoutput, List<BloqueTexto> listabloque, out int npaginas)
        {
            int npag = 1;
            
            int lineaanteriror = 0;
            //OBJECT OF MISSING "NULL VALUE"
            Object oMissing = System.Reflection.Missing.Value;
            //OBJECTS OF FALSE AND TRUE
            Object oTrue = true;
            Object oFalse = false;
            object filename = undocoutput;
            //CREATING OBJECTS OF WORD AND DOCUMENT
            Application oWord = new Microsoft.Office.Interop.Word.Application();
            Document oWordDoc = new Microsoft.Office.Interop.Word.Document();
            try
            {
                if (oWord == null)
                {
                    npaginas = -1;
                    return;
                }
                //if (!File.Exists(undocoutput))
                //{
                //    File.Create(undocoutput);
                //}
               
                if (File.Exists(undocoutput))
                {
                    object oVisible = false;
                    oWordDoc = oWord.Documents.Open(ref filename, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oVisible, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                    //object oCollapseEnd = WdCollapseDirection.wdCollapseEnd;
                    
                    //    oWord.Selection.Collapse(ref  oCollapseEnd);
                    //    int val = oWord.Selection.Text.Length;
                    //    oWord.Selection.SetRange(oWord.Selection.Text.Length-1, oWord.Selection.Text.Length-1);
                    //    object a = WdGoToItem.wdGoToLine;
                    //    object b = WdGoToDirection.wdGoToLast;
                    //    oWord.Selection.GoTo(ref a, ref b, ref oMissing, ref oMissing);
                    
                   
                }


                //MAKING THE APPLICATION VISIBLE
                oWord.Visible = false;
                //ADDING A NEW DOCUMENT TO THE APPLICATION
                if (!File.Exists(undocoutput))
                {
                    oWordDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                }
                
                for (int i = 0; i < listabloque.Count; i++)
                {

                    if (i == 0)
                    {
                        lineaanteriror = listabloque[i].LineaOcr;
                    }
                    string espacioblanco = " ";
                    for (int k = 0; k < listabloque[i].Blanks - 1; k++)
                    {
                        espacioblanco += " ";
                    }
                    if (cancelado)
                    {
                        npaginas = -1;
                        return;
                    }
                    if (lineaanteriror != listabloque[i].LineaOcr)
                    {
                        oWord.Selection.TypeText(saltolinea);
                        lineaanteriror = listabloque[i].LineaOcr;

                    }

                    if (listabloque[i].Fuente >= 4)
                    {
                        oWord.Selection.Font.Bold = 1;
                    }
                    else
                    {
                        oWord.Selection.Font.Bold = 0;
                    }

                    oWord.Selection.Font.Color = WdColor.wdColorBlack;
                    oWord.Selection.Font.Size = 10;
                    oWord.Selection.TypeText(espacioblanco + listabloque[i].Texto);

                    

                }
                for (int c = 0; c < 2; c++)
                {
                    oWord.Selection.TypeText(saltolinea);
                }

                //  btextodoc.Append(saltolinea);



                Object oSaveAsFile = (Object)undocoutput;

                oWordDoc.SaveAs(ref oSaveAsFile, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);
                //CLOSING THE FILE
            }
            catch (Exception error)
            {
                Console.Beep();
            }
            oWordDoc.Close(ref oFalse, ref oMissing, ref oMissing);
            //QUITTING THE APPLICATION
            oWord.Quit(ref oMissing, ref oMissing, ref oMissing);
          
            System.GC.Collect();
            GC.WaitForPendingFinalizers();
            npaginas = npag;
        }
        private static void XMLXLSTHREAD(string unxlsoutput, List<BloqueTexto> listabloque, int upagina, int unpag,out int npaginas)
        {
            int npag = 1;
            npaginas = -1;
            int lineaanteriror = 0;
            Object oMissing = System.Reflection.Missing.Value;
            Object oTrue = true;
            Object oFalse = false;
            object oVisible = false;
            DataTable dt=UtilDataTable.ParseBloque(listabloque);
            if (dt == null || dt.Rows.Count == 0) return;
            Microsoft.Office.Interop.Excel.Application xlApp =
                    new Microsoft.Office.Interop.Excel.Application();
            try
            {
                if (xlApp == null)
                {
                    return;
                }
                
                System.Globalization.CultureInfo CurrentCI =
                       System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture =
                        new System.Globalization.CultureInfo("en-US");
                Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook workbook = null;
                Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
                Microsoft.Office.Interop.Excel.Range range;
                //if (!File.Exists(unxlsoutput))
                //{
                //    File.Create(unxlsoutput);
                //}
                if (!File.Exists(unxlsoutput))
                {
                    workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                    worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];

                }
                else
                {

                    workbook = xlApp.Workbooks.Open(unxlsoutput,
                            0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
                            true, false, 0, true, false, false);
                    // workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);

                    worksheet = (Microsoft.Office.Interop.Excel.Worksheet)xlApp.Worksheets.Add(oMissing, (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[upagina - 1], oMissing, oMissing);

                    //(Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
                }
                //xlApp.Visible = true;
                xlApp.Visible = false;

                long totalCount = dt.Rows.Count;
                long rowRead = 0;
                float percent = 0;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, i + 1];
                    range.Interior.ColorIndex = 15;
                }
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        try
                        {
                            worksheet.Cells[r + 2, i + 1] = dt.Rows[r][i].ToString();
                        }
                        catch
                        {
                            worksheet.Cells[r + 2, i + 1] =
                         dt.Rows[r][i].ToString().Replace("=", "");
                        }
                    }
                    rowRead++;
                    percent = ((float)(100 * rowRead)) / totalCount;
                }

                Object oSaveAsFile = (Object)unxlsoutput;
               
                if (!File.Exists(unxlsoutput))
                {
                    workbook.SaveAs(oSaveAsFile, oMissing, oMissing, oMissing,
                             oMissing, oMissing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, oMissing, oMissing,
                             oMissing, oMissing, oMissing);
                    workbook.Close(oFalse, oSaveAsFile, oMissing);
                }
                else
                {
                    workbook.Save();
                }

                //QUITTING THE APPLICATION

                xlApp.Quit();
            }
            catch (Exception error)
            {
                xlApp.Quit();
            }
            System.GC.Collect();
            GC.WaitForPendingFinalizers();
            npaginas = npag;
        }
        private static void XMLPDFTHREAD(string untifsource,string unpdfoutput, List<BloqueTexto> listabloque, int pagina, bool isdeskew, out int npaginas)
        {
            int npag = 1;

            PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();
            PdfSharp.Pdf.PdfDocument inputDocument = new PdfSharp.Pdf.PdfDocument(); ;
            if (File.Exists(unpdfoutput))
            {
                inputDocument = PdfSharp.Pdf.IO.PdfReader.Open(unpdfoutput, PdfSharp.Pdf.IO.PdfDocumentOpenMode.Import);
               

            }
            for (int c = 0; c < inputDocument.PageCount + 1; c++)
            {
                if (c == pagina)
                {
                    using (TiffManager tifman = new TiffManager(untifsource))
                    {


                        Bitmap imagetmep = new Bitmap(tifman.GetSpecificPage(pagina));
                        if (isdeskew)
                        {

                            EncoderParameters parm = new EncoderParameters(1);
                            EncoderParameter pa = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionLZW);
                            parm.Param[0] = pa;
                            imagetmep = PixelImageManager.SaveGIFWithNewColorTable((imagetmep), 256, true);
                            if (cancelado)
                            {
                                npaginas = -1;
                                return;
                            }
                            imagetmep = AForgeDeskew.DeskewImagen(imagetmep);
                        }
                        try
                                {
                        using (Bitmap imagetest = imagetmep)
                        {
                            PdfSharp.Pdf.PdfPage page = document.AddPage();
                            XGraphics gfx = XGraphics.FromPdfPage(page);
                            XImage imgsharp = XImage.FromGdiPlusImage((Image)imagetest);
                            PdfSharp.PageSize siz = page.Size;
                            page.Height = imgsharp.PixelHeight;
                            page.Width = imgsharp.PixelWidth;

                            for (int i = 0; i < listabloque.Count; i++)
                            {
                                
                                    XFont font = new XFont("Verdana", listabloque[i].H, XFontStyle.Regular);
                                    RectangleF rec = new RectangleF((float)listabloque[i].X, (float)listabloque[i].Y, (float)listabloque[i].W, (float)listabloque[i].H);
                                    gfx.DrawString(listabloque[i].Texto, font, XBrushes.Black, rec, XStringFormats.TopCenter);
                               
                            }
                            gfx.DrawImage(imgsharp, 0, 0, imgsharp.PixelWidth, imgsharp.PixelHeight);
                            gfx.Save();
                            gfx.Dispose();
                            imagetest.Dispose();
                            imgsharp.Dispose();
                            System.GC.Collect();
                            GC.WaitForPendingFinalizers();
                        }
                                }
                        catch (Exception error)
                        {
                            Console.Beep();
                        }

                    }
                }
                else
                {
                    document.AddPage(inputDocument.Pages[c]);
                }
            }

           document.Save(unpdfoutput);



           try
           {
               ThreadStart _ts = delegate { PDFOCROptimized.ResizePDFOCR(unpdfoutput); };
               Thread mainGetter = new Thread(_ts);
               mainGetter.Start();
               mainGetter.Join();
               if (mainGetter != null)
               {
                   mainGetter = null;
               }
               System.GC.Collect();
               GC.WaitForPendingFinalizers();
              
           }
           catch (Exception error)
           {
               Console.Beep();
           }
           npaginas = 1;
        }
        private static void GENERARPROCESOXML(string unfilename,Proceso proceso,List<ArchivoProceso> lista)
        {
            FileInfo file=new FileInfo(unfilename);
            string nombrexml = file.Name.Replace(file.Extension,".xml");
            string nombreprocesoxml=XmlOcr.InicializarXmlProceso(file.DirectoryName,nombrexml);
            XmlOcr.ProcesamientoCabecera(nombreprocesoxml, proceso.Sec_Proceso, proceso.Estado);
            foreach (ArchivoProceso archivo in lista)
            {
                XmlOcr.Procesamiento(nombreprocesoxml,archivo.Path, archivo.Tamanio, archivo.Formato.Sec, archivo.Formato.Valor);
            }
        }
        private static void GENERARARCHIVOXML(string unfilename, Proceso proceso, List<ArchivoProceso> lista)
        {
            FileInfo file = new FileInfo(unfilename);
            string nombrexml = file.Name.Replace(file.Extension, ".xml");
            string nombreprocesoxml = XmlOcr.InicializarXmlProceso(file.DirectoryName, nombrexml);
            XmlOcr.ProcesamientoCabecera(nombreprocesoxml, proceso.Sec_Proceso, proceso.Estado);
            foreach (ArchivoProceso archivo in lista)
            {
                XmlOcr.Procesamiento(nombreprocesoxml, archivo.Path, archivo.Tamanio, archivo.Formato.Sec, archivo.Formato.Valor);
            }
        }
    }
}
