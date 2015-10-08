using HomeWork.Data.Model;

namespace HomeWork.UI.Model
{
    internal class OrderModel:IModel<Order>
    {
        public decimal Total { get; set; }
        public void SetValue(Order entity)
        {
            Total = entity.Quantity * entity.Price;
        }
    }
}
