using System;

namespace HomeWork.Infrastructure
{
    public interface ILogger
    {
        void Log(Exception e);
    }
}
