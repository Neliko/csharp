using System;
using HomeWork.Infrastructure;
using HomeWork.Model;

namespace HomeWork.Validation
{
    internal class PhoneValidator : ContactValidator
    {
        public PhoneValidator(ILogger logger)
            : base(logger)
        {
        }

        public override bool IsValid(Contact entity)
        {
            try
            {
                return (((Phone) entity).PhoneCode != null && entity.Value != null);
            }
            catch (Exception e)
            {
                _logger.Log(e);
                return false;
            }
        }
    }
}
