using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data
{
    public class Email : Contact, IComparable
    {
        private string _alias;

        public Email()
        {
            _alias = "";
        }

        public Email(string cname, string al)
            : base(cname)
        {
            _alias = al;
        }
        public string Alias
        {
            get { return _alias; }
            set { _alias = value; }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("mailto : ({0}) ", _alias);

        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Email otherEmail = obj as Email;
            if (otherEmail != null)
                return this._alias.CompareTo(otherEmail._alias);
            else
                throw new ArgumentException("Object is not a Card"); 
           
        }

        public override XElement ToXml()
        {
            XElement contact=new XElement("Email");
            contact.Add(new XAttribute("Name",this.Name));
            contact.Add(new XAttribute("Alias",this._alias));
            return contact;
        }
    }
}
