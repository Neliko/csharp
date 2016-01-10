using HomeWork.Model;

namespace HomeWork.Validation
{
    class EmailValidator : IValidator<Contact>
    {
        public bool IsValid(Contact entity)
        {
            return !string.IsNullOrWhiteSpace((entity).Value);
        }
    }
}
