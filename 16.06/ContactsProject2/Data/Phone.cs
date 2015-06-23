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
        private string _telephoneZone;

        public TelephoneContact()
        {
            _telephoneZone = "";
        }
        public TelephoneContact(string cname, string tz)
            : base(cname)
        {
            _telephoneZone = tz;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("City code : {0}", _telephoneZone);
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            TelephoneContact otherPhone = obj as TelephoneContact;
            if (otherPhone != null)
                return this._telephoneZone.CompareTo(otherPhone._telephoneZone);
            else
                throw new ArgumentException("Object is not a Card"); 
            throw new NotImplementedException();
        }

        public  override XElement ToXml()
        {
            XElement contact = new XElement("TelephoneContact");
            contact.Add(new XAttribute("Name", this.Name));
            contact.Add(new XAttribute("Zone", this._telephoneZone));
            return contact;
        }
    }
}
