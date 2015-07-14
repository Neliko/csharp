using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace Data
{
    public class Card : IComparable, ICloneable, IXmlSerializable
    {
        public List<Contact> ContactsList { get; private set; }
        public string Name { get; private set; }
        public long SynCode { get; private set; }
        public long ProjectId { get; private set; }

        CardStatus cardStatus = CardStatus.NotSet;

        public Card()
        {
            Name = string.Empty;
            SynCode = 0;
            ProjectId = 0;
            ContactsList = new List<Contact>();
        }

        public Card(string name, long synCode, long id)
        {
            Name = name;
            SynCode = synCode;
            ProjectId = id;
            ContactsList = new List<Contact>();
        }

        public long GetProjectId
        {
            get { return ProjectId; }
        }


        public void SetName(string name)
        {
            if (name == string.Empty)
                throw new ArgumentException("Название проекта не может быть пустым!");
            Name = name;
        }

        public void SetSynCode(long synCode)
        {
            if (synCode == 0)
                throw new ArgumentException("У карточки должен быть SynCode");
            SynCode = synCode;
        }

        public void SetProjectId(long id)
        {
            if (id < 0)
                throw new ArgumentException("Id карточки не может быть отрицательным");
            ProjectId = id;
        }

        public string GetData()
        {
            var text = "Название проекта:" + Name
                          + "SynCode:" + SynCode
                          + "Идентификатор:" + GetProjectId;
            return text;
        }

        public void AddContact(Contact c)
        {
            ContactsList.Add(c);
        }

        public string Print()
        {
            string result = "";
            foreach (Contact contact in ContactsList)
                result = result + (contact.ToString() + "\n");
            return result;
        }

        public bool DelContact(String name)
        {
            var i = ContactsList.FindIndex(x => x.Name == name);
            if (i == -1)
                return false;

            ContactsList.RemoveAt(i);
            return true;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var otherCard = obj as Card;
            if (otherCard != null)
            {
                if (this.ProjectId != otherCard.ProjectId)
                    return this.ProjectId.CompareTo(otherCard.ProjectId);
                if (!this.Name.Equals(otherCard.Name))
                    return this.Name.CompareTo(otherCard.Name);
                return this.SynCode.CompareTo(otherCard.SynCode);
            }
            else
                throw new ArgumentException("Object is not a Card");
        }

        public object Clone()
        {
            var newCard = new Card();
            newCard.Name = (string)this.Name.Clone();
            newCard.ProjectId = this.ProjectId;
            newCard.SynCode = this.SynCode;
            foreach (var contact in ContactsList)
            {
                newCard.ContactsList.Add((Contact)contact.Clone());
            }
            return newCard;
        }

        public XElement ToXml()
        {
            if (this.Name == string.Empty)
                throw new ArgumentException("Вы пытаетесь вывести пустую Xml ");
            var card = new XElement("Card", new XAttribute("Id", ProjectId), new XAttribute("Name", Name), new XAttribute("SynCode", SynCode),
                new XAttribute("Status", (int)cardStatus));
            var contacts = new XElement("Contacts");
            card.Add(contacts);

            foreach (var contact in ContactsList)
            {
                contacts.Add(contact.ToXml());
            }
            return card;
        }
        //Загрузка поля 
        public void LoadCardStatusValue(string state)
        {
            Enum.TryParse(state, true, out cardStatus);
        }

        //возвращаем контакты
        public IEnumerable<Email> EmailContacts()
        {
            return ContactsList.OfType<Email>().Where(email => email.Alias.EndsWith(".рф"));
        }
        //возвращаем телефоны
        public IEnumerable<string> PhoneContacts()
        {
            return ContactsList.OfType<TelephoneContact>().OrderBy(x => x.TelephoneZone).Select(x => x.TelephoneZone);
        }
 
        public XDocument SaveToXml()
        {
            return new XDocument(this.ToXml());
        }

        public void LoadFromXml(XDocument doc )
        {
            if (doc.Root == null || doc.Root.Name != "Card")
                throw new ArgumentException("Данный Xml не является карточкой");
            this.Name = (string)doc.Root.Attribute("Name");
            this.ProjectId = (long)doc.Root.Attribute("Id");
            this.SynCode = (long)doc.Root.Attribute("SynCode");
            this.cardStatus = (CardStatus) (int)doc.Root.Attribute("Status");

            foreach (var element in doc.Root.Elements())
            {
                if (element.Name == "Contacts")
                {
                    foreach (var childElement in element.Elements())
                    {
                        if (childElement.Name != "TelephoneContact" && childElement.Name !="Email")
                             throw new Exception("Контакта данного типа нет в карточке");

                        object newContact = "";
                        if (childElement.Name == "TelephoneContact")
                            newContact = new TelephoneContact((string)childElement.Attribute("Name"),
                                (string)childElement.Attribute("Zone"));
                        else
                            newContact = new Email((string)childElement.Attribute("Name"),
                                (string)childElement.Attribute("Alias"));

                        ContactsList.Add(newContact as Contact);
                    }
                }
            }
        }
    }
}
