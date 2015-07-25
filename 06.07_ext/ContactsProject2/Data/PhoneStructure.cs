using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data
{
    public struct PhoneStructure : IXmlSerializable
    {
        public string TelephoneZone { get; set; }
        public string Name { get; set; }


        public override string ToString()
        {
            return base.ToString() + string.Format("City code : {0}", TelephoneZone);
        }

        public new int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var otherPhone = obj as TelephoneContact;
            if (otherPhone != null)
            {
                if (!this.Name.Equals(otherPhone.Name))
                    return System.String.Compare(this.Name, otherPhone.Name, System.StringComparison.Ordinal);
                return System.String.Compare(this.TelephoneZone, otherPhone.TelephoneZone, System.StringComparison.Ordinal);
            }
            else
                throw new ArgumentException("Object is not a Phone");
        }
        public object Clone()
        {
            return new TelephoneContact(Name, TelephoneZone);
        }

        public XElement ToXml()
        {
            if (this.Name == string.Empty)
                throw new ArgumentException("Невозможно вывести пустой Xml-документ");
            var contact = new XElement("TelephoneContact");
            contact.Add(new XAttribute("Name", this.Name));
            contact.Add(new XAttribute("Zone", this.TelephoneZone));
            return contact;
        }

        public XDocument SaveToXml()
        {
            XDocument doc = new XDocument(this.ToXml());
            return doc;
        }
        public void LoadFromXml(XDocument doc)
        {
            if (doc.Root == null || doc.Root.Name != "TelephoneContact")
                throw new ArgumentException("Данный Xml не является телефонным контактом");
            this.Name = (string)doc.Root.Attribute("Name");
            this.TelephoneZone = (string)doc.Root.Attribute("Zone");
        }
    }
}
