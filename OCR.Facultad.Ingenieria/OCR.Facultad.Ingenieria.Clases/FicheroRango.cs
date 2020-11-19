using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCR.Facultad.Ingenieria.Clases
{
    /// <summary>
    /// Clase heredada de la clase Fichero.
    /// </summary>
    public class FicheroRango:Fichero
    {
        /// <summary>
        /// Fecha inicial para el rango de selección.
        /// </summary>
        DateTime desde;
        /// <summary>
        /// Fecha final para el rango de selección.
        /// </summary>
        DateTime hasta;
        /// <summary>
        /// Fecha inicial para el rango de selección.
        /// </summary>
        public DateTime Desde
        {
            get {
                return this.desde;
            }
            set {
                this.desde = value;
            }
        }
        /// <summary>
        /// Fecha final para el rango de selección.
        /// </summary>
        public DateTime Hasta
        {
            get
            {
                return this.hasta;
            }
            set
            {
                this.hasta = value;
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
        /// <param name="undesde">Fecha inicial para el rango de selección de fechas.</param>
        /// <param name="unhasta">Fecha final para el rango de selección de fechas.</param>
        public FicheroRango(string unarutaOrigen, string unarutaDestino, string unaextOrigen,  DateTime unafecha, bool unestado,string unaccion,DateTime undesde, DateTime unhasta):
                base(unarutaOrigen,unarutaDestino,unaextOrigen,unafecha,unestado,unaccion)
        {
          
            this.desde = undesde;
            this.hasta = unhasta;
        }

    }
}
