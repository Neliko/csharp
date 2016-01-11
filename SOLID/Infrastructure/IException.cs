using System;

namespace HomeWork.Infrastructure
{
    public interface IException
    {
        void HandleException(Exception e);
    }
}
