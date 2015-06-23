using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix_random
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
        static void Main(string[] args)
        {
            Random r=new Random();
            int n;
            Console.WriteLine("Введите число N для матрицы NxN");
            n= Convert.ToInt32( Console.ReadLine());
            int[][] matrix1 = new int[n][];
            int[][] matrix2 = new int[n][];
            int[,] matrix_res=new int[n,n];
            //наполнение
            for(int i=0;i<n;i++)
            { 
                matrix1[i]=new int[n];
                matrix2[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    matrix1[i][j] = r.Next(100);
                    matrix2[i][j] = r.Next(100);
                }
            }

            Console.WriteLine("Матрица №1:");
            printmatrix(matrix1,n);
            Console.WriteLine("\nМатрица №2:");
            printmatrix(matrix2,n);


            //сложение
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix_res[i, j] = matrix1[i][j] + matrix2[i][j];
                }
            }

            Console.WriteLine("\nРезультат:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix_res[i, j]+" ");

                }
                Console.WriteLine();
            }

        }
    }
}
