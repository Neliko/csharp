using System;
using System.Reflection;

namespace Reflection_test
{
    class Program
    {
        static void Main(string[] args)
        {

            var grelka = (Cat) Activator.CreateInstance(typeof (Cat));
            var zarapka = (Cat)Activator.CreateInstance(typeof(Cat), new object[]{10});


            var murzik = new Cat();
            Type animalType = typeof(Cat);

            foreach (var attribute in animalType.GetCustomAttributes())
            {
                Console.WriteLine(attribute.ToString());
            }

			// todo: получить и вывести все методы класса, сколько их будет?

            Console.ReadKey();
        }
    }
}
