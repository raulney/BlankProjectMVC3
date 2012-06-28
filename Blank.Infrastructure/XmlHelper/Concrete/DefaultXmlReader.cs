using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blank.Infrastructure.XmlHelper.Abstract;
using System.IO;

namespace Blank.Infrastructure.XmlHelper.Concrete
{
    public class DefaultXmlReader : IXmlReader
    {
        public string XmlFrom(string path)
        {
            StringBuilder strXML = new StringBuilder("");
            using (StreamReader lerXML = new StreamReader(path)) {
                while (!lerXML.EndOfStream)
                {
                    strXML.Append(lerXML.ReadLine().ToString());
                }
            }
            return strXML.ToString();
        }
    }
}
