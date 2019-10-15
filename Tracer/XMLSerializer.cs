using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Tracer
{
    public class XMLSerializer : ISerializer
    {
        public string Serialize(object obj)
        {
            var serializer = new XmlSerializer(obj.GetType());
            StringWriter strWriter = null;
            try
            {
                strWriter = new StringWriter();
                serializer.Serialize(strWriter, obj);
            }
            finally
            {
                if (strWriter != null)
                {
                    strWriter.Dispose();
                }
            }
            return strWriter.ToString();
        }
    }
}
