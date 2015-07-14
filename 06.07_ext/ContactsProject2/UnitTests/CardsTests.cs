using System;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass()]
    public class CardsTests
    {
        private Card _card;

        [TestInitialize()]
        public void Init()
        {
            _card = new Card(); 
        }
        [TestMethod()]
        public void InitialCardWithoutParameters()
        {
            Assert.AreEqual(_card.Name, string.Empty, "Init : Строка не пуста");
            Assert.AreEqual(_card.ProjectId, 0, "Init : Id !=0");
            Assert.AreEqual(_card.SynCode, 0, "Init : SynCode !=0");
            Assert.IsNotNull(_card.ContactsList, "Init : Не инициализирован список контактов");
        }

        [TestMethod()]
        public void CardSetName()
        {
            _card.SetName("Name");
            Assert.AreEqual(_card.Name, "Name", "SetName : Имя карточки отличается от присваемого");
        }

        [TestMethod()]
        public void CardSetProjectId()
        {
            _card.SetProjectId(1);
            Assert.AreEqual(_card.ProjectId, 1, "SetProjectId : Id отличается от присваемого");
        }

        [TestMethod()]
        public void CardSetSynCode()
        {
            _card.SetSynCode(123);
            Assert.AreEqual(_card.SynCode, 123, "SetSynCode : SynCode отличается от устанавливаемого");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CardSetSynCodeError()
        {
            _card.SetSynCode(0);
            Assert.AreEqual(_card.SynCode, 0, "SetSynCode : Ошибочная ситуация");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CardSetProjectIdError()
        {
            _card.SetProjectId(-23);
            Assert.AreEqual(_card.ProjectId, -23, "ProjectId : Ошибочная ситуация");
        }

         [TestMethod()]
         [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void CardSetNameError()
          {
              _card.SetName("");
              Assert.AreEqual(_card.Name, "", "SetName : Ошибочная ситуация");
          }

        [TestMethod()]
         public void CardSetNameChange()
         {
             _card=new Card("Name",1,1);
             _card.SetName("NewName");
             Assert.AreEqual(_card.Name, "NewName", "SetName : Название не совпадает с устанавливаемым");
         }

           [TestMethod()]
         public void CardGetData()
         {
             var card = new Card("Name", 1,123);
             var text = "Название проекта:Name"
                        + "SynCode:1"
                        + "Идентификатор:123";
             Assert.AreEqual(card.GetData(), text, "GetData : Ожидалась дргая строка для вывода");
         }
          [TestMethod()]
           public void CardAddContact()
           {
            var contact= new Email("1","2");
            _card.ContactsList.Add(contact);
            Assert.AreEqual(1, _card.ContactsList.Count, "Add : Количество контактов не увеличилось");
            Assert.AreEqual(_card.ContactsList[0], contact, "Add : Контакты не совпадают");
           }

          [TestMethod()]
          public void CardPrintDifferentCard()
          {
              _card.ContactsList.Add(new Email("1", "2"));
              _card.ContactsList.Add(new TelephoneContact("2","123"));
              string text = string.Empty;
              foreach (var contact in _card.ContactsList)
                text += (contact.ToString() + "\n");
              Assert.AreEqual(_card.Print(), text, "Print : Ожидалась другая строка");
              }

        [TestMethod()]
        public void CardPrintEmptyCard()
        {
            Assert.AreEqual(_card.Print(), "", "Print : Возвращаемая строка не пуста");
        }

          [TestMethod()]
          public void CardDelContact()
          {
              _card.ContactsList.Add(new Email("1", "2"));
              Assert.AreEqual(1, _card.ContactsList.Count, "Add : Количество контактов не увеличилось");
              _card.DelContact("1");
              Assert.AreEqual(0, _card.ContactsList.Count, "DelContact : Удаление не произошло");
          }
           [TestMethod()]
          public void CardDelNotExistContact()
          {
              _card.ContactsList.Add(new Email("1", "2"));
              Assert.AreEqual(1, _card.ContactsList.Count, "Add : Количество контактов не увеличилось");
              _card.DelContact("123213");
              Assert.AreEqual(1, _card.ContactsList.Count, "DelContact : Контакт был удален");
          }

          [TestMethod()]
        //если контакты с одинаковым именем - удаляем первый
           public void CardDelContactSameName()
           {
               _card.ContactsList.Add(new Email("1", "2"));
               _card.ContactsList.Add(new TelephoneContact("1", "123"));
               Assert.AreEqual(2, _card.ContactsList.Count);
               _card.DelContact("1");
               Assert.AreEqual(1, _card.ContactsList.Count);
           }
        
       [TestMethod()]
           public void CardCloneData()
        {
            _card = new Card("23", 23423, 1);
            _card.AddContact(new Email("123", "2342"));
           var card2 = (Card)_card.Clone();
           Assert.AreNotSame(_card, card2, "Clone : Карточки ссылаются на один объект");
           Assert.AreEqual(_card.ContactsList[0].Name, card2.ContactsList[0].Name, "Clone : Названия отличаются");
        }

       [TestMethod()]
        public void CardCloneAndChangeData()
        {
            _card = new Card("23", 23423, 1);
            _card.AddContact(new Email("123", "2342"));
            var card2 = (Card)_card.Clone();
            Assert.AreNotSame(_card, card2);
            Assert.AreEqual(_card.ContactsList[0].Name, card2.ContactsList[0].Name);
            _card.ContactsList[0].Name = "2345";
            Assert.AreNotEqual(_card.ContactsList[0].Name, card2.ContactsList[0].Name);
        }

       [TestMethod()]
        public void CardCloneAndAddContact()
        {
            _card = new Card("23", 23423, 1);
            _card.AddContact(new Email("123", "2342"));
            var card2 = (Card)_card.Clone();
            Assert.AreNotSame(_card, card2);
            Assert.AreEqual(_card.ContactsList[0].Name, card2.ContactsList[0].Name);
            card2.ContactsList.Add(new TelephoneContact());
            Assert.AreNotEqual(_card.ContactsList.Count, card2.ContactsList.Count);
        }
       [TestMethod()]
       public void CardCompareToEquals()
       {
           _card = new Card("23", 23423, 1);
           var card2 = new Card("23", 23423, 1);
           Assert.AreEqual(0, card2.CompareTo(_card));
       }

       [TestMethod()]
       public void CardCompareToMore()
       {
           _card = new Card("23", 23423, 1);
           var card2 = new Card("23", 23423123, 2);
           Assert.AreEqual(1, card2.CompareTo(_card));
       }

       [TestMethod()]
       public void CardCompareToLess()
       {
           _card = new Card("23", 23423, 1);
           var card2 = new Card("23", 23423, 0);
           Assert.AreEqual(-1, card2.CompareTo(_card));
       }

       [TestMethod()]
       public void CardCompareToNotEqual()
       {
           _card = new Card("23", 23423, 1);
           var card2 = new Card("23", 23423, 1);
           card2.ContactsList.Add(new Email("Name","~name"));
           Assert.AreNotEqual(_card,card2);
       }

       [TestMethod()]
        public void CardToXml()
        {
            _card = new Card("1",1,3);
            _card.AddContact(new Email("Name","~name"));

            var txt = "<Card Id=\"3\" Name=\"1\" SynCode=\"1\">\r\n  <Contacts>\r\n    <Email Name=\"Name\" Alias=\"~name\" />\r\n  </Contacts>\r\n</Card>";
            var txt2 = _card.ToXml().ToString();
            Assert.AreEqual(txt,txt2,"");
        }

       [TestMethod()]
       [ExpectedException(typeof(ArgumentException))]
        public void CardToXmlEmpty()
        {
            var txt = _card.ToXml();
        }


    }
}
