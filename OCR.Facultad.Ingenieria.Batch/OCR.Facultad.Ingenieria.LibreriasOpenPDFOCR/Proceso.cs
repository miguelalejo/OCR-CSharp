using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCR.Facultad.Ingenieria.LibreriasOpenPDFOCR
{
    public class Proceso
    {
        int  sec_proceso;
        public int Sec_Proceso
        {
            get { return this.sec_proceso; }
            
        }
        
        bool estado;
        public bool Estado 
        {
            get { return this.estado; }
        }
        string descripcion;
        public string Descripcion
        {
            get { return this.descripcion; }
        }
        bool deskew;
        public bool Deskew
        {
            get { return this.deskew; }
        }
        string nombrearchivo;
        public string Nombrearchivo
        {
            get { return this.nombrearchivo; }
        }
        string pathorigen;
        public string Pathorigen
        {
            get { return this.pathorigen; }
        }
        public Proceso(int usec_proceso,bool uestado)
        {
            this.sec_proceso = usec_proceso;
            estado = uestado;
        }
        public Proceso(int usec_proceso, string udescripcion, bool udeskew, string unombrearchivo, string upathorigen)
        {
            this.sec_proceso = usec_proceso;
            this.descripcion = udescripcion;
            this.deskew = udeskew;
            this.nombrearchivo = unombrearchivo;
            this.pathorigen = upathorigen;
        }
        public Proceso()
        {
            
        }
    }
}
