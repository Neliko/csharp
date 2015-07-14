using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension
{
   public static class ArrayExtensions
    {
       public static string Print(this int[] array, char separator)
       {
           string newString=string.Empty;
           foreach (var i in array)
           {
               newString += i;
               if (i != array.Count())
                   newString += separator;
           }
           return newString;
       }

    }
}
