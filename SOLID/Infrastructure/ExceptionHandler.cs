using System;
using System.Collections.Generic;

namespace HomeWork.Infrastructure
{
    public class ExceptionHandler
    {
        private IException _exceptionHandler = new ExceptionDefaultHandler(new FileLogger());

        private static readonly IDictionary<string, object> ExcaptionHandlerDictionary =
   new Dictionary<string, object>
            {
                {
                    "ArgumentNullException", new ArgumentNullExceptionHandler(new ConsoleLogger())
                }
            };

        private static readonly IList<string> ExcaptionHandlerListWoHandler = new List<string>()  
            {
               "InvalidOperationException"
            };

        public void Handle(Exception e)
        {
            var exceptionType = e.GetType().Name;

            if (ExcaptionHandlerListWoHandler.Contains(exceptionType))
                return;

            if (ExcaptionHandlerDictionary.ContainsKey(exceptionType))
            {
                _exceptionHandler = (IException)ExcaptionHandlerDictionary[exceptionType];
            }

            _exceptionHandler.HandleException(e);
        }
    }
}
