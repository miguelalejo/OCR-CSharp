using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace OCR.Facultad.Ingenieria.Clases
{
    /// <summary>
    /// Clase utilizada para el manejo de archivos, contenidos en directorios.
    /// </summary>
    public class Fichero
    {
        /// <summary>
        /// Ruta origen carpeta.
        /// </summary>
        string rutaOrigen;
        /// <summary>
        /// Ruta origen carpeta.
        /// </summary>
        public string RutaOrigen
        {
            get
            {
                return this.rutaOrigen;
            }
            set
            {
                this.rutaOrigen = value;
            }
        }
        /// <summary>
        /// Ruta destino carpeta.
        /// </summary>
        string rutaDestino;
        /// <summary>
        /// Ruta destino carpeta.
        /// </summary>
        public string RutaDestino
        {
            get
            {
                return this.rutaDestino;
            }
            set
            {
                this.rutaDestino = value;
            }
        }
        /// <summary>
        /// Extención origen.
        /// </summary>
        string extOrigen;
        /// <summary>
        /// Extención origen.
        /// </summary>
        public string ExtOrigen
        {
            get
            {
                return this.extOrigen;
            }
            set
            {
                this.extOrigen = value;
            }
        }
        /// <summary>
        /// Extención destino, por defecto el valor es: *.*
        ///</summary>
        string extDestino = "*.*";
        /// <summary>
        /// Extención destino, por defecto el valor es: *.*
        ///</summary>
        public string ExtDestino
        {
            get
            {
                return this.extDestino;
            }
            set
            {
                this.extDestino = value;
            }
        }
        /// <summary>
        /// Fecha programada para la tarea.
        /// </summary>
        DateTime fecha;
        /// <summary>
        /// Fecha programada para la tarea.
        /// </summary>
        public DateTime Fecha
        {
            get
            {
                return this.fecha;

            }
            set
            {
                this.fecha = value;
            }
        }
        /// <summary>
        /// Estado de la acción ejecutada sobre la carpeta.
        /// </summary>
        bool estado;
        /// <summary>
        /// Estado de la acción ejecutada sobre la carpeta.
        /// </summary>
        public bool Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        /// <summary>
        /// Tipo de acción sobre el carpeta.
        /// </summary>
        string accion;
        /// <summary>
        /// Tipo de acción sobre el carpeta.
        /// </summary>
        public string Accion
        {
            get
            {
                return this.accion;

            }
            set
            {
                this.accion = value;
            }
        }
        /// <summary>
        /// Número de archivos contenidos en la carpeta.
        /// </summary>
        int numeroArchivos = 0;
        /// <summary>
        /// Número de archivos contenidos en la carpeta.
        /// </summary>
        public int NumeroArchivos
        {
            get
            {
                return this.numeroArchivos;
            }
            set
            {
                this.numeroArchivos = value;
            }
        }
        /// <summary>
        /// Número de archivos copiados.
        /// </summary>
        int numeroCopiados = 0;
        /// <summary>
        /// Número de archivos copiados.
        /// </summary>
        public int NumeroCopiados
        {
            get
            {
                return this.numeroCopiados;
            }
            set
            {
                this.numeroCopiados = value;
            }
        }
        /// <summary>
        /// Número de archivos reemplazados.
        /// </summary>
        int numeroReemplazados = 0;
        /// <summary>
        /// Número de archivos reemplazados.
        /// </summary>
        public int NumeroReemplazados
        {
            get
            {
                return this.numeroReemplazados;
            }
            set
            {
                this.numeroReemplazados = value;
            }
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase fichero.
        /// </summary>
        /// <param name="unarutaOrigen">Ruta origen carpeta archivos.</param>
        /// <param name="unarutaDestino">Ruta destino carpeta archivos.</param>
        /// <param name="unaextOrigen">Extención origen.</param>
        /// <param name="unafecha">Extención destino.</param>
        /// <param name="unestado">Estado ficheros.</param>
        /// <param name="unaccion">Nombre acción</param>
        public Fichero(string unarutaOrigen, string unarutaDestino, string unaextOrigen, DateTime unafecha, bool unestado, string unaccion)
        {
            this.rutaOrigen = unarutaOrigen;
            this.rutaDestino = unarutaDestino;
            this.extOrigen = unaextOrigen;
            this.fecha = unafecha;
            this.estado = unestado;
            this.accion = unaccion;
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase fichero.
        /// </summary>
        /// <param name="unarutaOrigen">Ruta origen carpeta archivos.</param>
        /// <param name="unarutaDestino">Ruta destino carpeta archivos.</param>
        /// <param name="unaextOrigen">Extención origen.</param>
        /// <param name="unaextDestino">Extención destino.</param>
        /// <param name="unafecha">Extención destino.</param>
        /// <param name="unestado">Estado ficheros.</param>
        /// <param name="unaccion">Nombre acción.</param>
        public Fichero(string unarutaOrigen, string unarutaDestino, string unaextOrigen, string unaextDestino, DateTime unafecha, bool unestado, string unaccion)
        {
            this.rutaOrigen = unarutaOrigen;
            this.rutaDestino = unarutaDestino;
            this.extOrigen = unaextOrigen;
            this.extDestino = unaextDestino;
            this.fecha = unafecha;
            this.estado = unestado;
            this.accion = unaccion;
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase fichero.
        /// </summary>
        /// <param name="unarutaOrigen">Ruta origen carpeta archivos.</param>
        /// <param name="unarutaDestino">Ruta destino carpeta archivos.</param>
        /// <param name="unaextOrigen">Extención origen.</param>
        /// <param name="unaextDestino">Extención destino.</param>
        public Fichero(string unarutaOrigen, string unarutaDestino, string unaextOrigen, string unaextDestino)
        {
            this.rutaOrigen = unarutaOrigen;
            this.rutaDestino = unarutaDestino;
            this.extOrigen = unaextOrigen;
            this.extDestino = unaextDestino;
        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase fichero.
        /// </summary>
        /// <param name="unarutaOrigen">Ruta origen carpeta archivos.</param>
        /// <param name="unarutaDestino">Ruta destino carpeta archivos.</param>
        /// <param name="unaextOrigen">Extención origen.</param>       
        public Fichero(string unarutaOrigen, string unarutaDestino, string unaextOrigen)
        {
            this.rutaOrigen = unarutaOrigen;
            this.rutaDestino = unarutaDestino;
            this.extOrigen = unaextOrigen;
        }
        /// <summary>
        /// Mueve los archivos de la carpeta origen hacia la carpeta destino.
        /// </summary>
        public void MoverFicheros()
        {

            string[] sourceFilesOri = cargarNombresArchivos(this.rutaOrigen, this.extOrigen);
            int contador = 0;
            for (int i = 0; i < sourceFilesOri.Length; i++)
            {
                FileInfo f = new FileInfo(sourceFilesOri[i]);
                string dest = Path.Combine(this.rutaDestino, f.Name);
                if (!File.Exists(dest))
                {
                    File.Move(sourceFilesOri[i], dest);
                    this.numeroCopiados++;
                }
                else
                {
                    File.Delete(dest);
                    File.Move(sourceFilesOri[i], dest);
                    this.numeroReemplazados++;
                }
                contador++;
            }
            this.numeroArchivos = sourceFilesOri.Length;

        }
        /// <summary>
        /// Copia los archivos desde la carpeta origen hacia la carpeta destino.
        /// </summary>
        public void CopiarFicheros()
        {
            string[] sourceFilesOri = cargarNombresArchivos(this.rutaOrigen, this.extOrigen);
            int contador = 0;
            for (int i = 0; i < sourceFilesOri.Length; i++)
            {
                FileInfo f = new FileInfo(sourceFilesOri[i]);
                string dest = Path.Combine(this.rutaDestino, f.Name);
                if (!File.Exists(dest))
                {
                    File.Copy(sourceFilesOri[i], dest);
                    this.numeroCopiados++;
                }
                else
                {
                    File.Copy(sourceFilesOri[i], dest, true);
                    this.numeroReemplazados++;
                }
                contador++;
            }
            this.numeroArchivos = sourceFilesOri.Length;
        }
        /// <summary>
        /// Carga los nombre de los archivos en una ruta especifica, según su extención.
        /// </summary>
        /// <param name="ruta">Ruta del directorio.</param>
        /// <param name="ext">Nombre de la extención utilizada como parámetro de selección.</param>
        /// <returns></returns>
        string[] cargarNombresArchivos(string ruta, string ext)
        {
            ArrayList imageFilesNames = new ArrayList();

            string[] filesWithCurrentExtention = System.IO.Directory.GetFiles(ruta, ext);
            imageFilesNames.AddRange(filesWithCurrentExtention);

            return ((string[])imageFilesNames.ToArray(typeof(string)));
        }
        /// <summary>
        /// Compara el valor de la fecha de creación de los ficheros.
        /// </summary>
        /// <param name="F1">Un fichero.</param>
        /// <param name="F2">Un fichero a comparar.</param>
        /// <returns>Valor
        /// <list type="bullet">
        /// <listheader>Condición:</listheader>
        /// <item>Menor que cero: La fecha de creación del fichero F1 es menor que la del fichero F2. </item>
        /// <item>Cero: La fecha de creación del fichero F1 es igual a la del  fichero F2. </item>
        /// <item>Mayor que cero: La fecha de creación del fichero F1 es mayor que la del fichero F2. </item>
        /// </list>
        ///</returns>
        public static int ordenarFecha(Fichero F1, Fichero F2)
        {
            return F1.fecha.CompareTo(F2.fecha);
        }


    }
}
