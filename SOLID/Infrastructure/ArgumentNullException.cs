using System;

namespace HomeWork.Infrastructure
{
    class ArgumentNullExceptionHandler : ExceptionDefaultHandler
    {

        public ArgumentNullExceptionHandler(ILogger logger) : base(logger)
        {
        }

        public override void HandleException(Exception e)
        {
            _logger.Log(e);
        }
    }
}
