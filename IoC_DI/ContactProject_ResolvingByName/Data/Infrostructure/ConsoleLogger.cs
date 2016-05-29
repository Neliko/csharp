using System;

namespace Data.Infrostructure
{
   public class ConsoleLogger: ILogger
    {
        public void Log(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
