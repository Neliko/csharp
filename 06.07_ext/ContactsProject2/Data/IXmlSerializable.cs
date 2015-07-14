using System.Xml.Linq;

namespace Data
{
    public interface IXmlSerializable
    {
         XDocument SaveToXml();
         void LoadFromXml(XDocument doc);
    }
}
