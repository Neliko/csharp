using System;

namespace Data.Infrostructure
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger _logger;

        public ExceptionHandler(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentException("Необходимо указать logger");
            }

            _logger = logger;
        }
        public void Handle(Exception e)
        {
            _logger.Log(e);
        }
    }
}
