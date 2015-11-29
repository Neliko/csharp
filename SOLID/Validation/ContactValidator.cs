using System;
using System.IO;
using HomeWork.Model;

namespace HomeWork.Validation
{
    internal class ContactValidator : IValidator<Contact>
    {
        public bool IsValid(Contact entity)
        {
            try
            {
                switch (entity.Type)
                {
                    case ContactType.Phone:
                        return entity.PhoneCode != null && entity.Value != null;
                    case ContactType.Email:
                        return !string.IsNullOrWhiteSpace(entity.Value);
                }
            }
            catch (Exception e)
            {
                Log(e);
            }
            return true;
        }
        private void Log(Exception e)
        {
            File.AppendAllText("log.txt", e.Message);
        }
    }
}
