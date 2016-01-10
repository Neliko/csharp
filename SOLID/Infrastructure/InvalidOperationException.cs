using System;

namespace HomeWork.Infrastructure
{
    class InvalidOperationExceptionHandler : IException
    {
        public void Handle(Exception e)
        {
            throw new Exception("Custom exception", e);
        }
    }
}
