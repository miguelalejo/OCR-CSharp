using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
namespace OCR.Facultad.Ingenieria.LibreriasOpenPDFOCR
{
    public class CabeceraInfo
    {
        string nombre;
        public string Nombre {
            get {
                return this.nombre;
            }
        }
  
        string directorio;
        public string Directorio
        {
            get {
               return  this.directorio;
            }

        }
        long tamanio;
        public long Tamanio
        {
            get {
                return this.tamanio;
            }
        }       
       
        string extencion;
        public string Extencion
        {
            get {
                return this.extencion;
            }
        }
        DateTime fechacreacion;
        public DateTime Fechacreacion
        {
            get {
                return this.fechacreacion;
            }
 
        }
        DateTime fechamodificacion;
        public DateTime Fechamodificacion
        {
            get {
                return this.fechamodificacion;
            }
        }
        public CabeceraInfo(string unombre, string udirectorio, long utamanio,  string uextencion, DateTime ufechacreacion, DateTime ufechamodificacion)
        {
            this.nombre = unombre;
            this.directorio = udirectorio;
            this.tamanio = utamanio; 
           
            this.extencion = uextencion;
            this.fechacreacion = ufechacreacion;
            this.fechamodificacion = ufechamodificacion; 
        }
        
        public static CabeceraInfo GetCabeceraInfo(string ufilename)
        {
            FileInfo info = new FileInfo(ufilename);
            FileAttributes atributos = File.GetAttributes(ufilename);           
            
            FileSecurity secinfo=  File.GetAccessControl(ufilename);

            return new CabeceraInfo(info.Name, info.DirectoryName, info.Length,  info.Extension, info.CreationTime, info.LastWriteTime);
 
        }
    }
}
