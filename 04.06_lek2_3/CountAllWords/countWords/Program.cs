using System;
using System.Linq;

namespace СountAllWords
{
    class MyClass
    {
        static void Main(string[] args)
        {
           Console.WriteLine("Введите текст:");
           string str = Console.ReadLine();
           string[] newStrList = str.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
           Console.WriteLine("Количество слов в тексте:{0}", newStrList.Count());
           return;
        }
    }
}
