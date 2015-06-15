using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class Contact
    {
        public string Name { get; private set; }

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
            return string.Format("Name: {0}\n", Name);
        }
    }
}
