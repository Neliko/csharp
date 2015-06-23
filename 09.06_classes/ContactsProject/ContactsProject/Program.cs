using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace ContactsProject
{
    class Program
    {
        static void Main(string[] args)
        {
             //создание
            Card card = new Card();
            string name;
            while (true)
            {
                Console.WriteLine(
                    "Выберите действие:\n1 - Добавление контакта  карточку\n2 - Вывод списка контактов на экран\n3 - Удаление выбранного контакта\n4 - Выход");
                try
                {
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            card.AddContact();
                            break;
                        case 2:
                            card.Print();
                            break;
                        case 3:
                            Console.WriteLine("Введите контакт для удаления ");
                            card.DelContact(Console.ReadLine());
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine("\nТакой команды нет в списке\n");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nВы можете вводить только цифры из списка\n");

                }
            }
            Console.ReadKey();
        }
        
    }
}
