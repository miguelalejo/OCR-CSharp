using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCR.Facultad.Ingenieria.LibreriasOpenPDFOCR
{
    public class UtilXmlOcr
    {
        public static TypeCode TypeCodeString(string str)
        {

            Int32 intValue;
            Int64 bigintValue;
            double doubleValue;
            bool boolValue;
            DateTime dateValue;

            // Place checks higher if if-else statement to give higher priority to type.

            if (Int32.TryParse(str, out intValue))
                return TypeCode.Int32;
            else if (Int64.TryParse(str, out bigintValue))
                return TypeCode.Int64;
            else if (double.TryParse(str, out doubleValue))
                return TypeCode.Double;
            else if (bool.TryParse(str, out boolValue))
                return TypeCode.Boolean;
            else if (DateTime.TryParse(str, out dateValue))
                return TypeCode.DateTime;
            else return TypeCode.String;

        }

        public static TypeCode FindTypeCode(string utypecode)
        {

            Int32 intValue;
            Int64 bigintValue;
            double doubleValue;
            bool boolValue;
            DateTime dateValue;

            if (utypecode.Contains("Int32"))
            {
                return TypeCode.Int32;
            }
            if (utypecode.Contains("Int64"))
            {
                return TypeCode.Int64;
            }
            if (utypecode.Contains("Double"))
            {
                return TypeCode.Double;
            }
            if (utypecode.Contains("Boolean"))
            {
                return TypeCode.Boolean;
            }
            if (utypecode.Contains("DateTime"))
            {
                return TypeCode.DateTime;
            }
            return TypeCode.String;

        }
    }
}
