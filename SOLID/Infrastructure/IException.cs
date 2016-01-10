using System;

namespace HomeWork.Infrastructure
{
    public interface IException
    {
        void Handle(Exception e);
    }
}
