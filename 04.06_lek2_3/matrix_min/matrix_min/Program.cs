using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix_min
{
    class Program
    {
        public static void printmatrix(int[][] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i][j] + " ");

                }
                Console.WriteLine();
            }
        }
        private static void Main(string[] args)
        {
            Random r = new Random();
            int n;
            Console.WriteLine("Введите число N для матрицы NxN");
            n = Convert.ToInt32(Console.ReadLine());
            int[][] matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
                for (int j = 0; j < n; j++)
                    matrix[i][j] = r.Next(100);
            }
            Console.WriteLine("Исходная матрица:");
            printmatrix(matrix,n);
            Console.WriteLine("");
            for (int i = 0; i < n; i++)
            {
            Console.WriteLine("Строка{0}:{1}",i+1,matrix[i].Min() );
             }

            return;
            
        }
    }
}
