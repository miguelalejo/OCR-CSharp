using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace OCR.Facultad.Ingenieria.LibreriasOpenPDFOCR
{
    public class ConfiguracionXml
    {
        public static ConfiguracionProceso ParseXmlConfiguracion(string unombrearchivo)
        {
            XmlDocument originalXml = new XmlDocument();
            originalXml.Load(unombrearchivo);
            XmlNodeList configuracion = originalXml.GetElementsByTagName("configuracion");
            XmlNodeList proceso = ((XmlElement)configuracion[0]).GetElementsByTagName("proceso");
            ConfiguracionProceso configproceso = null;
            Proceso p=new Proceso();
            foreach (XmlElement nodo in proceso)
            {
                List<MapaNodoXml> listamapa = new List<MapaNodoXml>();

                listamapa.Add(new MapaNodoXml("secproceso", nodo.GetAttribute("secproceso")));
                listamapa.Add(new MapaNodoXml("descripcion", nodo.GetAttribute("descripcion")));
                listamapa.Add(new MapaNodoXml("deskew", nodo.GetAttribute("deskew")));
                listamapa.Add(new MapaNodoXml("nombrearchivo", nodo.GetAttribute("nombrearchivo")));
                listamapa.Add(new MapaNodoXml("pathorigen", nodo["origen"].GetAttribute("path")));
                int sec = 0;
                string descripcion = "";
                bool deskew = false;
                string nombrearchivo = "";
                string pathorigen = "";
                foreach (MapaNodoXml mapa in listamapa)
                {

                    if (mapa.Key == "secproceso")
                    {
                        sec = Convert.ToInt16(mapa.Valor);
                        continue;
                    }

                    if (mapa.Key == "descripcion")
                    {
                        descripcion = mapa.Valor;
                        continue;
                    }

                    if (mapa.Key == "deskew")
                    {
                        deskew = Convert.ToBoolean(mapa.Valor);
                        continue;
                    }
                    if (mapa.Key == "nombrearchivo")
                    {
                        nombrearchivo = mapa.Valor;
                        continue;
                    }
                    if (mapa.Key == "pathorigen")
                    {
                        pathorigen = mapa.Valor;
                        continue;
                    }
                  

                } 
                p = new Proceso(sec, descripcion, deskew, nombrearchivo, pathorigen);
            }

            List<RutaExportacion> listarutas = new List<RutaExportacion>();
            XmlNodeList rutas = ((XmlElement)configuracion[0]).GetElementsByTagName("rutas");
            foreach (XmlElement nodo in rutas)
            {
                List<MapaNodoXml> listamapa = new List<MapaNodoXml>();
                listamapa.Add(new MapaNodoXml("secruta", nodo.GetAttribute("secruta")));

                listamapa.Add(new MapaNodoXml("pathdestino", nodo["destino"].GetAttribute("path")));
                listamapa.Add(new MapaNodoXml("pathdestino", nodo["destino"].GetAttribute("path")));
                listamapa.Add(new MapaNodoXml("formato", nodo["formato"].GetAttribute("valor")));
                
                int secruta = 0;
             
                string pathdestino = "";
                string formato = "";

                foreach (MapaNodoXml mapa in listamapa)
                {

                    if (mapa.Key == "secruta")
                    {
                        secruta = Convert.ToInt16(mapa.Valor);
                        continue;
                    }                   

                    if (mapa.Key == "pathdestino")
                    {
                        pathdestino = mapa.Valor;
                        continue;
                    }
                    if (mapa.Key == "formato")
                    {

                        switch (mapa.Valor.ToLower())
                        {
                            case "doc":
                                {
                                    formato = FormatoExportacion.DOC.GetStringValue();
                                } break;
                            case "docx":
                                {
                                    formato = FormatoExportacion.DOCX.GetStringValue();
                                } break;
                            case "xls":
                                {
                                    formato = FormatoExportacion.XLS.GetStringValue();
                                } break;
                            case "xlsx":
                                {
                                    formato = FormatoExportacion.XLSX.GetStringValue();
                                } break;
                            case "pdf":
                                {
                                    formato = FormatoExportacion.PDF.GetStringValue();
                                } break;
                            case "txt":
                                {
                                    formato = FormatoExportacion.TXT.GetStringValue();
                                } break;
                            default:
                                {
                                    formato = FormatoExportacion.XML.GetStringValue();
                                } break;

                        }
                        continue;
                    }

                   

                }
                listarutas.Add(new RutaExportacion(secruta, pathdestino, formato));
            }
            configproceso = new ConfiguracionProceso(p);
            configproceso.Listarutas = listarutas;
            return configproceso;
          
            
        }
    }
}
