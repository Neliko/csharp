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
        private static void Main()
        {
            var unityContainer = new UnityContainer();

            // регистрация типов
            unityContainer.RegisterType<ILogger, ConsoleLogger>();
            unityContainer.RegisterType<IWriter, ConsoleWriter>();
            unityContainer.RegisterType<IExceptionHandler, ExceptionHandler>();

            // Получение репозитория
            var contactRepository = unityContainer.Resolve<Repository<Contact>>();
         
            // добавление контактов различных типов в карточку
            var firstContact = new Email {Id = 1, Value = "n3@rambler.ru", Alias = "Neliko"};
            var secondContact = new Phone {Id = 2, Value = "12345", TelephoneZone = "07"};

            contactRepository.Add(firstContact);
            contactRepository.Add(secondContact);

            var writerService = unityContainer.Resolve<WriterService>();

            //// Вывод на консоль
            writerService.WriteAll(contactRepository.GetAll());

            Console.ReadKey();
        }
    }
}
