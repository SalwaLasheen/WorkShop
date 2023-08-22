using System.Xml.Serialization;

namespace Application.Common
{
    public static class Converter
    {
        public static string ToXML(object obj)
        {
            using var stringwriter = new StringWriter();
                var serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(stringwriter, obj);
                return stringwriter.ToString();
        }
        
    }
}
