
namespace HomeWork.Data.Model
{
    public class Order : IEntity, IEntityOrderNumber, IEntityByUser
    {
        public long Id { get; set; }

        public int OrderNumber { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public long UserId { get; set; }

    }
}
