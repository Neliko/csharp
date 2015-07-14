using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace regex
{
    class Program
    {

        private static void Main(string[] args)
        {
            var regExp = new Regex(@"\d+,\d+");
            const string str = "3,14 kdfjkfdgj 349489 4,3";
            Console.WriteLine(string.Format("Исходная строка : {0}", str));
            var match = regExp.Match(str);
            if (match.Success)
            {
                Console.WriteLine("Вещественное число : {0}", match.Groups[0]);
            }
            else
                Console.WriteLine("Error");


            const string str2 = "04 Mar 2013 , 3kfdjdkfvjdk i49 . 02 Jun 1999 nnnsfn 02 Jun 19992";

            Console.WriteLine(string.Format("\nИсходная строка : {0}", str2));
            var regExp2 =
                new Regex(
                    @"(0[1-9]|1[0-9]|2[0-9]|3[01]) (Sep|Oct|Nov|Dec|Jan|Feb|Mar|Apr|May|Jun|Jul|Aug) ([012][0-9]{3}\D)");

            var matches = regExp2.Matches(str2);
            Console.WriteLine("Даты :");
            foreach (Match item in matches)
            {
                Console.WriteLine(item.Value);
            }
            Console.ReadKey();
        }
    }
}
