using System;
using System.Collections.Generic;
using System.Xml;
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

        //IDictionary<string, object> ValidatorGetterDictionary = new Dictionary<string, object>
        //    {
        //        {
        //           "Email",  new EmailValidator(FileLogger)
        //        },
        //        {
        //           "Phone",  new PhoneValidator(FileLogger) 
        //        }
        //    };

        static void Main(string[] args)
        {
            var user = new User { Id = 1, Name = "Name" };

            var phone = new Phone { Id = 1, PhoneCode = "123", Value = "123124" };
            var email = new Email { Id = 2, Value = "mail@2gis.ru" };

            var exceptionHandler = new ExceptionHandler(FileLogger);

            var userRepository = GetRepository<User>(exceptionHandler);
            userRepository.Add(user);

            var contactRepository = GetRepository<Contact>(exceptionHandler);

            new ValidationAndAddingService<Contact>(new EmailValidator(FileLogger)).ValidateAndAddEntity(contactRepository, email);
            new ValidationAndAddingService<Contact>(new PhoneValidator(FileLogger)).ValidateAndAddEntity(contactRepository, phone);

            Console.WriteLine(contactRepository.GetById(1));

            Console.WriteLine(contactRepository.GetById(2));

            Console.ReadKey();
        }

        //public IValidator<TEntity> GetValidator<TEntity>(TEntity entity) where TEntity : IEntity
        //{
        //    return (IValidator<TEntity>)ValidatorGetterDictionary[entity.GetType().Name];

        //}
        private static IRepository<TEntity> GetRepository<TEntity>(IExceptionHandler exceptionHandler)
               where TEntity : class, IEntity, new()
        {
            return new EntityRepository<TEntity>(exceptionHandler);
        }
    }
}
