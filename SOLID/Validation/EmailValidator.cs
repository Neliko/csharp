using System;
using HomeWork.Infrastructure;
using HomeWork.Model;

namespace HomeWork.Validation
{
    class EmailValidator : ContactValidator
    {
        public EmailValidator(ILogger logger) : base(logger)
        {
        }

        public override bool IsValid(Contact entity)
        {
            try
            {
                return !string.IsNullOrWhiteSpace(((Email)entity).Value);

            }
            catch (Exception e)
            {
              _logger.Log(e);
                return false;
            }
          
        }
    }
}
