using System;
using Data;
using Data.BL;
using Data.Data;
using Data.Infrostructure;
using Data.Model;
using Microsoft.Practices.Unity;

namespace ContactsProject
{
    internal class Program
    {
        private static void PrepareRegistration(IUnityContainer unityContainer)
        {
            // регистрация типов
            unityContainer.RegisterType<ILogger, ConsoleLogger>("consoleLogger");
            unityContainer.RegisterType<ILogger, FileLogger>("fileLoger");
            unityContainer.RegisterType<IWriter, ConsoleWriter>("consoleWriter");
            unityContainer.RegisterType<IWriter, FileWriter>("fileWriter");   
        }

        private static IWriterService GetWriterServiceByWriterName(IUnityContainer unityContainer, string writerName)
        {
            unityContainer.RegisterType<IWriterService, WriterService>( new InjectionConstructor(unityContainer.Resolve<IWriter>(writerName)));

            var writerService = unityContainer.Resolve<IWriterService>();

            return writerService;
        }

        private static IExceptionHandler GetExceptionHandlerByLoggerName(IUnityContainer unityContainer, string loggerName)
        {
            unityContainer.RegisterType<IExceptionHandler, ExceptionHandler>(new InjectionConstructor(unityContainer.Resolve<ILogger>(loggerName)));

            var exceptionHanler = unityContainer.Resolve<IExceptionHandler>();

            return exceptionHanler;
        }
        private static void Main()
        {
            var unityContainer = new UnityContainer();

            PrepareRegistration(unityContainer);
            unityContainer.RegisterType<WriterService>("consoleWriterSrevice", new InjectionConstructor(unityContainer.Resolve<ConsoleWriter>("consoleLogger")));

            var writer = unityContainer.Resolve<IWriter>("consoleWriter");
            var eh = GetExceptionHandlerByLoggerName(unityContainer, "consoleLogger");

            // Получение репозитория
            unityContainer.RegisterType<IRepository<Contact>, Repository<Contact>>("contactRepository", new InjectionConstructor(eh, writer));
            var contactRepository = unityContainer.Resolve<IRepository<Contact>>("contactRepository");

            // добавление контактов различных типов в карточку
            var firstContact = new Email {Id = 1, Value = "n3@rambler.ru", Alias = "Neliko"};
            var secondContact = new Phone {Id = 2, Value = "12345", TelephoneZone = "07"};

            contactRepository.Add(firstContact);
            contactRepository.Add(secondContact);

            var writerService = GetWriterServiceByWriterName(unityContainer, "consoleWriter");

            // Вывод на консоль
            writerService.WriteAll(contactRepository.GetAll());

            Console.ReadKey();
        }
    }
}
