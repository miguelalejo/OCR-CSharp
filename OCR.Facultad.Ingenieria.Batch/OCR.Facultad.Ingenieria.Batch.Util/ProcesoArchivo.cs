using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace OCR.Facultad.Ingenieria.Batch.Util
{
    public static class ProcesoArchivo
    {
        public static string mensajetitulo = "Procesando Archivo {0}  pag {1} de {2}  Completado {3}%";
        public static string mensajeinfo = "Página: {0}  Estado: {1}";
        public static string mensajetitulonombre = "Procesando Archivo: {0}";
        public static string mensajeproceso = "PROCESO: {0}";
        public static string nombrearchivo = "";
        public static string nombrefolder = "";
        public static string formatoarchivo = "";
        public static string directorio = "";
        public static string extencion = "";
        public static string root = "";
        public static int paginas = 0;
        public static int pagina = 0;
        public static int idproceso;
        public static int numeroprocesos=10;
        public static Point SitioVentana (int pancho,int plargo,int idproceso,int altura,int ancho)
        {
            int uy = 0;
            int ux = 0;
            if (numeroprocesos > 0)
            {
                numeroprocesos = (plargo / altura) * (pancho / ancho);
                int nprocaltura = (plargo / altura) ;
                if (((idproceso % nprocaltura) * altura) + altura > plargo)
                {
                    uy = 0;
                }
                else
                {
                    uy = (idproceso % nprocaltura) * altura;
                }
                if (idproceso >= numeroprocesos)
                {
                    idproceso = idproceso % numeroprocesos;
                }
                if ((idproceso % numeroprocesos) >= (numeroprocesos / (pancho / ancho)))       
                {
                    ux = (idproceso/(numeroprocesos / (pancho / ancho)))*ancho;
                }
                else
                {
                    ux=0;
                }
               

                return new Point(ux, uy);

            }
            else return new Point(ux, uy);

        }

        
    }
}
