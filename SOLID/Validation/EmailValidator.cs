using System;
using HomeWork.Infrastructure;
using HomeWork.Model;

namespace HomeWork.Validation
{
    class EmailValidator : IValidator<Contact>
    {
        private ILogger logger;

        public EmailValidator(ILogger logger)
        {
            this.logger = logger;
        }

        public bool IsValid(Contact entity)
        {
            try
            {
                return !string.IsNullOrWhiteSpace((entity).Value);
            }
            catch (Exception e)
            { 
               logger.Log(e);
            }
            return true;          
        }
    }
}
