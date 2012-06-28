using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blank.Infrastructure.XmlHelper.Abstract
{
    public interface IDeserializer
    {
        T DeserializeFromXml<T>(string xml);
    }
}
