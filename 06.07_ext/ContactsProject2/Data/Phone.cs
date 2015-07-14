using System;
using System.Xml.Linq;

namespace Data
{
    public class TelephoneContact : Contact, IComparable
    {
        public string TelephoneZone { get; private set; }

        public TelephoneContact()
        {
            TelephoneZone = string.Empty;
        }
        public TelephoneContact(string cname, string tz)
            : base(cname)
        {
            TelephoneZone = tz;
        }

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
        public override object Clone()
        {
            return new TelephoneContact(Name, TelephoneZone);
        }

        public override XElement ToXml()
        {
            if (this.Name == string.Empty)
                throw new ArgumentException("Невозможно вывести пустой Xml-документ");
            var contact = new XElement("TelephoneContact");
            contact.Add(new XAttribute("Name", this.Name));
            contact.Add(new XAttribute("Zone", this.TelephoneZone));
            return contact;
        }
    }
}
