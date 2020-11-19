using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCR.Facultad.Ingenieria.LibreriasOpenPDFOCR
{
    class MapaNodoXml
    {
        string key;
        string valor;
     
        public string Key
        {
            get {
                return this.key;
            }            
        }
        public string Valor
        {
            get
            {
                return this.valor;
            } 
        }
       
        public MapaNodoXml(string ukey, string uvalor)
        {
            this.key = ukey;
            this.valor = uvalor;
           
        }
    }
}
