using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using AForge.Imaging;
using AForge.Imaging.Filters;
using System.Drawing.Imaging;
using AMA.Util;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace OCR.Facultad.Ingenieria.LibreriasOpenPDFOCR
{
    /// <summary>
    ///<para>Clase con métodos utilizados para la alineación de imagenes.</para>
    ///<para>API que permite la integración con la librería OPEN SOURCE AForge.</para>
    /// </summary>
    public class AForgeDeskew
    {
        /// <summary>
        /// Método utilizado para alinear una Imagen.
        /// </summary>
        /// <param name="unbitmap">Bitmap de la imagen que se desea alinear.</param>
        /// <returns>Bitmap imagen alineada.</returns>
        /// <example>Como realizar el enderezamiento de una Imagen.
        /// <code>
        /// Bitmap enderezada=AForgeDeskew.DeskewImagen(new Bitmap(@"C:\DeskewImage.tif"));
        /// </code>
        /// <list type="bullet">
        /// <listheader>Observaciones:</listheader>
        /// <item>Nótese que la llamada se realiza a un método estático.</item>
        /// </list>
        /// </example>
        public static Bitmap DeskewImagen(Bitmap unbitmap)
        {          
            DocumentSkewChecker skewChecker = new DocumentSkewChecker();
            //Cálculo del ángulo de inclinación.
            double angle = skewChecker.GetSkewAngle(unbitmap);
            RotateBilinear rotationFilter = new RotateBilinear(-angle);
            rotationFilter.FillColor = Color.White;
            Bitmap rotatedImage = rotationFilter.Apply(unbitmap);
            unbitmap.Dispose();
            return rotatedImage;
        }   
        
       
       
    }
}
