using System;
using System.Collections.Generic;
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
       private static readonly UnityContainer unityContainer = new UnityContainer();

       private static IWriterService GetWriterServiceByWriterType<TWriterService, TWriter>(IUnityContainer unityContainer)
           where TWriter : IWriter, new()
           where TWriterService : IWriterService
       {
           var writerService = unityContainer.Resolve<TWriterService>(new DependencyOverride<TWriter>(new TWriter()));

           return writerService;
       }

        private static void Main()
        {
            Registration.PrepareRegistration(unityContainer);

            // Получение репозиториев контактов
            var contactRepository = Resolve<Contact>();
            var userRepository = Resolve<User>();

            // добавление контактов различных типов в карточку
            var emailContact = new Email {Id = 1, Value = "n3@rambler.ru", Alias = "Neliko"};
            var phoneContact = new Phone {Id = 2, Value = "12345", TelephoneZone = "07"};

            contactRepository.Add(emailContact);
            contactRepository.Add(phoneContact);

            var contacts = contactRepository.GetAll();
            var user = new User {Contacts = (ICollection<Contact>) contacts, Id = 1, Name = "Test"};

            userRepository.Add(user);

            var writerService = GetWriterServiceByWriterType<WriterService, ConsoleWriter>(unityContainer);

            // Вывод на консоль
            Console.WriteLine("Вывод данных на консоль через сервис");
            writerService.WriteAll(userRepository.GetAll());
            Console.WriteLine();
            writerService.WriteAll(contactRepository.GetAll());

            Console.ReadKey();
        }

        private static EntityRepository<TEntity> Resolve<TEntity>() where TEntity : class, IEntity
        {
            return unityContainer.Resolve<EntityRepository<TEntity>>();
        }
    }
}
