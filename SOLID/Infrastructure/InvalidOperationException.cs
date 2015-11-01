using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeWork.Infrastructure
{
    class InvalidOperationException : IException
    {
      public void Handle(Exception e)
        {
            throw new Exception("Custom exception", e);
        }
    }
}
