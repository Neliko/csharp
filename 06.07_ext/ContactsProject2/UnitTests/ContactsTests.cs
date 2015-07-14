using System;
using System.Xml.Linq;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass()]
    public class ContactsTests
    {
        [TestMethod()]
        public void InitialEmailWithoutParameters()
        {
            Contact contact = new Email();
            Assert.AreEqual(string.Empty, contact.Name, "Init Email : Название не пустое ");
            Assert.AreEqual(string.Empty, (contact as Email).Alias, "Init Email : Алиас не пуст");
        }

        [TestMethod()]
        public void InitialEmailWithParameters()
        {
            Contact contact = new Email("Tom", "tommie");
            Assert.AreEqual("Tom", contact.Name, "Init Email : Название не совпадает");
            Assert.AreEqual("tommie", (contact as Email).Alias, "Init Email : Алиас не совпадает");
        }

        [TestMethod()]
        public void InitialPhoneWithoutParameters()
        {
            Contact contact = new TelephoneContact();
            Assert.AreEqual(string.Empty, contact.Name, "Init Phone : Название не пустое");
            Assert.AreEqual(string.Empty, (contact as TelephoneContact).TelephoneZone, "Init Phone : Телефонная зона не пуста");
        }

        [TestMethod()]
        public void InitialPhoneWithParameters()
        {
            Contact contact = new TelephoneContact("Tora", "123");
            Assert.AreEqual("Tora", contact.Name, "Init Phone : Название не совпадает");
            Assert.AreEqual("123", (contact as TelephoneContact).TelephoneZone, "Init Phone : Телефонная зона не совпадает");
        }

        [TestMethod()]
        public void PhoneToStringWithParameters()
        {
            Contact contact = new TelephoneContact("Tora", "123");
            var txt = string.Format("Name: Tora \nCity code : 123");
            Assert.AreEqual(txt, contact.ToString(), "TelephoneContact ToString() : Ожидался другой результат");
        }
        [TestMethod()]
        public void PhoneToStringWithoutParameters()
        {
            Contact contact = new TelephoneContact();
            var txt = string.Format("Name:  \nCity code : ");
            Assert.AreEqual(txt, contact.ToString(), "TelephoneContact ToString() : Ожидалось отсутствие данных");
        }
        [TestMethod()]
        public void  EmailToStringWithParameters()
        {
            Contact contact = new Email("Tora", "~tora");
            var txt = string.Format("Name: Tora \nmailto : (~tora) ");
            Assert.AreEqual( txt,contact.ToString(), "Email ToString() : Ожидался другой результат");
        }
        [TestMethod()]
        public void EmailToStringWithoutParameters()
        {
            Contact contact = new Email();
            var txt = string.Format("Name:  \nmailto : () " );
            Assert.AreEqual( txt,contact.ToString(),  "Email ToString() : Ожидалось отсутствие данных");
        }

         [TestMethod()]
          public void EmailWithParametersToXml()
          {
            var contact = new Email("ContactName", "nam");
            var contactXml = new XElement("Email", new XAttribute("Name", "ContactName"),new XAttribute("Alias","nam"));
            Assert.AreEqual(contactXml.ToString(), contact.ToXml().ToString(), "ToXml() : Результаты не совпадают");
          }
     
         [TestMethod()]
         public void PhoneWithParametersToXml()
         {
             var contact = new TelephoneContact("Tora", "123");
             var contactXml = contact.ToXml().ToString();
             const string expected = "<TelephoneContact Name=\"Tora\" Zone=\"123\" />";
             Assert.AreEqual(expected, contactXml, "ToXml() : Xml отличаются");
         }

         [TestMethod()]
         [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
         public void EmailWithoutParametersToXml()
         {
             var contact = new Email();
             const string expected = "<Email Name=\"\" Alias=\"\" />";
             Assert.AreEqual(expected, contact.ToXml().ToString(), "ToXml() : Нет смысла выводить пустую строку");
         }
         [TestMethod()]
         [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
         public void PhoneWithoutParametersToXml()
         {
             var contact = new Email();
             const string expected = "<TelephoneContact Name=\"\" Zone=\"\" />";
             Assert.AreEqual(expected, contact.ToXml().ToString(), "ToXml() : Нет смысла выводить пустую строку");
         }
        [TestMethod()]
         public void ContactCloneObject()
         {
             var contact = new Email("Tora", "tora") as Contact;
             var newContact = (Contact)contact.Clone();
             Assert.AreNotSame(contact, newContact, "Contact Clone() : Данные ссылаются на один объект");
             Assert.AreEqual(contact.Name, newContact.Name, "Email Clone() : Названия не совпадают");
         }

        [TestMethod()]
        [ExpectedException(typeof(InvalidCastException))]
        public void ContactCloneEmailObjectAsPhone()
        {
            var contact = new Email("Tora", "tora");
            var newContact = (TelephoneContact)contact.Clone();
            Assert.AreNotSame(contact, newContact);
            Assert.AreEqual(contact.Name, newContact.Name,"Контакты не совпадают");
        }
           [TestMethod()]
         public void PhoneCloneObject()
         {
             var contact = new TelephoneContact("Name", "123");
             var newContact = (TelephoneContact)contact.Clone();
               Assert.AreNotSame(contact, newContact, "Email-Phone Clone() :  Данные ссылаются на один объект");
             Assert.AreEqual(contact.Name, newContact.Name, "Email-Phone Clone() : Название изменилось");
             Assert.AreEqual(contact.TelephoneZone, newContact.TelephoneZone, "Email-Phone Clone() : Алиас не скопировался в телефонную зону");
         }
          [TestMethod()]
           public void EmailCloneObject()
           {
               var contact = new Email("Tora", "tora");
               var newContact = (Email)contact.Clone();
               Assert.AreNotSame(contact, newContact, "Email Clone() : Данные ссылаются на один объект");
               Assert.AreEqual(contact.Name, newContact.Name, "Email Clone() : Название изменилось");
               Assert.AreEqual(contact.Alias, newContact.Alias, "Email Clone() : Алиас не был скопирован");
           }

        [TestMethod()]
        public void ContactCompareToEquals()
        {
            var contact = new TelephoneContact("Tora", "123");
            var contact2 = new TelephoneContact("Tora", "123");
            Assert.AreEqual(0, contact2.CompareTo(contact), "Contact CompareTo() : Контакты не равны");
        }
           
        [TestMethod()]
        public void ContactCompareToLess()
        {
            var contact = new TelephoneContact("Tora", "123");
            var  contact2 = new TelephoneContact("Tora", "12");
            Assert.AreEqual(-1, contact2.CompareTo(contact), "TelephoneContact CompareTo() : Неверное сожидаемое значение при сравнении");
        }

        [TestMethod()]
        public void ContactCompareToMore()
        {
            var contact = new Email("Tora", "~tora");
            var contact2 = new Email("Tora123", "123");
            Assert.AreEqual(1, contact2.CompareTo(contact), "Email CompareTo() : Неверное сожидаемое значение при сравнении");
        }

        [TestMethod()]
        public void ContactCompareToDifferentContacts()
        {
            var contact =  new Email("Tora", "~tora");
            var contact2 = new TelephoneContact("Tora", "123");
            Assert.AreEqual(0, (contact2 as Contact).CompareTo(contact as Contact), "Email-Phone  CompareTo():  Неверное сожидаемое значение при сравнении");
        }

        [TestMethod()]
        public void ContactCompareToEmpty()
        {
            var contact = new Email();
            var contact2 = new Email("Tora123", "123");
            Assert.AreEqual(1, contact2.CompareTo(contact), "Email  CompareTo() : Неверное сравнение с пустым контактом");
        }
    }
}
