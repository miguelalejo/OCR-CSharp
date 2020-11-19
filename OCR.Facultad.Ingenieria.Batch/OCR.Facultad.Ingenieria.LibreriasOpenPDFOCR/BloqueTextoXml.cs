using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace OCR.Facultad.Ingenieria.LibreriasOpenPDFOCR
{
    public class BloqueTextoXml
    {
        public static List<BloqueTexto> ParseXmlBloqueTexto(string unombrearchivo)
        {
            XmlDocument originalXml = new XmlDocument();
            originalXml.Load(unombrearchivo);
            XmlNodeList cuerpo = originalXml.GetElementsByTagName("cuerpo");
            XmlNodeList palabra = ((XmlElement)cuerpo[0]).GetElementsByTagName("palabra");
            List<BloqueTexto> listabloque = new List<BloqueTexto>();
            foreach (XmlElement nodo in palabra)
            {
                List<MapaNodoXml> listamapa=new List<MapaNodoXml>();

                listamapa.Add(new MapaNodoXml("secpalabra", nodo.GetAttribute("secpalabra")));
                listamapa.Add(new MapaNodoXml("tipodato", nodo.GetAttribute("tipodato")));
                listamapa.Add(new MapaNodoXml("pointsize", nodo.GetAttribute("pointsize")));
                listamapa.Add(new MapaNodoXml("fuente", nodo.GetAttribute("fuente")));
                listamapa.Add(new MapaNodoXml("linea", nodo.GetAttribute("linea")));
                  listamapa.Add(new MapaNodoXml("lineaocr", nodo.GetAttribute("lineaocr")));
                listamapa.Add(new MapaNodoXml("blanks", nodo.GetAttribute("blanks")));
                listamapa.Add(new MapaNodoXml("x", nodo["posicion"].GetAttribute("x")));
                listamapa.Add(new MapaNodoXml("y", nodo["posicion"].GetAttribute("y")));
                listamapa.Add(new MapaNodoXml("ancho", nodo["dimensiones"].GetAttribute("ancho")));
                listamapa.Add(new MapaNodoXml("largo", nodo["dimensiones"].GetAttribute("largo")));
                listamapa.Add(new MapaNodoXml("confidence", nodo.GetAttribute("confidence")));
                listamapa.Add(new MapaNodoXml("texto", nodo.GetAttribute("texto")));                
                int sec = 0;
                TypeCode tipodato = TypeCode.String;
                int pointsize = 0;
                int fuente = 0;
                int linea = 0;
                 int lineaocr = 0;
                int blanks = 0;
                int x=0, y=0, ancho=0, largo = 0;
                double confidence = 0;
                string texto = "";
                foreach (MapaNodoXml mapa in listamapa)
                {
                 
                    if (mapa.Key == "secpalabra")
                    {
                         sec=Convert.ToInt16(mapa.Valor);
                         continue;  
                    }
                  
                    if (mapa.Key == "tipodato")
                    {
                        tipodato = UtilXmlOcr.FindTypeCode(mapa.Valor);
                        continue;
                    }
                
                    if (mapa.Key == "pointsize")
                    {
                        pointsize = Convert.ToInt16(mapa.Valor);
                        continue;
                    }
                    if (mapa.Key == "fuente")
                    {
                        fuente = Convert.ToInt16(mapa.Valor);
                        continue;
                    }
                 
                    if (mapa.Key == "linea")
                    {
                        linea = Convert.ToInt16(mapa.Valor);
                        continue;
                    }
                     if (mapa.Key == "lineaocr")
                    {
                        lineaocr = Convert.ToInt16(mapa.Valor);
                        continue;
                    }
                 
                    if (mapa.Key == "blanks")
                    {
                        blanks = Convert.ToInt16(mapa.Valor);
                        continue;
                    }
                
                    if (mapa.Key == "confidence")
                    {
                        confidence = Convert.ToDouble(mapa.Valor);
                        continue;
                    }
                    if (mapa.Key == "x")
                    {
                        x = Convert.ToInt16(mapa.Valor);
                        continue;
                    }
                    if (mapa.Key == "y")
                    {
                        y = Convert.ToInt16(mapa.Valor);
                        continue;
                    }
                    if (mapa.Key == "ancho")
                    {
                        ancho = Convert.ToInt16(mapa.Valor);
                        continue;
                    }
                    if (mapa.Key == "largo")
                    {
                        largo = Convert.ToInt16(mapa.Valor);
                        continue;
                    }                   
                    if (mapa.Key == "texto")
                    {
                        texto = mapa.Valor;
                        continue;
                    }
                    
                }
                listabloque.Add(new BloqueTexto(sec, tipodato, pointsize, x, y, largo, ancho, linea,lineaocr, fuente, confidence, blanks, texto));
            }
            return listabloque;
        }
    }
}
