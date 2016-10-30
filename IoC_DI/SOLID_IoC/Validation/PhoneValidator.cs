using System;
using HomeWork.Infrastructure;
using HomeWork.Model;

namespace HomeWork.Validation
{
    internal class PhoneValidator : IValidator<Contact>
    {
        private readonly ILogger _logger;

        public PhoneValidator(ILogger logger)
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
                return (((Phone)entity).PhoneCode != null && entity.Value != null);
            }
            catch (Exception e)
            {
               _logger.Log(e);
            }

            return true;
        }
    }
}
