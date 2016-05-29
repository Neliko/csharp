using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data
{
    public class Card : IComparable, ICloneable
    {


        private List<Contact> _contactsList;
        private string _name;
        private long _synCode;
        private long _projectId;
        public Card()
        {
            _name = null;
            _synCode = 0;
            _projectId = 0;
            ContactsList = new List<Contact>();
        }

        public Card(string name, long synCode, long id)
        {
            _name = name;
            _synCode = synCode;
            _projectId = id;
            ContactsList = new List<Contact>();
        }

        public long GetProjectId
        {
            get { return _projectId; }
        }

        public List<Contact> ContactsList
        {
            get { return _contactsList; }
            set { _contactsList = value; }
        }

        public void SetName(string name)
        {
            if (name == string.Empty)
                throw new Exception("Название проекта не может быть пустым!");
            _name = name;
        }

        public void SetSynCode(long synCode)
        {
            if (synCode == 0)
                throw new Exception("У карточки должен быть SynCode");
            _synCode = synCode;
        }

        public void SetProjectId(long id)
        {
            if (id < 0)
                throw new Exception("Id карточки не может быть отрицательным");
            _projectId = id;
        }

        public string GetData()
        {
            var text = "Название проекта:" + _name
                          + "SynCode:" + _synCode
                          + "Идентификатор:" + GetProjectId;
            return text;
        }

        public void AddContact(Contact c)
        {
            ContactsList.Add(c);
        }

        public string Print()
        {
            return ContactsList.Aggregate("", (current, cont) => current + (cont.ToString() + "\n"));
        }

        public bool DelContact(String name)
        {
            int i = ContactsList.FindIndex(x => x.Name == name);
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
                if (this._projectId != otherCard._projectId)
                    return this._projectId.CompareTo(otherCard._projectId);
                if (!this._name.Equals(otherCard._name))
                    return this._name.CompareTo(otherCard._name);
                return this._synCode.CompareTo(otherCard._synCode);
            }
            else
                throw new ArgumentException("Object is not a Card");
        }

        public object Clone()
        {
            var newCard = new Card();
            newCard._name = (string)this._name.Clone();
            newCard._projectId = this._projectId;
            newCard._synCode = this._synCode;
            foreach (var contact in ContactsList)
            {
                newCard.ContactsList.Add((Contact)contact.Clone());
            }
            return newCard;
        }

        public XElement ToXml()
        {
            var card = new XElement("Card", new XAttribute("Id", _projectId), new XAttribute("Name", _name), new XAttribute("SynCode", _synCode));
            var contacts = new XElement("Contacts");
            card.Add(contacts);

            foreach (var contact in _contactsList)
            {
                contacts.Add(contact.ToXml());
            }
            return card;

        }
    }
}
