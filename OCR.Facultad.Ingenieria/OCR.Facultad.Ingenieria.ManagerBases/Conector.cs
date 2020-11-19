using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace OCR.Facultad.Ingenieria.ManagerBases
{
    class Conector
    {
        private  IPAddress ip = null;
        private int puerto = 0;
        private String usuario = null;
        private String contrasenia = null;
        private String baseDatos = null;
        private String UKeypublica = null;
        private String CKeypublica = null;

        public Conector(IPAddress  _ip, int _puerto, string _usuario, string _contrasenia, string _baseDatos, string _UKeypublica, string _CKeypublica)
        {
            ip = _ip;
            puerto = _puerto;
            usuario = _usuario;
            contrasenia = _contrasenia;
            baseDatos = _baseDatos;
            UKeypublica = _UKeypublica;
            CKeypublica = _CKeypublica;
            
        }

        public IPAddress Ip
        {
            get { return this.ip; }
            set { this.ip = value; }

        }

        public int Puerto
        {
            get { return this.puerto; }
            set { this.puerto = value; }
        }
        

        public String Usuario
        {
            get { return this.usuario;}
            set {this.usuario = value;}
        }

        public String Contrasenia
        {
            get {return this.contrasenia;}
            set {this.contrasenia= value;}
        }
        
        public String BaseDatos
        {
            get {return this.baseDatos;}
            set {this.baseDatos = value;}
        }
        
        public String Ukeypublica
        {
            get {return this.UKeypublica;}
            set {this.UKeypublica = value;}
            
        }
        
         public String Ckeypublica
        {
             get {return this.CKeypublica;}
             set {this.CKeypublica = value;}
            
        }
       
    }
}