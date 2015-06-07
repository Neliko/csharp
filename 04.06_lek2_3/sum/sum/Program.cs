using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sum
{
    class Program
    {
 
        static void Main(string[] args)
        {
            int N = 0;
            int sum = 0;
            Console.WriteLine("Введите количество чисел");
            N=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите числа. Ввод нового числа осуществляется по нажатию на клавишу \"Enter\"");
            while (N>0)
            {
                try
                {
                    sum += Convert.ToInt32(Console.ReadLine());
                    ;
                    N--;
                }
                catch (Exception e)
                {
                    continue;        
                }

            }
            Console.WriteLine("Сумма чисел:"+sum);
            Console.ReadKey();
        }
    }
}
