     using System;

namespace HomeWork.Infrastructure
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger _logger;

        public ExceptionHandler(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            _logger = logger;
        }

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
                _logger.Log(e);
            }
        }
    }
}

