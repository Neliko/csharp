using HomeWork.Model;

namespace HomeWork.Validation
{
    internal class PhoneValidator : IValidator<Contact>
    {
        public bool IsValid(Contact entity)
        {
            return (((Phone)entity).PhoneCode != null && entity.Value != null);
        }
    }
}
