using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z1
{
    class Program
    {
        private static void Main(string[] args)
        {
            int x1 = 0;
            int x2 = 0;

            while (true)
            {
                try
                {
                    Console.WriteLine("Введите первое число:");
                    x1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите второе число:");
                    x2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ответ:{0}",x1+x2);
                }
                catch
                {
                    Console.WriteLine("Введенные параметры должны быть числом");
                }

                Console.WriteLine("\nВыйти? y/n");
                if ( Console.ReadLine() == "y")
                    break;

            }
        }
    }
}
