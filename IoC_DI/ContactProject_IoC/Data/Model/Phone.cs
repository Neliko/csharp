using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;

namespace Data
{
    public class Phone : Contact
    {
        public string TelephoneZone;

        public override string ToString()
        {
            return base.ToString() + string.Format("City code : {0}", TelephoneZone);
        }
    }
}
