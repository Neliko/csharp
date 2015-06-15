using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class TelephoneContact : Contact
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
    }
}
