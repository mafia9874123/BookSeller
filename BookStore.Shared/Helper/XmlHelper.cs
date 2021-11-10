using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Lib.Helper
{
    public static class XmlHelper
    {
        public static T DeserializeXmlFileToObject<T>(this string xml)
        {
            T returnObject;
            using (var xmlStream = new StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(T));
                returnObject = (T)serializer.Deserialize(xmlStream);
            }

            return returnObject;
        }

        public static string SerializeXmlObjectToFile<T>(this T xml, string path)
        {
            string fileName = DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xml";
            var writer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (var file = System.IO.File.Create(path + fileName))
            {
                writer.Serialize(file, xml);
                file.Close();
            }

            return fileName;
        }
    }
}
