using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsCard
{
    class Email : Contact
    {
        private string _alias;

        public Email()
        {
           _alias = "";
        }

        public Email(string cname, string al):base(cname)
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
            return base.ToString()+ string.Format("mailto : ({0}) ", _alias);
            
        }
    }
}
