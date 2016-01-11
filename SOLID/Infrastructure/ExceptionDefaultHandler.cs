using System;

namespace HomeWork.Infrastructure
{
    class ExceptionDefaultHandler: IException
    {
        protected readonly ILogger _logger;

        public ExceptionDefaultHandler(ILogger logger)
        {
            _logger = logger;
        }

        public virtual void HandleException(Exception e)
        {
           _logger.Log(e);
        }
    }
}
