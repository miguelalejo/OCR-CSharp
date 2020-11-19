using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace OCR.Facultad.Ingenieria.Aplicacion
{
    public class ServidorMysqlSeccion:ConfigurationSection
    {
        public ServidorMysqlSeccion()
        { }
        [ConfigurationProperty("MysqlElement")]
        public ServidorMysql ConsoleElement
        {
            get
            {
                return (
                  (ServidorMysql)this["MysqlElement"]);
            }
            set
            {
                this["MysqlElement"] = value;
            }
        }
    }
}
