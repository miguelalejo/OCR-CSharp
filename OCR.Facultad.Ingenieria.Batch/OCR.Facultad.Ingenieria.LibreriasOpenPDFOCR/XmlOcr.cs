using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace OCR.Facultad.Ingenieria.LibreriasOpenPDFOCR
{
    public class XmlOcr
    {
        public static bool CabeceraPagina(string unombrearchivo, int usecpagina, int uncaracteres, int unpalabras, int unlineas, DateTime ufechainiproces, DateTime ufechafinproces)
        {
            try
            {
                XmlDocument originalXml = new XmlDocument();
                originalXml.Load(unombrearchivo);
                XmlNodeList cuerpo = originalXml.GetElementsByTagName("cuerpo");
                XmlNode nodocuerpo = (XmlNode)cuerpo[0];
                XmlNode cabecerapagina = originalXml.GetElementsByTagName("cabecerapagina")[0];
                XmlAttribute secpagina = originalXml.CreateAttribute("secpagina");
                secpagina.Value = usecpagina.ToString();
                XmlAttribute ncaracteres = originalXml.CreateAttribute("ncaracteres");
                ncaracteres.Value = uncaracteres.ToString();
                XmlAttribute npalabras = originalXml.CreateAttribute("npalabras");
                npalabras.Value = unpalabras.ToString();
                XmlAttribute nlineas = originalXml.CreateAttribute("nlineas");
                nlineas.Value = unlineas.ToString();
                XmlAttribute fechainiproces = originalXml.CreateAttribute("fechainiproces");
                fechainiproces.Value = ufechainiproces.ToString();
                XmlAttribute fechafinproces = originalXml.CreateAttribute("fechafinproces");
                fechafinproces.Value = ufechafinproces.ToString();
                cabecerapagina.Attributes.Append(secpagina);
                cabecerapagina.Attributes.Append(ncaracteres);
                cabecerapagina.Attributes.Append(npalabras);
                cabecerapagina.Attributes.Append(nlineas);
                cabecerapagina.Attributes.Append(fechainiproces);
                cabecerapagina.Attributes.Append(fechafinproces);
                originalXml.Save(unombrearchivo);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }
        public static bool ProcesamientoCabecera(string unombrearchivo, int usecproceso ,bool uestado)
        {
            try
            {
                XmlDocument originalXml = new XmlDocument();
                originalXml.Load(unombrearchivo);
                XmlNodeList proceso = originalXml.GetElementsByTagName("proceso");
                XmlNode nodoproceso = (XmlNode)proceso[0];
                XmlAttribute secproceso = originalXml.CreateAttribute("secproceso");
                secproceso.Value = usecproceso.ToString();
                XmlAttribute estado = originalXml.CreateAttribute("estado");
                estado.Value = uestado.ToString();
                nodoproceso.Attributes.Append(secproceso);
                nodoproceso.Attributes.Append(estado);
                originalXml.Save(unombrearchivo);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }
        public static bool Procesamiento(string unombrearchivo,string upath,long utamanio,int usec, string uvalor)
        {
            try
            {  

                XmlDocument originalXml = new XmlDocument();
                originalXml.Load(unombrearchivo);
                XmlNodeList proceso = originalXml.GetElementsByTagName("proceso");
                XmlNode nodoproceso = (XmlNode)proceso[0];
                XmlNode archivo = originalXml.CreateNode(XmlNodeType.Element, "archivo", null);
                XmlAttribute path = originalXml.CreateAttribute("path");
                path.Value = upath.ToString();
                archivo.Attributes.Append(path);
                XmlAttribute tamanio = originalXml.CreateAttribute("tamanio");
                tamanio.Value = utamanio.ToString();
                archivo.Attributes.Append(tamanio);
                XmlNode formato = originalXml.CreateNode(XmlNodeType.Element, "formato", null);
                {
                    XmlAttribute sec = originalXml.CreateAttribute("sec");
                    sec.Value = usec.ToString();
                    formato.Attributes.Append(sec);
                    XmlAttribute valor = originalXml.CreateAttribute("valor");
                    valor.Value = uvalor.ToString();
                    formato.Attributes.Append(valor);
                }
                archivo.AppendChild(formato);
                nodoproceso.AppendChild(archivo);
                originalXml.Save(unombrearchivo);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }
        public static bool ArchivoCabecera(string unombrearchivo, string unombre, string udirectorio, long utamanio, string uextencion, DateTime ufechacreacion, DateTime ufechamodificacion)
        {
            try
            {

                XmlDocument originalXml = new XmlDocument();
                originalXml.Load(unombrearchivo);
                XmlNodeList cabecera = originalXml.GetElementsByTagName("cabecera");
                XmlNode nodocabecera = (XmlNode)cabecera[0];
                XmlAttribute nombre = originalXml.CreateAttribute("nombre");
                nombre.Value = unombre.ToString();
                nodocabecera.Attributes.Append(nombre);

                XmlAttribute directorio = originalXml.CreateAttribute("directorio");
                directorio.Value = udirectorio.ToString();
                nodocabecera.Attributes.Append(directorio);

                XmlAttribute tamanio = originalXml.CreateAttribute("tamanio");
                tamanio.Value = utamanio.ToString();
                nodocabecera.Attributes.Append(tamanio);

                            

               
                XmlAttribute extencion = originalXml.CreateAttribute("extencion");
                extencion.Value = uextencion.ToString();
                nodocabecera.Attributes.Append(extencion);

                XmlAttribute fechacreacion = originalXml.CreateAttribute("fechacreacion");
                fechacreacion.Value = ufechacreacion.ToString();
                nodocabecera.Attributes.Append(fechacreacion);

                XmlAttribute fechamodificacion = originalXml.CreateAttribute("fechamodificacion");
                fechamodificacion.Value = ufechamodificacion.ToString();
                nodocabecera.Attributes.Append(fechamodificacion);
               
                originalXml.Save(unombrearchivo);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }
        public static bool ArchivoImagen(string unombrearchivo, int uancho, int ualto, float uvertical, float uhorizontal, int uprofundidadbits)
        {
            try
            {

                XmlDocument originalXml = new XmlDocument();
                originalXml.Load(unombrearchivo);
                XmlNodeList imagen = originalXml.GetElementsByTagName("imagen");
                XmlNode nodoimagen = (XmlNode)imagen[0];
                XmlAttribute ancho = originalXml.CreateAttribute("ancho");
                ancho.Value = uancho.ToString();
                nodoimagen.Attributes.Append(ancho);

                XmlAttribute alto = originalXml.CreateAttribute("alto");
                alto.Value = ualto.ToString();
                nodoimagen.Attributes.Append(alto);

                XmlAttribute vertical = originalXml.CreateAttribute("vertical");
                vertical.Value = uvertical.ToString();
                nodoimagen.Attributes.Append(vertical);

                XmlAttribute horizontal = originalXml.CreateAttribute("horizontal");
                horizontal.Value = uhorizontal.ToString();
                nodoimagen.Attributes.Append(horizontal);

                XmlAttribute profundidadbits = originalXml.CreateAttribute("profundidadbits");
                profundidadbits.Value = uprofundidadbits.ToString();
                nodoimagen.Attributes.Append(profundidadbits);

                originalXml.Save(unombrearchivo);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }
        public static bool ArchivoOcr(string unombrearchivo, int uncaracteres, int unpalabras, int unlineas,int unpaginas, DateTime ufechainiproces, DateTime ufechafinproces, bool uestado)
        {
            try
            {

                XmlDocument originalXml = new XmlDocument();
                originalXml.Load(unombrearchivo);
                XmlNodeList ocr = originalXml.GetElementsByTagName("ocr");
                XmlNode nodoocr = (XmlNode)ocr[0];
                XmlAttribute ncaracteres = originalXml.CreateAttribute("ncaracteres");
                ncaracteres.Value = uncaracteres.ToString();
                nodoocr.Attributes.Append(ncaracteres);

                XmlAttribute npalabras = originalXml.CreateAttribute("npalabras");
                npalabras.Value = unpalabras.ToString();
                nodoocr.Attributes.Append(npalabras);

                XmlAttribute nlineas = originalXml.CreateAttribute("nlineas");
                nlineas.Value = unlineas.ToString();
                nodoocr.Attributes.Append(nlineas);

                XmlAttribute npaginas = originalXml.CreateAttribute("npaginas");
                npaginas.Value = unpaginas.ToString();
                nodoocr.Attributes.Append(npaginas);

                XmlAttribute fechainiproces = originalXml.CreateAttribute("fechainiproces");
                fechainiproces.Value = ufechainiproces.ToString();
                nodoocr.Attributes.Append(fechainiproces);

                XmlAttribute fechafinproces = originalXml.CreateAttribute("fechafinproces");
                fechafinproces.Value = ufechafinproces.ToString();
                nodoocr.Attributes.Append(fechafinproces);


                XmlAttribute estado = originalXml.CreateAttribute("estado");
                estado.Value = uestado.ToString();
                nodoocr.Attributes.Append(estado);

                originalXml.Save(unombrearchivo);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }
        


        public static bool CuerpoPagina(string unombrearchivo, int usecpalabra, TypeCode utipodato, int upointsize, int ux, int uy, int ulargo, int uancho, int ulinea, int ulineaocr, int ufuente, double uconfidence, int ublanks, string utexto)
        {
            try
            {
                XmlDocument originalXml = new XmlDocument();
                originalXml.Load(unombrearchivo);
                XmlNodeList cuerpo = originalXml.GetElementsByTagName("cuerpo");
                XmlNode nodocuerpo = (XmlNode)cuerpo[0];
                XmlNode palabra = originalXml.CreateNode(XmlNodeType.Element, "palabra", null);
                XmlAttribute secpalabra = originalXml.CreateAttribute("secpalabra");
                secpalabra.Value = usecpalabra.ToString();
                palabra.Attributes.Append(secpalabra);
                XmlAttribute tipodato = originalXml.CreateAttribute("tipodato");
                tipodato.Value = utipodato.ToString();
                palabra.Attributes.Append(tipodato);
                XmlAttribute pointsize = originalXml.CreateAttribute("pointsize");
                pointsize.Value = upointsize.ToString();
                palabra.Attributes.Append(pointsize);

                XmlNode posicion = originalXml.CreateNode(XmlNodeType.Element, "posicion", null);
                {
                    XmlAttribute x = originalXml.CreateAttribute("x");
                    x.Value = ux.ToString();
                    posicion.Attributes.Append(x);
                    XmlAttribute y = originalXml.CreateAttribute("y");
                    y.Value = uy.ToString();
                    posicion.Attributes.Append(y);
                }
                palabra.AppendChild(posicion);

                XmlNode dimensiones = originalXml.CreateNode(XmlNodeType.Element, "dimensiones", null);
                {
                    XmlAttribute largo = originalXml.CreateAttribute("largo");
                    largo.Value = ulargo.ToString();
                    dimensiones.Attributes.Append(largo);
                    XmlAttribute ancho = originalXml.CreateAttribute("ancho");
                    ancho.Value = uancho.ToString();
                    dimensiones.Attributes.Append(ancho);
                }
                palabra.AppendChild(dimensiones);

                XmlAttribute fuente = originalXml.CreateAttribute("fuente");
                fuente.Value = ufuente.ToString();
                palabra.Attributes.Append(fuente);
                
                XmlAttribute linea = originalXml.CreateAttribute("linea");
                linea.Value = ulinea.ToString();
                palabra.Attributes.Append(linea);

                XmlAttribute lineaocr = originalXml.CreateAttribute("lineaocr");
                lineaocr.Value = ulineaocr.ToString();
                palabra.Attributes.Append(lineaocr);

                XmlAttribute blanks = originalXml.CreateAttribute("blanks");
                blanks.Value = ublanks.ToString();
                palabra.Attributes.Append(blanks);

                XmlAttribute confidence = originalXml.CreateAttribute("confidence");
                confidence.Value = uconfidence.ToString();
                palabra.Attributes.Append(confidence);

                XmlAttribute texto = originalXml.CreateAttribute("texto");
                texto.Value = utexto;
                palabra.Attributes.Append(texto);
                nodocuerpo.AppendChild(palabra);
                originalXml.Save(unombrearchivo);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }
        public static bool InicializarXmlPagina(string unombrearchivo)
        {
            try
            {
                File.Copy("xmlFiles/XPag.xml", unombrearchivo, true);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }
        public static string InicializarXmlArchivo(string directorio, string unombrearchivo)
        {
            try
            {
                File.Copy("xmlFiles/XA.xml", Path.Combine(directorio, "XA" + unombrearchivo), true);
                return Path.Combine(directorio, "XA" + unombrearchivo);
            }
            catch (Exception error)
            {
                return "";
            }
        }
        public static string InicializarXmlProceso(string directorio,string unombrearchivo)
        {
            try
            {
                File.Copy("xmlFiles/XP.xml", Path.Combine(directorio,"XP" + unombrearchivo), true);
                return Path.Combine(directorio, "XP" + unombrearchivo);
            }
            catch (Exception error)
            {
                return "";
            }
        }
        public static string InicializarXmlExportado(string unombrearchivo)
        {
            try
            {
                File.Copy("xmlFiles/X.xml", unombrearchivo, true);
                return unombrearchivo;
            }
            catch (Exception error)
            {
                return "";
            }
        }
        public static bool CuerpoPaginaExportado(string unombrearchivo, string unxmlxmlfile)
        {
            try
            {
                XmlDocument originalXml = new XmlDocument();
                originalXml.Load(unombrearchivo);
                XmlNodeList archivo = originalXml.GetElementsByTagName("archivo");
                XmlNode nodoarchivo = (XmlNode)archivo[0];
                XmlDocument paginaXml = new XmlDocument();
                paginaXml.Load(unxmlxmlfile);
                XmlNodeList pagina = paginaXml.GetElementsByTagName("pagina");
                XmlNode nodopagina = (XmlNode)pagina[0];
                XmlNode paginanueva = originalXml.CreateNode(XmlNodeType.Element, "pagina", null);
                paginanueva.InnerXml= nodopagina.InnerXml;
                
                nodoarchivo.AppendChild(paginanueva);
                originalXml.Save(unombrearchivo);
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }
        private static Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }


     }
}
