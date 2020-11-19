using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCR.Facultad.Ingenieria.LibreriasOpenPDFOCR
{
    public class RutaExportacion
    {
        int secruta;       
        string pathdestino;
        public string Pathdestino
        {
            get {  return this.pathdestino;}
        }
        string formato;
        public string Formato
        {
            get {
                return formato;
            }
        }
        public RutaExportacion( int usecruta, string upathdestino, string uformato)
        {
            this.secruta = usecruta;
            this.pathdestino = upathdestino;
            this.formato = uformato;
 
        }
    }
}
