using System;
using System.Xml;
using HomeWork.BL;
using HomeWork.Data;
using HomeWork.Infrastructure;
using HomeWork.Model;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User{ Id = 1, Name = "Name" };

            var phone = new Phone {Id = 1, PhoneCode = null, Value = "123124" };
            var email = new Email { Id = 2, Value = "mail@2gis.ru" };

            const string txtName = "logfile.txt";
            var fileLogger = new FileLogger(txtName);
            var exceptionHandler = new ExceptionHandler(fileLogger);

            var userRepository = GetRepository<User>(exceptionHandler);
            userRepository.Add(user);

            var contactRepository = GetRepository<Contact>(exceptionHandler);

            var testService = new AddingValidationService<Contact>(fileLogger);
            testService.ValidateAndAddEntity(contactRepository, email);
            testService.ValidateAndAddEntity(contactRepository, phone);

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
