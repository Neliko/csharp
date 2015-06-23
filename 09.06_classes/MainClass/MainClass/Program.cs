using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace MainClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Card c = new Card();
            Console.WriteLine("Объект без параметров");
            c.GetData();
            c.SetName("NAME");
            c.SetProjectIs(123456789);
            c.SetSynCode(11111);
            Console.WriteLine("\nЭти данные изменены с помощью методов");
            c.GetData();
            Console.WriteLine("\nДанные переданы через конструктор");
            Card c2 = new Card("Parameter1", 22222, 987654321);
            c2.GetData();
            Console.ReadKey();

        }

    }
}
