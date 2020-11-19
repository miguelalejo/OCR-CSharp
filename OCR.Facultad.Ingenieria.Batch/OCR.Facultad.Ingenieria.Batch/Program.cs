using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OCR.Facultad.Ingenieria.Batch
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(String[]args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                FormProcesamiento fproceso = new FormProcesamiento();
                string pathxml = "";

                foreach (string s in args)
                {
                    pathxml += s;
                }

                fproceso.Args = new string[] { pathxml };

                Application.Run(fproceso);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);   
            }

            //Application.Run(new Form1());
        }
    }
}
