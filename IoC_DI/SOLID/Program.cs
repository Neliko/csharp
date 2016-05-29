using System;
using System.Collections.Generic;
using HomeWork.BL;
using HomeWork.Data;
using HomeWork.Infrastructure;
using HomeWork.Model;
using HomeWork.Validation;
using Microsoft.Practices.Unity;

namespace HomeWork
{
    class Program
    {
        const string TxtName = "logfile.txt";
        private static readonly ILogger FileLogger = new FileLogger(TxtName);

        static readonly Dictionary<Type, object> Validators = new Dictionary<Type, object>
            {
                {
                   typeof(Email),  new EmailValidator(FileLogger)
                },
                {
                   typeof(Phone),  new PhoneValidator(FileLogger) 
                }
            };

        static void Main()
        {
            // Регистрируем контейнер
            var unityContainer = new UnityContainer();

            // Для всех зависимостей задаем обработчик и логирование в консоль
            unityContainer.RegisterType<ILogger, ConsoleLogger>();
            unityContainer.RegisterType<IExceptionHandler, ExceptionHandler>();

            unityContainer.RegisterType<IValidatorFactory, ValidatorFactory>(new InjectionConstructor(Validators));

            var contactRepository = unityContainer.Resolve<EntityRepository<Contact>>();
            var userRepository = unityContainer.Resolve<EntityRepository<User>>();

            var addingService = unityContainer.Resolve<AddingService<Contact>>();

            var user = new User { Id = 1, Name = "Name" };

            var phone = new Phone { Id = 1, PhoneCode = "123", Value = "123124" };
            var email = new Email { Id = 2, Value = "mail@2gis.ru" };

            userRepository.Add(user);

            addingService.ValidateAndAddEntity(contactRepository, email);
            addingService.ValidateAndAddEntity(contactRepository, phone);

            Console.WriteLine(contactRepository.GetById(1));

            Console.WriteLine(contactRepository.GetById(2));

            Console.ReadKey();
        }
    }
}
