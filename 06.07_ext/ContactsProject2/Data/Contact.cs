using System;
using System.Xml.Linq;

namespace Data
{
    public abstract class Contact:IComparable, ICloneable
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
            return null;   
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var otherContact = obj as Contact;
            if (otherContact != null)
                return (System.String.Compare(this.Name, otherContact.Name, System.StringComparison.Ordinal));
            else
                throw new ArgumentException("Object is not a Contact");
        }

        public virtual XElement ToXml()
        {
            if (this.Name == string.Empty)
                throw new ArgumentException("Невозможно вывести пустой Xml-документ");
           var contact = new XElement("Contact",new XAttribute("Name", Name));
           return contact;
        }
      
    }
}
