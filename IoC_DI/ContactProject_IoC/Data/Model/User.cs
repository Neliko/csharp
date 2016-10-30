﻿using System.Collections.Generic;

namespace Data.Model
{
    public class User : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Contact> Contacts { get;  set; }

        public User()
        {
            Contacts = new HashSet<Contact>();
        }

        public override string ToString()
        {
            return string.Format("Id={0}, Name={1}", Id, Name);
        }

    }
}
