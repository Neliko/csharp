using System;

namespace HomeWork.Infrastructure
{
    class ConsoleLogger : ILogger
    {
        public void Log(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
