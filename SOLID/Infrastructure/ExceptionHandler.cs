using System;
using System.IO;

namespace HomeWork.Infrastructure
{
    public class ExceptionHandler : IException
    {
        // открыт для модификации. Передавать _logger  конструкторе
        readonly ILogger _logger = new FileLogger();

        public ExceptionHandler(ILogger fileLogger)
        {
            _logger = _logger;
        }

        public void Handle(Exception e)
        {
                _logger.Log(e);
        }

    }
}
