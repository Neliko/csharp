using System;
using System.Linq;

namespace СountAllWords
{
    class MyClass
    {
        static void Main(string[] args)
        {
           Console.WriteLine("Введите текст:");
           String str = Console.ReadLine();
           String[] newStrList = str.Split(' ');
           Console.WriteLine("Количество слов в тексте:{0}", newStrList.Count());
           return;
        }
    }
}
