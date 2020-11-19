using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCR.Facultad.Ingenieria.LibreriasOpenPDFOCR
{
    public class BloqueTextoTessnet
    {
        public BloqueTexto anterior = null;
        int indicelinea = 0;
        int secpalabra=0;
        public BloqueTextoTessnet()
        {
            anterior = null;
            indicelinea = 0;
            secpalabra = 0;
        }
        public List<BloqueTexto> LineasTextoPorPalabra(tessnet2.Word uword)
        {

            tessnet2.Character valor = uword.CharList[0];
            string texto = "";
            List<BloqueTexto> lista = new List<BloqueTexto>();
            int right = 0;
            int bottom = 0;

            //OJO
            right = uword.Right;
            bottom = uword.Bottom;
            if (anterior != null)
            {
                if (anterior.LineaOcr != uword.LineIndex)
                {
                    secpalabra = 0;
                }
            }
            BloqueTexto actual = new BloqueTexto(valor.Left, right, valor.Top, bottom, uword.PointSize, uword.Text, uword.LineIndex, uword.LineIndex, secpalabra++);
           
            lista.Add(actual);
           
            anterior = actual;
            
            //OJO
           
            //BloqueTexto actual = null;
            //for (int i = 0; i < uword.CharList.Count; i++)
            //{
            //    texto += uword.CharList[i].Value;
            //    right = uword.CharList[i].Right;
            //    bottom = uword.CharList[i].Bottom;
            //    if (i < uword.CharList.Count - 1)
            //    {

            //        if (Math.Abs(uword.CharList[i].Bottom - uword.CharList[i + 1].Bottom) > 10 && Math.Abs(uword.CharList[i].Top - uword.CharList[i + 1].Top) > 10)
            //        {
            //            lista.Add(new BloqueTexto(valor.Left, uword.CharList[i].Right, valor.Top, uword.CharList[i].Bottom, uword.PointSize, texto, indicelinea,uword.LineIndex, secpalabra++));
            //            valor = uword.CharList[i + 1];
            //            texto = "";
            //        }

            //    }
            //}            
            //lista.Add(new BloqueTexto(valor.Left, right, valor.Top, bottom, uword.PointSize, texto, indicelinea,uword.LineIndex,secpalabra++));
            //if (lista.Count > 0)
            //{
            //    if (anterior == null)
            //    {
            //        anterior = lista[lista.Count - 1];
            //    }
            //    else
            //    {
            //        bool saltolinea = false;
            //        for (int k = 0; k < lista.Count; k++)
            //        {
            //            actual = lista[k];
            //            if (Math.Abs(actual.Y - anterior.Y) > 10)
            //            {
            //                saltolinea = true;
            //                indicelinea++;
            //                secpalabra = 0;                            
            //                anterior = actual;
            //            }
            //            lista[k].Linea = indicelinea;
            //            if (saltolinea)
            //            {
            //                lista[k].SecPalabra = secpalabra;
            //                secpalabra++;
            //            }
            //        }
            //        anterior = lista[lista.Count - 1];
            //    }
            //}
            
            return lista;
        }
    }
}
