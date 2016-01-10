using System;

namespace HomeWork.Infrastructure
{
    class ArgumentNullExceptionHandler : ExceptionDefaultHandler
    {

        public ArgumentNullExceptionHandler(ILogger logger) : base(logger)
        {
        }

        public override void Handle(Exception e)
        {
            _logger.Log(e);
        }
    }
}
