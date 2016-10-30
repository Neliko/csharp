using System;

namespace Data.Infrostructure
{
    public interface ILogger
    {
        void Log(Exception e);
    }
}
