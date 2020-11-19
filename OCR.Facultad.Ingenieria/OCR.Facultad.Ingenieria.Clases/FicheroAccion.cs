using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCR.Facultad.Ingenieria.Clases
{
    /// <summary>
    /// Clase heredada de la clase Fichero.
    /// </summary>
    public class FicheroAccion : Fichero
    {
        /// <summary>
        /// Dirección destino de la carpeta contenedora de los archivos a mover.
        /// </summary>
        string rutamover;
        /// <summary>
        /// Dirección destino de la carpeta contenedora de los archivos a mover.
        /// </summary>
        public string RutaMover
        {
            get {
                return this.rutamover;
            }
            set {
                this.rutamover = value;
            }
        }
        /// <summary>
        /// Número de documentos borrados.
        /// </summary>
        int numeroBorrados;
        /// <summary>
        /// Número de documentos borrados.
        /// </summary>
        public int NumeroBorrados
        {
            get {
                return this.numeroBorrados;
            }
            set {
                this.numeroBorrados = value;
            }
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
        /// <param name="unaccion">Nombre acción</param>
        /// <param name="unarutaMover">Ruta destino contenedora de los archivos a mover.</param>
        public FicheroAccion(string unarutaOrigen, string unarutaDestino, string unaextOrigen,string unaextDestino,DateTime unafecha, bool unestado, string unaccion, string unarutaMover) :
            base(unarutaOrigen, unarutaDestino, unaextOrigen,unaextDestino, unafecha, unestado, unaccion)
        {
            this.rutamover = unarutaMover;
        }


    }
}
