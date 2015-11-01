using System;
using HomeWork.Data.Model;

namespace HomeWork.UI.Model
{
    internal class UserModel
    {
        public string Name { get; set; }
        public ContactModel[] Contacts { get; set; }
        public OrderModel[] Orders { get; set; }
    }
}
