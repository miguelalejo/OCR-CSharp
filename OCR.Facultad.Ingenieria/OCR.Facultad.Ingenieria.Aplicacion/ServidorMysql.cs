using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace OCR.Facultad.Ingenieria.Aplicacion
{
    public class ServidorMysql:ConfigurationElement
    {
        public ServidorMysql()
    { }
        [ConfigurationProperty("nombre",
       DefaultValue = "ninguno",
       IsRequired = false)]
        public string Nombre
        {
            get
            {
                return (string) this["nombre"];
            }
            set
            {
                this["nombre"] = value;
            }
        }
    }
}
