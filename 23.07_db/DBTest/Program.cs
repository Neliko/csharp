using System;
using System.Linq;
using System.Xml.Linq;

namespace DBTest
{
    class Program
    {
        //переписываем данные из Xml в карточку
        public static Card NewCard(XDocument doc, TestDBEntities dbContext)
        {
            var newCard = new Card
            {
                Id = (long)doc.Root.Attribute("Id"),
                BranchId = (long)doc.Root.Attribute("BranchId"),
                Name = (string)doc.Root.Attribute("Name"),
                SynCode = (long)doc.Root.Attribute("SynCode"),
                StatusTypeId = (int)doc.Root.Attribute("Status")
            };

            foreach (var element in doc.Root.Elements())
            {
                if (element.Name == "Contacts")
                {
                    foreach (var childElement in element.Elements())
                    {
                        if (childElement.Name != "TelephoneContact" && childElement.Name != "Email")
                            throw new Exception("Контакта данного типа нет в карточке");

                        Contact newContact;
                        if (childElement.Name == "TelephoneContact")
                            newContact = new Contact
                            {
                                ContactTypeId = 1,
                                Value = (string)childElement.Attribute("Zone")
                            };
                        else
                            newContact = new Contact
                            {
                                ContactTypeId = 2,
                                Value = (string)childElement.Attribute("Alias")
                            };

                        newContact.Id = (long)childElement.Attribute("Id");
                        newCard.Contacts.Add(newContact);
                    }
                }
            }
            return newCard;
        }

        //обновление карточки
        public static void UpdateCard(Card card, TestDBEntities dbContext)
        {
            var cardInDb = dbContext.Cards.FirstOrDefault(c => c.Id == card.Id);

            //если данные карточки не изменены - не менять лишний раз

            if (cardInDb == null)
                throw new ArgumentException(string.Format("Карточка с id = {0} не найдена", card.Id));
            if (
                !(cardInDb.Id == card.Id && cardInDb.Name == card.Name && cardInDb.BranchId == card.BranchId &&
                  cardInDb.SynCode == card.SynCode && cardInDb.StatusTypeId == card.StatusTypeId))
            {
                cardInDb.Name = card.Name;
                cardInDb.BranchId = card.BranchId;
                cardInDb.StatusTypeId = card.StatusTypeId;
                cardInDb.SynCode = card.SynCode;
            }

            foreach (var contact in card.Contacts)
            {
                var contactInDb = cardInDb.Contacts.FirstOrDefault(cont => cont.Id == contact.Id);
                //если контакта нет - добавляем
                if (contactInDb == null)
                    cardInDb.Contacts.Add(contact);
                else //если контакт изменен - обновляем
                    if (!(contactInDb.Value == contact.Value && contactInDb.ContactTypeId == contact.ContactTypeId))
                    {
                        contactInDb.Value = contact.Value;
                        contactInDb.ContactTypeId = contact.ContactTypeId;
                    }
            }

            var contList = card.Contacts.Select(x => x.Id).ToList();
            var noContactIds = cardInDb.Contacts.Select(x => x.Id).Except(contList).ToList(); //Находим id, которые необходимо удалить

            //удаляем 
            foreach (var noContactId in noContactIds)
            {
                dbContext.Contacts.Remove(dbContext.Contacts.FirstOrDefault(c => c.Id == noContactId));
            }
        }

        public static void LoadFromXml(XDocument doc)
        {
            using (var dbContext = new TestDBEntities())
            {

                if (doc.Root == null || doc.Root.Name != "Card")
                    throw new ArgumentException("Данный Xml не является карточкой");

                var newCard = NewCard(doc, dbContext);

                if (dbContext.Cards.FirstOrDefault(c => c.Id == newCard.Id) == null)
                {
                    dbContext.Cards.Add(newCard);
                }
                else
                {
                    UpdateCard(newCard, dbContext);
                }
                dbContext.SaveChanges();
            }
        }

        public static void PtintCard()
        {
            using (var dbContext = new TestDBEntities())
            {

                foreach (var card in dbContext.Cards)
                {
                    Console.Write(string.Format("Card Id = {0}, Name = {1}, BranchId = {2}, SynCode = {3}, Status = {4}", card.Id, card.Name, card.BranchId, card.SynCode, card.StatusType.Name));
                    foreach (var contact in card.Contacts)
                    {
                        Console.Write(string.Format("\n\tContact Id = {0}, Type = {1}, Value = {2}", contact.Id, contact.ContactType.Name, contact.Value));
                    }
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            const string cardXml = "<Card Id=\"10\" Name=\"2333\" BranchId=\"1\" SynCode=\"23423\" Status=\"2\"> <Contacts> <Email Id=\"18\"  Alias=\"2342.рф\" />" +
                                      "<TelephoneContact Id =\"20\" Zone=\"(23222242.рф)\" /> </Contacts></Card>";
            /*  const string cardXml = "<Card Id=\"8\" Name=\"22\" BranchId=\"1\" SynCode=\"23423\" Status=\"1\"> <Contacts> <Email Id=\"18\"  Alias=\"2342.рф\" />" +
                                        "</Contacts></Card>";*/
            var xdoc = XDocument.Parse(cardXml);
            LoadFromXml(xdoc);
            PtintCard();
            Console.ReadKey();
        }
    }
}
