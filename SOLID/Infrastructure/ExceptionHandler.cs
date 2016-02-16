     using System;

namespace HomeWork.Infrastructure
{
    public class ExceptionHandler : IExceptionHandler
    {
        private ILogger logger;

        public ExceptionHandler(ILogger logger)
        {
            this.logger = logger;
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
                logger.Log(e);
            }
        }
    }
}

