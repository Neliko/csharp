using System;
using System.IO;
<<<<<<< HEAD
using HomeWork.Infrastructure;
=======
>>>>>>> master
using HomeWork.Model;

namespace HomeWork.Validation
{
<<<<<<< HEAD
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
=======
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
>>>>>>> master
        }
    }
}
