using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCR.Facultad.Ingenieria.LibreriasOpenPDFOCR
{
    public class ConfiguracionProceso
    {

        List<RutaExportacion> listarutas = new List<RutaExportacion>();
        Proceso proceso;
        public List<RutaExportacion> Listarutas
        {
            get { return this.listarutas; }
            set { listarutas = value; }
        }
        public Proceso Proceso 
        {
            get { return this.proceso; }
        }
        public ConfiguracionProceso(Proceso uproceso)
        {
            this.proceso = uproceso;
        }
        public ConfiguracionProceso()
        {
            
        }
       
    }
}
