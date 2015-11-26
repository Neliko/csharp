using System;
using System.Linq;

namespace CountWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст:");
            string str = Console.ReadLine();
            string[] newStrList = str.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var newStrListDistinct = newStrList.Distinct();
            int count = 0;

            foreach (var word in newStrListDistinct)
            {
                count = 0;
                foreach (string s in newStrList)
                {
                    if (s == word)
                        count++;
                }
                Console.WriteLine("Слово:{0} - {1}",word,count);       
            }  
            Console.ReadKey();
        }
    }
}
