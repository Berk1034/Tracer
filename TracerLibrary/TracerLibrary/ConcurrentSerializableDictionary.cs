using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;

namespace TracerLibrary
{
    public class ConcurrentSerializableDictionary<TKey, TValue> : ConcurrentDictionary<TKey, TValue>, IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            Console.WriteLine("Not implemented");
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            Console.WriteLine("Not implemented");
        }

        public void WriteXml(XmlWriter writer)
        {
            XmlSerializer ValueSerializer = new XmlSerializer(typeof(TValue));
            foreach (TKey key in Keys)
            {
                TValue value = this[key];
                ValueSerializer.Serialize(writer, value);
            }
        }
    }
}
