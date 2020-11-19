using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace OCR.Facultad.Ingenieria.Estadisticas
{
    public class Serealizar
    {
        static public void SerializeToXML(List<EstadisticaProcesamiento> lista,string rutaarchivo)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<EstadisticaProcesamiento>));
            TextWriter textWriter = new StreamWriter(rutaarchivo);
            serializer.Serialize(textWriter, lista);
            textWriter.Close();
        }
        public static List<EstadisticaProcesamiento> DeserializeFromXML(string rutaarchivo)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<EstadisticaProcesamiento>));
            TextReader textReader = new StreamReader(rutaarchivo);
            List<EstadisticaProcesamiento> lista;
            lista = (List<EstadisticaProcesamiento>)deserializer.Deserialize(textReader);
            textReader.Close();

            return lista;
        }
    }
}
