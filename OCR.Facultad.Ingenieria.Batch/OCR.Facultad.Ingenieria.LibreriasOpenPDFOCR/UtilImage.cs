using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace OCR.Facultad.Ingenieria.LibreriasOpenPDFOCR
{
    /// <summary>
    /// Clase con métodos utiles para el manejo de archivos de Imagen.
    /// </summary>
    public class UtilImage
    {
        /// <summary>
        /// Método utilizado para abrir un objeto de Imagen en modo seguro y asignarlo en Memoria.
        /// </summary>
        /// <param name="filename">Ruta del origen del archivo de Imagen.</param>
        /// <returns>Devuelve un objeto tipo Imagen.</returns>
        public static System.Drawing.Image NonLockingOpen(string filename)
        {
            System.Drawing.Image result;
            long size = (new FileInfo(filename)).Length;
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[size];
            try
            {
                fs.Read(data, 0, (int)size);
            }
            finally
            {
                fs.Close();
                fs.Dispose();
            }

            MemoryStream ms = new MemoryStream();
            ms.Write(data, 0, (int)size);
            result = new Bitmap(ms);
            ms.Close();

            return result;
        }
        /// <summary>
        /// Método utilizado para guardar un objeto de Imagen en modo seguro.
        /// </summary>
        /// <param name="img">Objeto tipo Imagen que sera almacenado en el disco.</param>
        /// <param name="fn">Ruta destino del archivo de Imagen.</param>
        /// <param name="format">Formato de compresión del archivo de Imagen(TIFF,JPG,ext).</param>
        public static void NonLockingSave(System.Drawing.Image img, string fn, ImageFormat format)
        {
            // Delete destination file if it already exists
            if (File.Exists(fn))
                File.Delete(fn);
            MemoryStream ms = new MemoryStream();
            System.Drawing.Image img2 = (System.Drawing.Image)img.Clone();
            img2.Save(ms, format);
            img2.Dispose();
            byte[] byteArray = ms.ToArray();
            ms.Close();
            ms.Dispose();
            FileStream fs = new FileStream(fn, FileMode.CreateNew, FileAccess.Write);
            try
            {
                fs.Write(byteArray, 0, byteArray.Length);
            }
            finally
            {
                fs.Close();
                fs.Dispose();
            }

        }
        /// <summary>
        /// Información del tipo de Codec de imagen según su tipo MIME.
        /// </summary>
        /// <param name="mimeType">Nombre del tipo MIME por ejemplo ("image/tif").</param>
        /// <returns>Retorna un tipo MIME como un objeto ImageCodecInfo</returns>
        public static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        public  static Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }
        public static int PotenciaMenor(int udimension)
        {
            int res = 0;
            while (udimension > 0)
            {
                udimension = udimension / 2;
                res++;
            }
            return res;
        }
    }
    
}
    

