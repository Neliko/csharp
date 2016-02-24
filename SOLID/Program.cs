using System;
using System.Collections.Generic;
using HomeWork.BL;
using HomeWork.Data;
using HomeWork.Infrastructure;
using HomeWork.Model;
using HomeWork.Validation;

namespace HomeWork
{
    class Program
    {
        const string TxtName = "logfile.txt";
        private static readonly ILogger FileLogger = new FileLogger(TxtName);

        static readonly Dictionary<Type, object> ValidatorGetterDictionary = new Dictionary<Type, object>
            {
                {
                   typeof(Email),  new EmailValidator(FileLogger)
                },
                {
                   typeof(Phone),  new PhoneValidator(FileLogger) 
                }
            };

        static void Main(string[] args)
        {
            var user = new User { Id = 1, Name = "Name" };

            var phone = new Phone { Id = 1, PhoneCode = "123", Value = "123124" };
            var email = new Email { Id = 2, Value = "mail@2gis.ru" };

            var exceptionHandler = new ExceptionHandler(FileLogger);

            var userRepository = GetRepository<User>(exceptionHandler);
            userRepository.Add(user);

            var contactRepository = GetRepository<Contact>(exceptionHandler);

            var validatorFactory = new ValidatorFactory(ValidatorGetterDictionary);
            validatorFactory.Create(email);
            new ValidationAndAddingService<Contact>(validatorFactory).ValidateAndAddEntity(contactRepository, email);
            new ValidationAndAddingService<Contact>(validatorFactory).ValidateAndAddEntity(contactRepository, phone);

            Console.WriteLine(contactRepository.GetById(1));

            Console.WriteLine(contactRepository.GetById(2));

            Console.ReadKey();
        }

        private static IRepository<TEntity> GetRepository<TEntity>(IExceptionHandler exceptionHandler)
               where TEntity : class, IEntity, new()
        {
            return new EntityRepository<TEntity>(exceptionHandler);
        }
    }
}
