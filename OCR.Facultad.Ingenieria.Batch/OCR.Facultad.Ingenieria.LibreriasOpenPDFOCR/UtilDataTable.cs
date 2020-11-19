using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace OCR.Facultad.Ingenieria.LibreriasOpenPDFOCR
{
    public class UtilDataTable
    {
        public static DataTable ParseBloque(List<BloqueTexto> lista)
        {
            DataTable dt = new DataTable();

            var maxSecLista = (from element in lista
                               orderby element.SecPalabra
                               select element.SecPalabra).Max();
            var nLineas = (from element in lista
                           orderby element.Linea
                           select element.Linea).Max();
            for (int c = 0; c < (int)maxSecLista+1; c++)
            {
                dt.Columns.Add(c.ToString());
            }
            int lineaactual = 0;


            for (int i = 0, k = 0; i < (int)nLineas; i++)
            {

                DataRow dr = dt.NewRow();
                var maxSecListaLinea = (from element in lista
                                        where element.LineaOcr == i
                                        select element).Count();

                for (int j = 0; j < (int)maxSecListaLinea + 1; j++)
                {
                    if (lista[k].LineaOcr > i)
                    {
                        break;
                    }

                    dr[j.ToString()] = lista[k].texto;
                    k++;

                }

                dt.Rows.Add(dr);


            }
            dt.AcceptChanges();
          
            return dt;
            
        }
        protected static void ExportExcel(string unxlsoutput,int upagina,DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0) return;
            Microsoft.Office.Interop.Excel.Application xlApp =
                    new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                return;
            }
            System.Globalization.CultureInfo CurrentCI =
                   System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture =
                    new System.Globalization.CultureInfo("en-US");
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet =
                    (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range;
            if (File.Exists(unxlsoutput))
            {

                workbook = xlApp.Workbooks.Open(unxlsoutput,
                        0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
                        true, false, 0, true, false, false);
                workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                worksheet =
                        (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[upagina];
            }

          

            long totalCount = dt.Rows.Count;
            long rowRead = 0;
            float percent = 0;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, i + 1];
                range.Interior.ColorIndex = 15;
            }
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    try
                    {
                        worksheet.Cells[r + 2, i + 1] = dt.Rows[r][i].ToString();
                    }
                    catch
                    {
                        worksheet.Cells[r + 2, i + 1] =
                     dt.Rows[r][i].ToString().Replace("=", "");
                    }
                }
                rowRead++;
                percent = ((float)(100 * rowRead)) / totalCount;
            }         
            xlApp.Visible = true;
            xlApp.Save(unxlsoutput);
            
        }
    }
}
