using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork.Infrastructure
{
    class ArgumentNullException : IException
    {
        // открыт для модификации. Передавать _logger в конструкторе
        private ILogger _logger = new ConsoleLogger();

      public void Handle(Exception e)
        {
            new ConsoleLogger().Log(e);
        }

      public void Handle(Exception e, ILogger logger)
      {
          logger.Log(e);
      }
    }
}
