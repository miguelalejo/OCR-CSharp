using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace OCR.Facultad.Ingenieria.Aplicacion
{
    public class ClassAppAplicacion
    {
        public static String GetProcesadosOcr()
        {
            return ConfigurationManager.AppSettings.Get("ProcesadosOcr");
        }
        public static String GetNoProcesadosOcr()
        {
            return ConfigurationManager.AppSettings.Get("NoProcesadosOcr");
        }
        public static String GetXMLProcesados()
        {
            return ConfigurationManager.AppSettings.Get("XMLProcesados");
        }
        public static String GetXMLNoProcesados()
        {
            return ConfigurationManager.AppSettings.Get("XMLNoProcesados");
        }
        public static String GetKeyPublicaMysql()
        {
            return ConfigurationManager.AppSettings.Get("KeyPublicaMysql");
        }
        public static String GetAutoArranque()
        {
            return ConfigurationManager.AppSettings.Get("AutoArranque");
        }
        public static String GetDeskew()
        {
            return ConfigurationManager.AppSettings.Get("Deskew");
        }
         public static String GetMoverDoc()
        {
            return ConfigurationManager.AppSettings.Get("MoverDoc");
        }
         public static bool Guardar(string ukey,string uvalor)
         {

             try
             {
                 
                 Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                 conf.AppSettings.Settings[ukey].Value = uvalor;
                 conf.Save();
                 //ConfigurationManager.OpenExeConfiguration(conf.FilePath);
                 ConfigurationManager.RefreshSection("appSettings");
                 return true;
             }
             catch 
             {
                 return false;
             }
         }
       
    
       
   
    }
}
