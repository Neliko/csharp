using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeWork.Data.Model;
using HomeWork.UI.Model;

namespace HomeWork.UI.ModelConverter
{
    class OrderConverter
    {
        public static OrderModel ConvertEntityToModel(Order order)
        {
            return new OrderModel { Total = order.Quantity * order.Price };
        }
    }
}
