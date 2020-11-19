using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCR.Facultad.Ingenieria.LibreriasOpenPDFOCR
{
    public class ArchivoProceso
    {
        string path;
        public string Path 
        {
            get { return this.path; }
            set { this.path = value; }
        }
        long tamanio;
        public long Tamanio
        {
            get { return this.tamanio; }
            set { this.tamanio = value; }
        }
        FormatoExp formato;
        public FormatoExp Formato{
            get { return this.formato; }
            set { this.formato = value; }

         }
        public ArchivoProceso(string upath,long utamanio,FormatoExp uformato)
        {
            this.path = upath;
            this.tamanio = utamanio;
            this.formato = uformato;
        }
        public ArchivoProceso(string upath, FormatoExp uformato)
        {
            this.path = upath;
            
            this.formato = uformato;
        }


    }
}
