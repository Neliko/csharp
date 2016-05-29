using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;

namespace Data
{
    public class Email : Contact
    {
        private string _alias;

        public string Alias
        {
            get { return _alias; }
            set { _alias = value; }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("mailto : ({0}) ", _alias);

        }
    }
}
