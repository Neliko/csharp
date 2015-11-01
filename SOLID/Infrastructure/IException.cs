using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork.Infrastructure
{
    interface IException
    {
        void Handle(Exception e);
    }
}
