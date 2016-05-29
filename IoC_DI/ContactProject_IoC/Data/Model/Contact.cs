namespace Data.Model
{
    public abstract class Contact : IEntity
    {
        public long Id { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}\n", Id, Value);
        }
    }
}
