namespace HomeWork.Model
{
    public class Contact : IEntity
    {
        public long Id { get; set; }
        public virtual string Value { get; set; }
    }
}
