using System;

namespace Data.Infrostructure
{
    public interface IExceptionHandler
    {
        void Handle(Exception e);
    }
}
