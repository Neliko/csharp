using System;
using System.IO;
using HomeWork.Infrastructure;
using HomeWork.Model;

namespace HomeWork.Validation
{
    internal  class ContactValidator : IValidator<Contact> 
    {
        protected ILogger _logger = new FileLogger();

        public ContactValidator(ILogger logger)
        {
            _logger = logger;
        }

        public ContactValidator()
        {
        }

        public virtual bool IsValid(Contact entity)
        {
            //try
            //{
            //    return true;
            //}
            //catch (Exception e)
            //{
            //   _logger.Log(e);
            //}
            return true;
        }
    }
}
