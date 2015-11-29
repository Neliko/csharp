using System;
using System.IO;

namespace HomeWork.Infrastructure
{
    public class ExceptionHandler
    {
        public void Handle(Exception e)
        {
            if (e is ArgumentNullException)
            {
                Console.WriteLine(e.Message);
            }
            else if (e is InvalidOperationException)
            {
                throw new Exception("Custom exception", e);
            }
            else
            {
                Log(e);
            }
        }

        private void Log(Exception e)
        {
            File.AppendAllText("log.txt", e.Message);
        }
    }
}
