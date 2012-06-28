using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blank.Infrastructure.XmlHelper.Abstract;
using System.Xml.Serialization;
using System.IO;

namespace Blank.Infrastructure.XmlHelper.Concrete
{
    public class DefaultDeserializer : IDeserializer
    {
        public T DeserializeFromXml<T>(string xml)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (TextReader tr = new StringReader(xml))
            {
               return (T)ser.Deserialize(tr);
            }
            
        }
    }
}
