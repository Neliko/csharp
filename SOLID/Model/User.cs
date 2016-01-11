﻿using System.Collections.Generic;

namespace HomeWork.Model
{
    internal class User : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Contact> Contacts { get; private set; }

        public User()
        {
            Contacts = new HashSet<Contact>();
        }
<<<<<<< HEAD

        public override string ToString()
        {
            return string.Format("Id={0}, Name={1}", Id, Name); 
        }

=======
>>>>>>> master
    }
}
