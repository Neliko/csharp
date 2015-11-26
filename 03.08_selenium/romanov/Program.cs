using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace romanov
{
    
    static class Program
    {
        public static main main;
        public static Buy buy;
      
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
   
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            main = new main();
            buy = new Buy();
            Application.Run(main);
        }
    }
}
