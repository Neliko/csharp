using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace raise
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите число:");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите степень:");
                int N = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ответ:{0}",Math.Pow(x, N));
            }
            catch (Exception e)
            {
                Console.WriteLine("Введенное значение должно быть числом");
            }
      return;
        }
    }
}
