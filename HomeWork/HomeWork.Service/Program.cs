using System;
using HomeWork.UI.Service;

namespace HomeWork.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new OrderService();

            var user = service.GetUser(1);

            Console.WriteLine(user.Contacts.Length);
            Console.WriteLine(user.Orders[0].Total);
            Console.WriteLine(user.Orders[1].Total);

            Console.ReadKey();
        }
    }
}
