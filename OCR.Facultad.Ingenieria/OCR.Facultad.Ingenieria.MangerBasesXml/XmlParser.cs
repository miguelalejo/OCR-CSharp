using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OCR.Facultad.Ingenieria.ManagerBases;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetRutaTableAdapters;
using OCR.Facultad.Ingenieria.ManagerBases.DataSetTipo_DocumentalTableAdapters;
using System.Xml;
namespace OCR.Facultad.Ingenieria.MangerBasesXml
{
    public class XmlParser
    {
        static rutaTableAdapter adaptadorruta = new rutaTableAdapter();
        static tipo_documentalTableAdapter adaptadortipo_documental = new tipo_documentalTableAdapter();
        public static DataSetOcr.ocrRow ParseXAXmlOcr(string unombrearchivo,  int uocr_nume_radi,int uocr_batch_ocr)
        {
            XmlDocument originalXml = new XmlDocument();
            originalXml.Load(unombrearchivo);
            XmlNodeList archivo = originalXml.GetElementsByTagName("archivo");
            XmlNodeList cabecera = ((XmlElement)archivo[0]).GetElementsByTagName("cabecera");
            DataSetOcr.ocrRow fila=new DataSetOcr.ocrDataTable().NewocrRow();
            fila.ocr_batch_ocr = uocr_batch_ocr;
            fila.ocr_nume_radi = uocr_nume_radi;
            foreach (XmlElement nodo in cabecera)
            {
                List<MapaNodoXml> listamapa = new List<MapaNodoXml>();
                listamapa.Add(new MapaNodoXml("fechamodificacion", nodo.GetAttribute("fechamodificacion")));
                listamapa.Add(new MapaNodoXml("fechacreacion", nodo.GetAttribute("fechacreacion")));
                listamapa.Add(new MapaNodoXml("extencion", nodo.GetAttribute("extencion")));
                listamapa.Add(new MapaNodoXml("tamanio", nodo.GetAttribute("tamanio")));
                listamapa.Add(new MapaNodoXml("directorio", nodo.GetAttribute("directorio")));
                listamapa.Add(new MapaNodoXml("nombre", nodo.GetAttribute("nombre")));
                             
          
                foreach (MapaNodoXml mapa in listamapa)
                {

                    if (mapa.Key == "fechamodificacion")
                    {
                        fila.ocr_fechamodificacion = Convert.ToDateTime(mapa.Valor);
                        continue;
                    }

                    if (mapa.Key == "fechacreacion")
                    {
                        fila.ocr_fechacreacion = Convert.ToDateTime(mapa.Valor);
                        continue;
                    }

                    if (mapa.Key == "extencion")
                    {                        
                        string extencion = mapa.Valor.Replace(".","");
                        int idextencion = 0;
                        idextencion=(int)adaptadortipo_documental.FillByTipoExtencion(extencion);
                        fila.ocr_tipo_documental = idextencion;
                        fila.ocr_tipo_documental_valor = extencion.ToUpper();
                        continue;
                    }
                    if (mapa.Key == "tamanio")
                    {
                        fila.ocr_tamanio = Convert.ToInt32(mapa.Valor);
                        continue;
                    }

                    if (mapa.Key == "directorio")
                    {
                        fila.ocr_directorio = mapa.Valor;
                        continue;
                    }
                    if (mapa.Key == "nombre")
                    {
                        fila.ocr_nombre = mapa.Valor;
                        continue;
                    }                  

                }               
            }
            XmlNodeList imagen = ((XmlElement)archivo[0]).GetElementsByTagName("imagen");
            foreach (XmlElement nodo in imagen)
            {
                List<MapaNodoXml> listamapa = new List<MapaNodoXml>();
                listamapa.Add(new MapaNodoXml("profundidadbits", nodo.GetAttribute("profundidadbits")));
                listamapa.Add(new MapaNodoXml("horizontal", nodo.GetAttribute("horizontal")));
                listamapa.Add(new MapaNodoXml("vertical", nodo.GetAttribute("vertical")));
                listamapa.Add(new MapaNodoXml("alto", nodo.GetAttribute("alto")));
                listamapa.Add(new MapaNodoXml("ancho", nodo.GetAttribute("ancho")));
           
                foreach (MapaNodoXml mapa in listamapa)
                {

                    if (mapa.Key == "profundidadbits")
                    {
                        fila.ocr_profundidadbits= Convert.ToInt32(mapa.Valor);
                        continue;
                    }

                    if (mapa.Key == "horizontal")
                    {
                        fila.ocr_horizontal = (float)Convert.ToDouble(mapa.Valor);
                        continue;
                    }

                    if (mapa.Key == "vertical")
                    {
                        fila.ocr_vertical = (float)Convert.ToDouble(mapa.Valor);
                        continue;
                       
                    }
                    if (mapa.Key == "alto")
                    {
                        fila.ocr_alto = (float)Convert.ToDouble(mapa.Valor);
                        continue;
                    }

                    if (mapa.Key == "ancho")
                    {
                        fila.ocr_ancho = (float)Convert.ToDouble(mapa.Valor);
                        continue;
                    }
                }
            }
            XmlNodeList ocr = ((XmlElement)archivo[0]).GetElementsByTagName("ocr");
            foreach (XmlElement nodo in ocr)
            {
                List<MapaNodoXml> listamapa = new List<MapaNodoXml>();
                listamapa.Add(new MapaNodoXml("estado", nodo.GetAttribute("estado")));
                listamapa.Add(new MapaNodoXml("fechafinproces", nodo.GetAttribute("fechafinproces")));
                listamapa.Add(new MapaNodoXml("fechainiproces", nodo.GetAttribute("fechainiproces")));
                listamapa.Add(new MapaNodoXml("npaginas", nodo.GetAttribute("npaginas")));
                listamapa.Add(new MapaNodoXml("nlineas", nodo.GetAttribute("nlineas")));
                listamapa.Add(new MapaNodoXml("npalabras", nodo.GetAttribute("npalabras")));
                listamapa.Add(new MapaNodoXml("ncaracteres", nodo.GetAttribute("ncaracteres")));

                foreach (MapaNodoXml mapa in listamapa)
                {

                    if (mapa.Key == "estado")
                    {
                        fila.ocr_estado = Convert.ToBoolean(mapa.Valor);
                        continue;
                    }

                    if (mapa.Key == "fechafinproces")
                    {
                        fila.ocr_fechafinproces = Convert.ToDateTime(mapa.Valor);
                        continue;
                    }

                    if (mapa.Key == "fechainiproces")
                    {
                        fila.ocr_fechainiproces = Convert.ToDateTime(mapa.Valor);
                        continue;

                    }
                    if (mapa.Key == "npaginas")
                    {
                        fila.ocr_npaginas = Convert.ToInt32(mapa.Valor);
                        continue;
                    }
                    if (mapa.Key == "nlineas")
                    {
                        fila.ocr_nlineas = Convert.ToInt32(mapa.Valor);
                        continue;
                    }
                    if (mapa.Key == "npalabras")
                    {
                        fila.ocr_npalabras = Convert.ToInt32(mapa.Valor);
                        continue;
                    }
                    if (mapa.Key == "ncaracteres")
                    {
                        fila.ocr_ncaracteres = Convert.ToInt32(mapa.Valor);
                        continue;
                    }                  
                }
            }
            return fila;
        }
        public static DataSetOcr_Pagina.ocr_paginaRow ParseXPagXmlOcr_Pagina(string unombrearchivo, int uocr_pag_nume_radi, int uocr_pag_batch_ocr)
        {
            XmlDocument originalXml = new XmlDocument();
            originalXml.Load(unombrearchivo);
            XmlNodeList pagina = originalXml.GetElementsByTagName("pagina");
            XmlNodeList cabecerapagina = ((XmlElement)pagina[0]).GetElementsByTagName("cabecerapagina");
            DataSetOcr_Pagina.ocr_paginaRow fila = new DataSetOcr_Pagina.ocr_paginaDataTable().Newocr_paginaRow();
            fila.ocr_pag_batch_ocr = uocr_pag_batch_ocr;
            fila.ocr_pag_nume_radi = uocr_pag_nume_radi;
            foreach (XmlElement nodo in cabecerapagina)
            {
                List<MapaNodoXml> listamapa = new List<MapaNodoXml>();
                listamapa.Add(new MapaNodoXml("fechafinproces", nodo.GetAttribute("fechafinproces")));
                listamapa.Add(new MapaNodoXml("fechainiproces", nodo.GetAttribute("fechainiproces")));
                listamapa.Add(new MapaNodoXml("nlineas", nodo.GetAttribute("nlineas")));
                listamapa.Add(new MapaNodoXml("npalabras", nodo.GetAttribute("npalabras")));
                listamapa.Add(new MapaNodoXml("ncaracteres", nodo.GetAttribute("ncaracteres")));
                listamapa.Add(new MapaNodoXml("secpagina", nodo.GetAttribute("secpagina")));
                foreach (MapaNodoXml mapa in listamapa)
                {
                    if (mapa.Key == "fechafinproces")
                    {
                        fila.ocr_pag_fechafinproces = Convert.ToDateTime(mapa.Valor);
                        continue;
                    }
                    if (mapa.Key == "fechainiproces")
                    {
                        fila.ocr_pag_fechainiproces = Convert.ToDateTime(mapa.Valor);
                        continue;
                    }

                    if (mapa.Key == "nlineas")
                    {
                        fila.ocr_pag_nlineas = Convert.ToInt32(mapa.Valor);
                        continue;
                    }
                    if (mapa.Key == "npalabras")
                    {
                        fila.ocr_pag_npalabras = Convert.ToInt32(mapa.Valor);
                        continue;
                    }
                    if (mapa.Key == "ncaracteres")
                    {
                        fila.ocr_pag_ncaracteres = Convert.ToInt32(mapa.Valor);
                        continue;
                    }
                    if (mapa.Key == "secpagina")
                    {
                        fila.ocr_pag_secpagina = Convert.ToInt32(mapa.Valor);
                        continue;
                    }

                }
            }
            return fila;
        }

        public static List<DataSetOcr_Exportado.ocr_exportadoRow> ParseXPXmlOcr_Pagina(string unombrearchivo, int uocr_exp_nume_radi, int uocr_exp_batch_ocr)
        {
            XmlDocument originalXml = new XmlDocument();
            originalXml.Load(unombrearchivo);
            XmlNodeList proceso = originalXml.GetElementsByTagName("proceso");
            XmlNodeList archivo = ((XmlElement)proceso[0]).GetElementsByTagName("archivo");
            List<DataSetOcr_Exportado.ocr_exportadoRow> lista = new List<DataSetOcr_Exportado.ocr_exportadoRow>();
            foreach (XmlElement nodo in archivo)
            {
                DataSetOcr_Exportado.ocr_exportadoRow fila = new DataSetOcr_Exportado.ocr_exportadoDataTable().Newocr_exportadoRow();
                fila.ocr_exp_nume_radi = uocr_exp_nume_radi;
                fila.ocr_exp_batch_ocr = uocr_exp_batch_ocr;
                
                List<MapaNodoXml> listamapa = new List<MapaNodoXml>();
                listamapa.Add(new MapaNodoXml("tamanio", nodo.GetAttribute("tamanio")));
                listamapa.Add(new MapaNodoXml("path", nodo.GetAttribute("path")));
                listamapa.Add(new MapaNodoXml("valor", nodo["formato"].GetAttribute("valor")));
                 foreach (MapaNodoXml mapa in listamapa)
                {
                    if (mapa.Key == "tamanio")
                    {
                        fila.ocr_exp_tamanio= Convert.ToInt32(mapa.Valor);
                        continue;
                    }
                    if (mapa.Key == "path")
                    {
                        fila.ocr_exp_path=mapa.Valor;
                        continue;
                    }

                    if (mapa.Key == "valor")
                    {
                        string extencion = mapa.Valor.Replace(".", "");
                        int idextencion = 0;
                        idextencion = (int)adaptadortipo_documental.FillByTipoExtencion(extencion);
                        fila.ocr_exp_tipo_documental = idextencion;
                        fila.ocr_exp_tipo_documental_valor = extencion.ToUpper();
                        fila.ocr_exp_ruta = adaptadorruta.GetDataByRuta_TipoDocumental(idextencion)[0].ru_id;
                        continue;
                    }
                }
                 lista.Add(fila);
            }
            return lista;
        }
        public static List<DataSetOcr_Linea.ocr_lineaRow> ParseXPagXmlOcr(string unombrearchivo, int uocr_lin_nume_radi, int uocr_lin_batch_ocr, int upag)
        {
            List<BloqueTexto> lista = BloqueTextoXml.ParseXmlBloqueTexto(unombrearchivo);

            List<DataSetOcr_Linea.ocr_lineaRow> listalinea = new List<DataSetOcr_Linea.ocr_lineaRow>();
            
            foreach (BloqueTexto fila in lista)
            {
                DataSetOcr_Linea.ocr_lineaRow filalinea=new DataSetOcr_Linea.ocr_lineaDataTable().Newocr_lineaRow();
                filalinea.ocr_lin_nume_radi = uocr_lin_nume_radi;
                filalinea.ocr_lin_batch_ocr = uocr_lin_batch_ocr;
                
                filalinea.ocr_lin_blanks=fila.Blanks;
                filalinea.ocr_lin_confidence=fila.Confidence;
                filalinea.ocr_lin_fuente=fila.Fuente;
                filalinea.ocr_lin_largo=fila.H;
                filalinea.ocr_lin_linea=fila.Linea;
                filalinea.ocr_lin_lineaocr=fila.LineaOcr;
                filalinea.ocr_lin_pag_secpagina=upag;
                filalinea.ocr_lin_pointsize=fila.Pointsize;
                filalinea.ocr_lin_secpalabra=fila.SecPalabra;
                filalinea.ocr_lin_texto=fila.Texto;
                filalinea.ocr_lin_tipodato=fila.Tipodato.ToString();
                filalinea.ocr_lin_x=fila.X;
                filalinea.ocr_lin_y=fila.Y;
                filalinea.ocr_lin_ancho=fila.W;
                listalinea.Add(filalinea);
                
            }
            return listalinea;
        }
    }
}
