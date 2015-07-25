using System;
using System.Xml.Linq;

namespace Data
{
    public class Email : Contact, IComparable, ICloneable, IXmlSerializable
    {
        public string Alias { get; set; }
        public Email()
        {
            Alias = string.Empty;
        }

        public Email(string cname, string al)
            : base(cname)
        {
            Alias = al;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("mailto : ({0}) ", Alias);

        }

        public override object Clone()
        {
            return new Email(Name, Alias);
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var otherEmail = obj as Email;
            if (otherEmail != null)
            {
                //сравниваю по имени
                if (!this.Name.Equals(otherEmail.Name))
                    return this.Name.CompareTo(otherEmail.Name);
                //если равны - возвращаю позицию alias
                return this.Alias.CompareTo(otherEmail.Alias);
            }
            else
            {
                throw new ArgumentException("Object is not a Email");  
            }

        }
        public override XElement ToXml()
        {
            if (this.Name == string.Empty)
                throw new ArgumentException("Невозможно вывести пустой Xml-документ");
            var contact = new XElement("Email");
            contact.Add(new XAttribute("Name", this.Name));
            contact.Add(new XAttribute("Alias", this.Alias));
            return contact;
        }

        public XDocument SaveToXml()
        {
            return new XDocument(this.ToXml());
        }

        public void LoadFromXml(XDocument doc)
        {
            if (doc.Root == null || doc.Root.Name != "Email")
                    throw new ArgumentException("Данный Xml не является электронным адресом");
            this.Name = (string)doc.Root.Attribute("Name");
            this.Alias = (string)doc.Root.Attribute("Alias");
        }
    }
}
