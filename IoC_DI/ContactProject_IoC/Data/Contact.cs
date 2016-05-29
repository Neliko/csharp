using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Data
{
    public class Contact:IComparable, ICloneable
    {
        public string Name { get; set; }

        protected Contact()
        {
            Name = string.Empty;

        }

        protected Contact(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} \n", Name);
        }

        public virtual object Clone()
        {
           return new Contact(Name);
               
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var otherContact = obj as Contact;
            if (otherContact != null)
                return (this.Name.CompareTo(otherContact.Name));
            else
                throw new ArgumentException("Object is not a Contact");

        }


        public virtual XElement  ToXml()
        {
           var contact = new XElement("Contact",new XAttribute("Name", Name));
           return contact;
        }

    }
}
