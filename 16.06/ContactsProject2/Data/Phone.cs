using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var otherPhone = obj as TelephoneContact;
            if (otherPhone != null)
            {
                if (!this.TelephoneZone.Equals(otherPhone.TelephoneZone))
                    return this.Name.CompareTo(otherPhone.Name);
                return this.TelephoneZone.CompareTo(otherPhone.TelephoneZone);
            }

            else
                throw new ArgumentException("Object is not a Phone");
        }
        public override object Clone()
        {
            return new TelephoneContact(Name, TelephoneZone);

        }

        public  override XElement ToXml()
        {
            var contact = new XElement("TelephoneContact");
            contact.Add(new XAttribute("Name", this.Name));
            contact.Add(new XAttribute("Zone", this.TelephoneZone));
            return contact;
        }
    }
}
