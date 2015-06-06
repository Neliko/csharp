using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z2
{
    class Program
    {

        static int kol_bit = 64;

        static void Main(string[] args)
        {
            int id;
            int city;
            int table;
            int text;
            int i = 0;
            String var_string = "";
            long num = 1267165676175383; //число
            String num_txt = Convert.ToString(num, 2).PadLeft(64,'0'); //двоичное представление

            var_string = num_txt.Substring(0, 2);
            id = Convert.ToInt32(var_string, 2);
            var_string = num_txt.Substring(2, 15);
            city = Convert.ToInt32(var_string, 2);
            var_string = num_txt.Substring(17, 15);
            table = Convert.ToInt32(var_string, 2);
            var_string = num_txt.Substring(32, 32);
            text = Convert.ToInt32(var_string, 2);


            Console.WriteLine("id типа: " + id + "\nid города: " + city + "\nid таблицы: " + table + "\nid объекта: " + text);
            Console.ReadKey();


        }
    }
}
