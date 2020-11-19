using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace OCR.Facultad.Ingenieria.Clases
{
    public class ArchivoProceso
    {
        Process process;
        public Process Process
        {
            get {
                return this.process;
            }
            set {
                this.process = value;
            }
        }
        string nombre;
        public string Nombre {
            get {
                return this.nombre;
            }
        }
        int proceso;
        public int Proceso
        {
            get {
                return this.proceso;
            }
        }
        int secarchivo;
        public int SecArchivo
        {
            get
            {
                return this.secarchivo;
            }
        }
        int secproceso;
        public int SecProceso
        {
            get
            {
                return this.secproceso;
            }
            set {
                this.secproceso = value;
            }
        }
        string rutaprincipal;
        public string RutaPrincipal
        {
            get {
                return this.rutaprincipal;
            }
        }
        string descripcionproceso;
        public string DescripcionProceso
        {
            get {
                return this.descripcionproceso;
            }
        }
        public ArchivoProceso(string unombre, int uproceso, string urutaprincipal, string udescripcionproceso,int usecarchivo,int usecproceso)
        {
            this.nombre = unombre;
            this.proceso = uproceso;
            this.rutaprincipal = urutaprincipal;
            this.descripcionproceso = udescripcionproceso;
            this.secarchivo = usecarchivo;
            this.secproceso = usecproceso;
        }
    /*    public int CompareTo(object obj)
        {
            ArchivoProceso archivo = (ArchivoProceso)obj;
            if (this.secarchivo != archivo.secarchivo)
                return this.secarchivo.CompareTo(archivo.secarchivo);
            else
                return this.proceso.CompareTo(archivo.proceso);
        }   */

    }
}
