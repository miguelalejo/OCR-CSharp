using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCR.Facultad.Ingenieria.Clases
{
    public class Ruta
    {
        int id;
        string path;
        bool activa;
        bool principal;
        string tipodocumental;
        public int Id
        {
            get {
                return this.id;
            }
        }
        public string  Path
        {
            get {
                return this.path;
            }
        }
        public bool Activa
        {
            get
            {
                return this.activa;
            }
        }
        public bool Principal
        {
            get {
                return this.principal;
            }
        }
        public string TipoDocumental
        {
            get {
                return this.tipodocumental;
            }
        }
        public Ruta()
        { 

        }
        public Ruta(int _id,string _path,bool _activa,bool _principal,string _tipodocumental)
        {
            id = _id;
            path = _path;
            activa = _activa;
            principal = _principal;
            tipodocumental = _tipodocumental;
        }
    }
}
