using System;
<<<<<<< HEAD
using System.Collections.Generic;
=======
using System.IO;
>>>>>>> master

namespace HomeWork.Infrastructure
{
    public class ExceptionHandler
    {
<<<<<<< HEAD
        private IException _exceptionHandler = new ExceptionDefaultHandler(new FileLogger());

        private static readonly IDictionary<string, object> ExcaptionHandlerDictionary =
   new Dictionary<string, object>
            {
                {
                    "ArgumentNullException", new ArgumentNullExceptionHandler(new ConsoleLogger())
                },
                {
                    "InvalidOperationException", new InvalidOperationExceptionHandler()
                }
            };
        
        public void Handle(Exception e)
        {
            var exceptionType = e.GetType().Name;

            if (ExcaptionHandlerDictionary.ContainsKey(exceptionType))
            {
                _exceptionHandler = (IException) ExcaptionHandlerDictionary[exceptionType];
            }

            _exceptionHandler.Handle(e);
=======
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
>>>>>>> master
        }
    }
}
