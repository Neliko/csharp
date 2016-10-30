using System;

namespace HomeWork.Infrastructure
{
    public interface IExceptionHandler
    {
        void Handle(Exception e);
    }
}
