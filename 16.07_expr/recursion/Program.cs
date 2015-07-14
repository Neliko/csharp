using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recursion
{
    class Program
    {
        public static int Fibonacci(int N)
        {
            if (N <= 2 )
                return 1;
            else return Fibonacci(N - 1) + Fibonacci(N - 2);
        }

        public static void DelDirectories(string path)
        {
            var files = Directory.EnumerateFiles(path);
            foreach (var file in files)
            {
                File.Delete(file);
            }

            var directories = Directory.EnumerateDirectories(path);
            foreach (var directory in directories)
            {
               DelDirectories(directory);
            }
            Directory.Delete(path);
        }
        static void Main(string[] args)
        {
            //Фибоначчи:
           /* while (true)
            {
            Console.WriteLine("Введите номер числа Фибоначчи");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(string.Format("Введенный номер : {0}\nЧисло : {1}",N,Fibonacci(N)));
            Console.ReadKey();
                
            }*/
            
            try
            {
                DelDirectories(@"F:\test");
                Console.WriteLine("Директория успешно удалена");
            }
            catch (Exception)
            {

                Console.WriteLine("Ошибка удаления директории");
            }
          
        }
    }
}
