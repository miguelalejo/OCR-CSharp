using System;
using System.Collections.Generic;
using System.Text;

namespace OCR.Facultad.Ingenieria.LibreriasOpenPDFOCR
{
    /// <summary>
    /// Clase utilizada para el reconocimiento de bloques de texto en documentos. 
    /// </summary>
    public class BloqueTexto
    {
        /// <summary>
        /// Posición en pixeles de la coordenada horizontal en un bloque de texto.
        /// </summary>
        private int x ;
        /// <summary>
        /// Posición en pixeles de la coordenada horizontal en un bloque de texto.
        /// </summary>
        public int X
        {
            get { return x; }
        }
        /// <summary>
        /// Posición en pixeles de la coordenada vertical en un bloque de texto.
        /// </summary>
        private int y ;
        /// <summary>
        /// Posición en pixeles de la coordenada vertical en un bloque de texto.
        /// </summary>
        public int Y
        {
            get {
                return y;
            }
        }
        /// <summary>
        /// Ancho del bloque de texto.
        /// </summary>
        private int  w ;
        /// <summary>
        /// Ancho del bloque de texto.
        /// </summary>
        public int W
        {
            get {
                return w;
            }
        }
        /// <summary>
        /// Alto del bloque de texto.
        /// </summary>
        private int h;
        /// <summary>
        /// Alto del bloque de texto.
        /// </summary>
        public int  H
        {
            get {
                return h;
            }
        }
        private int  bottom;
        /// <summary>
        /// Alto del bloque de texto.
        /// </summary>
        public int Bottom
        {
            get
            {
                return bottom;
            }
        }
        private int left;
        /// <summary>
        /// Alto del bloque de texto.
        /// </summary>
        public int Left
        {
            get
            {
                return left;
            }
        }
        private int right;
        /// <summary>
        /// Alto del bloque de texto.
        /// </summary>
        public int Right
        {
            get
            {
                return right;
            }
        }
        /// <summary>
        /// Tamaño de la letra por bloque de texto.
        /// </summary>
        private int pointsize;
        /// <summary>
        /// Tamaño de la letra por bloque de texto.
        /// </summary>
        public int Pointsize
        {
            get {
                return this.pointsize;
            } 
        }
        private int linea;
        /// <summary>
        /// Alto del bloque de texto.
        /// </summary>
        public int Linea
        {
            get
            {
                return linea;
            }
             set
            {
                this.linea=value;
            }
        }
        private int lineaocr;
        /// <summary>
        /// Alto del bloque de texto.
        /// </summary>
        public int LineaOcr
        {
            get
            {
                return lineaocr;
            }
            set
            {
                this.lineaocr = value;
            }
        }
        private int secpalabra;
        /// <summary>
        /// Alto del bloque de texto.
        /// </summary>
        public int SecPalabra
        {
            get
            {
                return secpalabra;
            }
            set
            {
                this.secpalabra = value;
            }
        }
        private int fuente;
        /// <summary>
        /// Alto del bloque de texto.
        /// </summary>
        public int Fuente
        {
            get
            {
                return fuente;
            }
            set
            {
                this.fuente = value;
            }
        }
        private int blanks;
        /// <summary>
        /// Alto del bloque de texto.
        /// </summary>
        public int Blanks
        {
            get
            {
                return blanks;
            }
            set
            {
                this.blanks = value;
            }
        }
        private double confidence;
        /// <summary>
        /// Alto del bloque de texto.
        /// </summary>
        public double Confidence
        {
            get
            {
                return confidence;
            }
            set
            {
                this.confidence = value;
            }
        }
       TypeCode tipodato ;
        /// <summary>
        /// Alto del bloque de texto.
        /// </summary>
       public TypeCode Tipodato
        {
            get
            {
                return tipodato;
            }
            set
            {
                this.tipodato = value;
            }
        }
        /// <summary>
        /// Texto contenido en el bloque.
        /// </summary>
        public string texto;
        /// <summary>
        /// Texto contenido en el bloque.
        /// </summary>
        public string Texto
        {
            get { return this.texto; }
        }
        /// <summary>
        /// Constructor BloqueTexto.
        /// </summary>
        /// <param name="left">Pixeles left.</param>
        /// <param name="right">Pixeles right.</param>
        /// <param name="top">Pixeles top.</param>
        /// <param name="bottom">Pixeles bottom.</param>
        /// <param name="unpointSize">Tamaño de la letra contenida en el bloque de texto.</param>
        /// <param name="untexto">Cadena de texto.</param>
        public BloqueTexto(int uleft, int uright, int utop, int ubottom, int unpointSize,string untexto)
        {
            x = (uleft <= 0) ? 0 : uleft;
            y = (utop <= 0) ? 0 : utop;
            w = ((uright - uleft) <= 0) ? 1 : (uright - uleft);
            h = ((ubottom - utop) <= 0) ? 1 : (ubottom - utop);
            bottom = ubottom;
            left = uleft;
            right = uright;
            pointsize = unpointSize;
            texto = untexto;
        }
        public BloqueTexto(int usecpalabra, TypeCode utipodato, int upointsize, int ux, int uy, int ulargo, int uancho, int ulinea,int ulineaocr, int ufuente, double uconfidence, int ublanks, string utexto)
        {
            secpalabra = usecpalabra;
            tipodato = utipodato;
            pointsize = upointsize;
            x = (ux <= 0)?0:ux;
            y = (uy <= 0) ? 0 : uy;
            h = (ulargo<=0)?1:ulargo;
            w = (uancho<=0)?1:uancho;
            linea = ulinea;
            lineaocr = ulineaocr;
            fuente = ufuente;
            confidence = uconfidence;
            blanks = ublanks;
            texto = utexto;
        }
        /// <summary>
        /// Constructor BloqueTexto.
        /// </summary>
        /// <param name="left">Pixeles left.</param>
        /// <param name="right">Pixeles right.</param>
        /// <param name="top">Pixeles top.</param>
        /// <param name="bottom">Pixeles bottom.</param>
        /// <param name="unpointSize">Tamaño de la letra contenida en el bloque de texto.</param>
        /// <param name="untexto">Cadena de texto.</param>
        public BloqueTexto(int uleft, int uright, int utop, int ubottom, int unpointSize, string untexto, int ulinea,int ulineaocr,int usecpalabra)
        {
            x = (uleft <= 0) ? 0 : uleft;
            y = (utop <= 0) ? 0 : utop;
            w = ((uright - uleft) <= 0) ? 1 : (uright - uleft);
            h = ((ubottom - utop) <= 0) ? 1 : (ubottom - utop);
            bottom = ubottom;
            left = uleft;
            right = uright;
            pointsize = unpointSize;
            texto = untexto;
            linea = ulinea;
            lineaocr = ulineaocr;
            secpalabra = usecpalabra;
            
        }
        /// <summary>
        /// Constructor BloqueTexto.
        /// </summary>
        /// <param name="left">Pixeles left.</param>
        /// <param name="right">Pixeles right.</param>
        /// <param name="top">Pixeles top.</param>
        /// <param name="bottom">Pixeles bottom.</param>
        /// <param name="untexto">Cadena de texto.</param>
        public BloqueTexto(int uleft, int uright, int utop, int ubottom,string untexto)
        {
            x = (uleft <= 0) ? 0 : uleft;
            y = (utop <= 0) ? 0 : utop;
            w = Math.Abs(uright - uleft);
            h = Math.Abs(ubottom - utop);
            bottom = ubottom;
            left = uleft;
            right = uright;
            texto = untexto;
        }
      /// <summary>
      /// Determina si un bloque de texto pertenece una línea texto.
      /// </summary>
      /// <param name="bloqueA">Bloque para comparar.</param>
      /// <param name="bloqueB">Bloque para comparar.</param>
      /// <param name="pixeles">Máxima distancia de separación entre bloques.</param>
        /// <returns><para>TRUE si el bloque de texto pertenece a una línea de texto.</para><para>FALSE si el bloque de texto no pertenece a una línea de texto, luego este valor indica un salto de línea.</para></returns>
        /// <example>Como reconcer si un bloque de texto pertenece a una línea de texto
        /// <code>
        /// public int NumeroLineas()
        /// {
        /// //Código utilizado para realizar el Reconocimiento OCR con la libreria "tessnet2_32.dll"
        /// int total = ocr.Init(@"tessdata", "spa", false); // To use correct tessdata
        /// ocr.SetVariable("tessedit_char_whitelist", ""); // If digit only
        /// List&#60;tessnet2.Word&#62; result = null;
        /// Thread FirstThread = new Thread((ThreadStart)delegate
        /// {
        ///       result = ocr.DoOCR(imagetest, System.Drawing.Rectangle.Empty);
        /// });
        /// FirstThread.Start();
        /// FirstThread.Join();
        /// //Código utilizado para el ejemplo 
        /// int numerolineas=0;
        /// for(int i=0; i &#60; result.Count-1;i++)
        /// {
        ///    tessnet2.Word word1=result[i];
        ///    BloqueTexto bloquea = new BloqueTexto(word1.Left, word1.Right, word1.Top, word1.Bottom, word1.PointSize, word1.Text);
        ///     tessnet2.Word word2=result[i+1];
        ///    BloqueTexto bloqueb = new BloqueTexto(word2.Left, word2.Right, word2.Top, word2.Bottom, word2.PointSize, word2.Text);
        ///    //Llamada al método es bloque línea
        ///    if(!bloqueb.EsBloqueLinea(bloquea))
        ///    {
        ///     numerolineas++;
        ///    }
        ///  }
        ///  return numerolineas;
        /// }     
        /// </code>
        /// <list type="bullet">
        /// <listheader>Observaciones:</listheader>
        /// <item>Nótese que la llamada se realiza a un método estático.</item>
        /// </list>
        /// </example>
        public bool EsBloqueLinea(BloqueTexto bloqueA, BloqueTexto bloqueB,int pixeles)
        {
            if (Math.Abs(bloqueA.y - bloqueB.y) <= pixeles)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Cálculo de la Altura promedio de un conjunto de bloques que pertenecen a una misma línea de texto.
        /// </summary>
        /// <param name="lista">Lista de bloques que pertenecen a una misma línea de texto.</param>
        /// <returns>AlturaPromedio de la línea de texto.</returns>
        /// <example>Como calcular la altura promedio de un conjunto de bloques
        /// <code>
        /// public int MaximaAlturaPromedio()
        /// {
        /// List&#60; BloqueTexto &#62; listacad = new List &#60; BloqueTexto &#62;();
        /// for (int k = 0; k &#60; 3; k++)
        /// {
        ///    tessnet2.Character caracter = cadena[k];
        ///    listacad.Add(new BloqueTexto(10, 20+k, 30, 40+k, "HOLA"));
        ///                                        
        /// }
        /// //Ulización del Método para el ejemplo
        /// return BloqueTexto.MaximaAlturaPromedio(listacad);
        /// } 
        /// </code>
        /// <list type="bullet">
        /// <listheader>Observaciones:</listheader>
        /// <item>Nótese que la llamada se realiza a un método estático.</item>
        /// </list>
        /// </example>
        public static double MaximaAlturaPromedio(List<BloqueTexto> lista)
        {
            if (lista.Count == 0)
            {
                return 0;
            }
            double suma = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                suma+= lista[i].h;
            }
            return (suma / lista.Count);
        }
       
    }
}
