namespace HomeWork.Model
{
    class Email : Contact
    {
        public override string ToString()
        {
            return string.Format("Id={0}, Value={1}", Id, Value);
        }
    }
}
