using System;
using HomeWork.BL;
using HomeWork.Data;
using HomeWork.Model;
using Microsoft.Practices.Unity;

namespace HomeWork
{
    internal class Program
    {
        private static readonly IUnityContainer UnityContainer = new UnityContainer();

        private static void Main()
        {
            // Регистрируем все зависимости
            Registration.PrepareRegistration(UnityContainer);
            // Разрешаем зависимости через generic-метод

           var userRepository = Resolve<User>();
           var contactRepository = Resolve<Contact>();
         
            var addingService = GetAddingService<Contact, AddingService<Contact>>(UnityContainer);

            var user = new User {Id = 1, Name = "Name"};

            var phone = new Phone {Id = 1, PhoneCode = "123", Value = "123124"};
            var email = new Email {Id = 2, Value = "mail@2gis.ru"};

            userRepository.Add(user);

            addingService.ValidateAndAddEntity(contactRepository, email);
            addingService.ValidateAndAddEntity(contactRepository, phone);

            Console.WriteLine(contactRepository.GetById(1));

            Console.WriteLine(contactRepository.GetById(2));

            Console.ReadKey();
        }

        private static EntityRepository<TEntity> Resolve<TEntity>() where TEntity : class, IEntity, new()
        {
            return UnityContainer.Resolve<EntityRepository<TEntity>>();
        }

        private static IService<TEntity> GetAddingService<TEntity, TService>(IUnityContainer unityContainer)
            where TEntity : IEntity where
                TService : IService<TEntity>
        {
            var addingService = unityContainer.Resolve<TService>(new DependencyOverride(typeof(IService<TEntity>), typeof(TService)));

            return addingService;
        }
    }
}
