﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new[] {1, 2, 3};
            Console.WriteLine(arr.Print('/')) ;
            Console.ReadKey();
        }
    }
}
