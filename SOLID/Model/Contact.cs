using System;

namespace HomeWork.Model
{
    internal class Contact : IEntity
    {
        private string _phoneCode;
        public long Id { get; set; }
        public virtual string Value { get; set; }

        public ContactType Type { get; set; }

        public string PhoneCode
        {
            get
            {
                if (Type != ContactType.Phone)
                    throw new NotSupportedException();
                return _phoneCode;
            }
            set
            {
                if (Type != ContactType.Phone)
                    throw new NotSupportedException();
                _phoneCode = value;
            }
        }

        public override string ToString()
        {
            switch (Type)
            {
                case ContactType.Phone:
                    return string.Format("Id={0}, Value={1}", Id, "(" + PhoneCode + ")" + Value);
                case ContactType.Email:
                    return string.Format("Id={0}, Value={1}", Id, Value);
            }
            return base.ToString();

        }
    }
}
