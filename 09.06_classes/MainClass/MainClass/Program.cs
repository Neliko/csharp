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
            Console.WriteLine("Запуск из основного проекта. Данные переданы через конструктор");
            Card c2 = new Card("ParameterMain", 99999, 9999999);
            c2.GetData();
            Console.ReadKey();

        }
    }
}
