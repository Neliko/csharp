using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork.Infrastructure
{
    public interface ILogger
    {
        void Log(Exception e);
    }
}
