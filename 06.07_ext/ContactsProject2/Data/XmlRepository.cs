using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data
{
    public class XmlRepository<TItem> where TItem : IXmlSerializable, new()
    {
        public TItem LoadFromXml<TItem2>(XDocument doc) where TItem2 : new()
        {
            if (doc == null || doc.Root== null)
            {
                throw new ArgumentException("Неизвестный тип данных");
            }
            var t = new TItem();
            t.LoadFromXml(doc);

            return t;
        }

        public XDocument SaveToXml(TItem item)
        {
            if (item != null)
                return item.SaveToXml();
            return null;
        }
    }
}
