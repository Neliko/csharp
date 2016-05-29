using System;
using HomeWork.Infrastructure;
using HomeWork.Model;

namespace HomeWork.Validation
{
    class EmailValidator : IValidator<Contact>
    {
        private readonly ILogger _logger;

        public EmailValidator(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            _logger = logger;
        }

        public bool IsValid(Contact entity)
        {
            try
            {
                return !string.IsNullOrWhiteSpace((entity).Value);
            }
            catch (Exception e)
            { 
               _logger.Log(e);
            }

            return true;          
        }
    }
}
