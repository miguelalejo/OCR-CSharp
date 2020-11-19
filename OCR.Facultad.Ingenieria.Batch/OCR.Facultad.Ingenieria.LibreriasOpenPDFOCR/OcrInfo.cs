using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCR.Facultad.Ingenieria.LibreriasOpenPDFOCR
{
    public class OcrInfo
    {
        int ncaracteres;
        public int NCaracteres
        {
            get
            {
                return this.ncaracteres;
            }
            set {
                this.ncaracteres= value;
            }
        }
        int npaginas;
        public int NPaginas
        {
            get
            {
                return this.npaginas;
            }
            set {
                this.npaginas = value;
            }
        }
        int npalabras;
        public int NPalabras
        {
            get {
                return this.npalabras;
            }
            set {
                this.npalabras = value;
            }
        }
        int nlineas;
        public int NLineas {
            get {
                return this.nlineas;
            }
            set {
                this.nlineas = value;
            }
        }
        DateTime fechainicio;
        public DateTime FechaInicio
        {
            get { return this.fechainicio; }
            set {
                this.fechainicio = value;
            }
        }
        DateTime fechafin;
        public DateTime FechaFin
        {
            get { return this.fechafin; }
            set {
                this.fechafin = value;
            }
        }
        public OcrInfo(int uncaracteres, int unpalabras, int unlineas, DateTime ufechainicio, DateTime ufechafin)
        {
            this.ncaracteres = uncaracteres;
            this.npalabras = unpalabras;
            this.nlineas = unlineas;
            this.fechainicio = ufechainicio;
            this.fechafin = ufechafin; 
        }
        public OcrInfo()
        { }

    }
}
