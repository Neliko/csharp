using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Data
{
    public class Card : IComparable, ICloneable
    {
        public List<Contact> ContactsList { get; private set; }
        public string Name { get; private set; }
        public long SynCode { get; private set; }
        public long ProjectId { get; private set; }

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
            if(this.Name==string.Empty)
                throw new ArgumentException("Вы пытаетесь вывести пустую Xml ");
            var card = new XElement("Card", new XAttribute("Id", ProjectId), new XAttribute("Name", Name), new XAttribute("SynCode", SynCode));
            var contacts = new XElement("Contacts");
            card.Add(contacts);

            foreach (var contact in ContactsList)
            {
                contacts.Add(contact.ToXml());
            }
            return card;
        }

        public IEnumerable<string> EmailContacts()
        {
            var contacts =  ContactsList.OfType<Email>();
            return contacts.Select(x=> x.Alias);
        }

        public IEnumerable<string> PhoneContacts()
        {
            var contacts = ContactsList.OfType<TelephoneContact>();
            return  contacts.OrderBy(x => x).Select(x => x.TelephoneZone);
        }

    }
}
