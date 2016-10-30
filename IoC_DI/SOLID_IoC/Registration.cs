using System;
using System.Collections.Generic;
using HomeWork.Data;
using HomeWork.Infrastructure;
using HomeWork.Model;
using HomeWork.Validation;
using Microsoft.Practices.Unity;

namespace HomeWork
{
    public static class Registration
    {
        private const string TxtName = "logfile.txt";
        private static readonly ILogger FiLogger = new FileLogger(TxtName);

        // Для всех зависимостей задаем обработчик и логирование в консоль
        private static readonly Dictionary<Type, object> Validators = new Dictionary<Type, object>
        {
            {
                typeof (Email), new EmailValidator(FiLogger)
            },
            {
                typeof (Phone), new PhoneValidator(FiLogger)
            }
        };

        public static void PrepareRegistration(IUnityContainer unityContainer)
        {
            // регистрация типов
            unityContainer.RegisterType<ILogger, ConsoleLogger>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IExceptionHandler, ExceptionHandler>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IValidatorFactory, ValidatorFactory>(new ContainerControlledLifetimeManager(), new InjectionConstructor(Validators));

            unityContainer.RegisterType<EntityRepository<Contact>>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<EntityRepository<User>>(new ContainerControlledLifetimeManager());
        }
    }
}
