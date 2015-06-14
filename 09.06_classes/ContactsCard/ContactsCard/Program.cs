using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsCard
{
    class Card
    { private List<Contact> _contactsList;

        public Card()
    {
        _contactsList = new List<Contact>();
        
        }
        public void AddContact()
        {
            Contact c=null;
            string name;
            Console.WriteLine("Выберите тип контакта:\n1 - Телефонный контакт\n2 - Электронная почта");
            try
            {
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Введите имя контакта");
                    name = Console.ReadLine();
                    Console.WriteLine("Введите код города");
                    string telephone = Console.ReadLine();
                    c = new TelephoneContact(name, telephone); break;

                case 2: 
                    Console.WriteLine("Введите имя контакта");
                    name = Console.ReadLine();
                    Console.WriteLine("Введите alias");
                    string alias = Console.ReadLine();
                    c = new Email(name, alias); break;

                default: Console.WriteLine("\nТакой команды нет в списке\n"); return;    
            }
            _contactsList.Add(c);
            }
            catch (Exception)
            {
                Console.WriteLine("\nВы можете вводить только цифры из списка\n");
            }
        }

        public void Print()
        {
            foreach (var cont in _contactsList)
            {
                Console.WriteLine( cont.ToString());
            }
            Console.WriteLine();
        }

        public void DelContact(String name)
        {
            //P.S. Думала,как сделать покороче. В итоге - первый опыт работы с предикатом =)
            int i = _contactsList.FindIndex(x => x.Name == name);

            //можно сделать и так:
            /* int i = 0;
            foreach (Contact contact in _contactsList)
            {
                if(contact.Name==name)
                    break;
                i++;
            }*/
            if (i == -1)
            {
                Console.WriteLine("Такого контакта нет в списке");
                return;
            }
        _contactsList.RemoveAt(i);
        }

        static void Main(string[] args)
        {
            //создание
            Card card=new Card();
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
