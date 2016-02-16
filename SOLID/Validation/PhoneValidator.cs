using System;
using HomeWork.Infrastructure;
using HomeWork.Model;

namespace HomeWork.Validation
{
    internal class PhoneValidator : IValidator<Contact>
    {
        private ILogger logger;

        public PhoneValidator(ILogger logger)
        {
            this.logger = logger;
        }

        public bool IsValid(Contact entity)
        {
            try
            {
                return (((Phone)entity).PhoneCode != null && entity.Value != null);
            }
            catch (Exception e)
            {
               logger.Log(e);
            }
            return true;
        }
    }
}
