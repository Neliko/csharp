
namespace HomeWork.Data.Model
{
    public class Order : IEntity, IEntityOrderNumber, IEntityByUser
    {
        public long Id { get; set; }

        public int OrderNumber { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public long UserId { get; set; }
        //public TOrderModel[] GetModels<TOrderModel, TEntity>(TEntity[] entities) 
        //{
        //    var a = entities.OrderBy<Order,>();(OrderNumber).ToArray();
        //    ;
        //    return new;
        //}

        public OrderModel ConvertToModel<OrderModel>(Order entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
