using System;
using HomeWork.Data;
using HomeWork.Model;
using HomeWork.Validation;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User { Id = 1, Name = "Name" };

            var phone = new Phone { Id = 1, PhoneCode = "123", Value = "123124"};
            var email = new Email { Id = 2, Value = "mail@2gis.ru" };

            var userRepository = GetRepository<User, UserValidator>();
            userRepository.Add(user);

            var contactRepository = GetRepository<Contact, ContactValidator>();

          //  if (validator.IsValid(email))
                contactRepository.Add(phone);

         //   if (validator.IsValid(phone))
                contactRepository.Add(email);

            Console.WriteLine(contactRepository.GetById(1));

            Console.WriteLine(contactRepository.GetById(2));

            Console.ReadKey();
        }
     private static IRepository<TEntity, TValidator> GetRepository<TEntity, TValidator>()
            where TEntity : class, IEntity, new() where TValidator : IValidator<TEntity>, new()
     {
            return new EntityRepository<TEntity, TValidator>();
        }

    }
}
