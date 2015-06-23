using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace ContactsProject
{
    class Program
    {

        public static void WriteToFile(string path, List<Contact> contactList)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                foreach (var contact in contactList)
                {
                    sw.WriteLine(contact.ToString());
                }
            }

        }

        public static string ReadFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string text = sr.ReadToEnd();
                return text;
            }
            return null;
        }
        //Элемент меню - создание карточки
        public static Card NewCard()
        {
            Card card = new Card();
            Console.WriteLine("Введите id карточки");
            card.SetProjectId(Convert.ToInt64(Console.ReadLine()));
            Console.WriteLine("Введите название");
            card.SetName(Console.ReadLine());
            Console.WriteLine("Введите SynCode ");
            card.SetSynCode(Convert.ToInt64(Console.ReadLine()));
            return card;
        }
        //Элемент меню - создание контакта
        public static Contact NewContact()
        {
            string name = "";

            Console.WriteLine("Выберите тип контакта:\n1 - Телефонный контакт\n2 - Электронная почта");
            try
            {
                Contact contact = null;
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Введите имя контакта");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите код города");
                        string telephone = Console.ReadLine();
                        contact = new TelephoneContact(name, telephone);
                        return contact;

                    case 2:
                        Console.WriteLine("Введите имя контакта");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите alias");
                        string alias = Console.ReadLine();
                        contact = new Email(name, alias);
                        return contact;

                    default:
                        Console.WriteLine("\nТакой команды нет в списке\n");
                        break;
                }
            }

            catch (Exception)
            {
                Console.WriteLine("\nВы можете вводить только цифры из списка\n");
            }
            return null;
        }
        //поиск в списке номера карточки по Id
        public static int GetCardNumber(List<Card> cardList)
        {
            int cardNumber;
            long id;
            if (cardList.Count <= 0)
                throw new Exception("У Вас нет ни одной карточки");
            Console.WriteLine("Введите Id карточки для работы с ней");
            id = Convert.ToInt64(Console.ReadLine());
            cardNumber = cardList.FindIndex(i => i.GetProjectId == id);
            if (cardNumber == -1)
                throw new Exception("Карточки с таким Id не существует");
            return cardNumber;
        }

        static void Main(string[] args)
        {
            //работа с файлом
            string path = "c:\\temp\\file.txt";

            List<Contact> contactList = new List<Contact>();
            contactList = new List<Contact>();
            contactList.Add(new Email("cont1", "Contact"));
            contactList.Add(new TelephoneContact("cont2", "1234"));
            contactList.Add(new Email("cont3", "ccc"));
            WriteToFile(path, contactList);
            Console.WriteLine(ReadFromFile(path));

            List<Card> cardList = new List<Card>();
            long id = 0;
            var cardNumber = 0;

            //основное меню
            Card card = new Card();
            while (true)
            {
                Console.WriteLine(
                    "Выберите действие:\n0 - Создание новой карточки\n1 - Добавление контакта  карточку\n2 - Вывод списка контактов на экран\n3 - Удаление выбранного контакта\n4 - Вывод информации о карточки в Xml\n5 - Выход");
                try
                {

                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 0:
                            try
                            {
                                cardList.Add(NewCard());
                            }
                            catch (Exception e)
                            {

                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 1:
                            cardNumber = GetCardNumber(cardList);
                            cardList[cardNumber].AddContact(NewContact());
                            break;
                        case 2:
                            cardNumber = GetCardNumber(cardList);
                            Console.WriteLine(cardList[cardNumber].Print());
                            break;
                        case 3:
                            cardNumber = GetCardNumber(cardList);
                            Console.WriteLine("Введите контакт для удаления ");

                            if (cardList[cardNumber].DelContact(Console.ReadLine()) == false)
                                Console.WriteLine("Такого контакта нет в списке");
                            break;
                        case 4:
                            cardNumber = GetCardNumber(cardList);
                            Console.WriteLine(cardList[cardNumber].ToXml());
                            break;

                        case 5: return;
                        default:
                            Console.WriteLine("\nТакой команды нет в списке\n");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }
            Console.ReadKey();
        }

    }
}
