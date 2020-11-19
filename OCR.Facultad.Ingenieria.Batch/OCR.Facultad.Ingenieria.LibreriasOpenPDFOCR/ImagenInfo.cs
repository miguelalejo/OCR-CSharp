using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace OCR.Facultad.Ingenieria.LibreriasOpenPDFOCR
{
    public class ImagenInfo
    {
        int ancho;
        public int Ancho
        {
            get {
                return this.ancho;
            }
        }

        int alto;
        public int Alto
        {
            get {
                return this.alto;
            }
        }
        float vertical;
        public float Vertical
        {
            get {
                return this.vertical;
            }
        }
        float horizontal;
        public float Horizontal
        {
            get {
                return this.horizontal;
            }
        }
        int profundidadbits;
        public int Profundidadbits
        {
            get {
                return this.profundidadbits;
            }
        }
        public ImagenInfo(int uancho,int ualto,float uvertical,float uhorizontal,int uprofundidad)
        {
            this.ancho = uancho;
            this.alto = ualto;
            this.vertical = uvertical;
            this.horizontal = uhorizontal;
            this.profundidadbits = uprofundidad;
        }
        public static ImagenInfo GetInfoImagen(Image imagen)
        {
            return new ImagenInfo(imagen.Width, imagen.Height, imagen.VerticalResolution, imagen.HorizontalResolution, Image.GetPixelFormatSize(imagen.PixelFormat));
        }

    }
}
