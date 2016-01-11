using System;
using HomeWork.Data;
using HomeWork.Model;
<<<<<<< HEAD
=======
using HomeWork.Validation;
>>>>>>> master

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            var user = new User{ Id = 1, Name = "Name" };

            var phone = new Phone{ Id = 1, PhoneCode = "123", Value = "123124" };
            var email = new Email { Id = 2, Value = "mail@2gis.ru" };
            
=======
            var user = new User { Id = 1, Name = "Name" };

            var phone = new Contact { Type = ContactType.Phone, Id = 1, PhoneCode = "123", Value = "123124" };
            var email = new Contact { Type = ContactType.Email, Id = 2, Value = "mail@2gis.ru" };

            var validator = new ContactValidator();

>>>>>>> master
            var userRepository = GetRepository<User>();
            userRepository.Add(user);

            var contactRepository = GetRepository<Contact>();

<<<<<<< HEAD
            contactRepository.Add(email);

            contactRepository.Add(phone);
=======
            if (validator.IsValid(email))
                contactRepository.Add(phone);

            if (validator.IsValid(phone))
                contactRepository.Add(email);
>>>>>>> master

            Console.WriteLine(contactRepository.GetById(1));

            Console.WriteLine(contactRepository.GetById(2));
<<<<<<< HEAD

            Console.ReadKey();
        }
        private static IRepository<TEntity> GetRepository<TEntity>()
               where TEntity : class, IEntity, new()
=======
        }

        private static IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity
>>>>>>> master
        {
            return new EntityRepository<TEntity>();
        }
    }
}
