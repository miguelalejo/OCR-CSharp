using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace OCR.Facultad.Ingenieria.LibreriasOpenPDFOCR
{
    /// <summary>
    /// This attribute is used to represent a string value
    /// for a value in an enum.
    /// </summary>

    public class EnumStringAttribute : System.Attribute
    {
        /// <summary>
        /// Holds the stringvalue for a value in an enum.
        /// </summary>
        public string EnumStringValue { 
            get;
            protected set; 
        }
        /// <summary>
        /// Constructor used to init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public EnumStringAttribute(string value)
        {
            this.EnumStringValue= value;
        }
        /// <summary>
        /// Will get the string value for a given enums value, this will
        /// only work if you assign the StringValue attribute to
        /// the items in your enum.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override string ToString()
        {
            return EnumStringValue;
        }
        /// <summary>
        /// Will get the string value for a given enums value, this will
        /// only work if you assign the StringValue attribute to
        /// the items in your enum.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        

    }
    public static class EnumEstaticStringAttribute
    {
        public static string GetStringValue(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            EnumStringAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(EnumStringAttribute), false) as EnumStringAttribute[];

            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].EnumStringValue : null;
        }
      
    }
}
