using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork.Infrastructure
{
    class ConsoleLogger:ILogger
    {
        public void Log(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
