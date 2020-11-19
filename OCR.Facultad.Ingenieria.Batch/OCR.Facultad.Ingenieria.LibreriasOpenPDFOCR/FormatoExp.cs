using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCR.Facultad.Ingenieria.LibreriasOpenPDFOCR
{
    public class FormatoExp
    {
        int sec;
        public int Sec
        {
            get { return this.sec; }
            set { this.sec = value; }
        }
        string valor;
        public string Valor
        {
            get { return this.valor; }
            set { this.valor = value; }
        }
        public FormatoExp(int usec,string uvalor)
       {
           sec = usec;
           valor = uvalor;
       }
       
    }
}
