using System;
using HomeWork.Data;
using HomeWork.Model;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User{ Id = 1, Name = "Name" };

            var phone = new Phone{ Id = 1, PhoneCode = "123", Value = "123124" };
            var email = new Email { Id = 2, Value = "mail@2gis.ru" };
            
            var userRepository = GetRepository<User>();
            userRepository.Add(user);

            var contactRepository = GetRepository<Contact>();

            contactRepository.Add(email);

            contactRepository.Add(phone);

            Console.WriteLine(contactRepository.GetById(1));

            Console.WriteLine(contactRepository.GetById(2));

            Console.ReadKey();
        }
        private static IRepository<TEntity> GetRepository<TEntity>()
               where TEntity : class, IEntity, new()
        {
            return new EntityRepository<TEntity>();
        }
    }
}
