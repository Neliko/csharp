using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc
{
    class Program
    {
        static void Main(string[] args)
        {
            double a;
            double b;
            char action=' ';
            double answer=0;
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите левый операнд");
                    a = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите один из операторов: +,-,/,*,^,%");
                    action = Convert.ToChar(Console.ReadLine());
                    Console.WriteLine("Введите правый операнд");
                    b = Convert.ToDouble(Console.ReadLine());

                    answer = 0;

                    switch (action)
                    {
                        case '+':
                            answer = a + b;
                            break;
                        case '-':
                            answer = a - b;
                            break;
                        case '*':
                            answer = a*b;
                            break;
                        case '/':
                            answer = a/b;
                            break;
                        case '^':
                            answer = Math.Pow(a, b);
                            break;
                        case '%':
                            answer = a%b;
                            break;
                        default: Console.WriteLine("Введенного оператора не существует. Повторите попытку\n"); continue;
                    }
                    Console.WriteLine("\nОтвет:{0}", answer);
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ой, произошла ошибка. Введите все данные заново ");
                }
                Console.WriteLine("Выйти? y/n");
                if (Console.ReadLine() == "y")
                    break;
                  
                Console.WriteLine();
            }


        }
    }
}
