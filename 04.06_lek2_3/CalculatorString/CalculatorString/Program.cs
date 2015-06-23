using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorString
{
    class Program
    {
        public static double Sum(double a, double b)
        {
            return a + b;
        }

        public static double Min(double a, double b)
        {
            return a - b;
        }

        public static double Multiplication(double a, double b)
        {
            return a * b;
        }


        public static double Division(double a, double b)
        {
            return a / b;
        }

        public static double Pow(double a, double b)
        {
            return Math.Pow(a, b);
        }

        public static double Remainder(double a, double b)
        {

            return a % b;
        }

        static void Main(string[] args)
        {

            while (true)
            {
                try
                {
                    Console.WriteLine("Введите арифметическое выпажение. Кажый операнд вводится через пробел");
                    Console.WriteLine("Возможные варианы операторов: +,-,/,*,^,%");
                    string expression = Console.ReadLine();
                    string[] allData = expression.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); 
                    double a = Convert.ToDouble(allData[0]);
                    char operation = Convert.ToChar(allData[1]);
                    double b = Convert.ToDouble(allData[2]);

                    double answer = 0;
                   
                        switch (operation)
                        {
                            case '+':
                                answer = Sum(a, b);
                                break;
                            case '-':
                                answer = Min(a, b);
                                break;
                            case '*':
                                answer = Multiplication(a, b);
                                break;
                            case '/':
                                answer = Division(a, b);
                                break;
                            case '^':
                                answer = Pow(a, b);
                                break;
                            case '%':
                                answer = Remainder(a, b);
                                break;
                            default:
                                Console.WriteLine("Введенного оператора не существует. Повторите попытку\n");
                                continue;
                        }
                        Console.WriteLine("\nОтвет:{0}", answer);
                       
                    } catch (Exception e)
                {
                    Console.WriteLine("Ой, произошла ошибка. Введите все данные заново");
                }
                Console.WriteLine("Выйти? y/n");
                if (Console.ReadLine() == "y")
                    break;
                Console.WriteLine();
                    
                }

            }
    }
}
