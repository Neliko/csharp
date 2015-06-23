using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Data
{
    public abstract class Contact:IComparable
    {
        public string Name { get; private set; }
           // ame { get; private set; }

        public Contact()
        {
            Name = "";

        }

        public Contact(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} \n", Name);
        }

        public int CompareTo(object obj)
        {
        if(  obj.GetType() != this.GetType())
            throw new Exception("Типы не сравнимы");
         return 1;
        }


        public virtual XElement  ToXml()
        {
           XElement contact = new XElement("Contact",new XAttribute("Name", Name));
           return contact;
        }

    }
}
