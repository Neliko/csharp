//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DbDemo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public Order()
        {
            this.OrderProducts = new HashSet<OrderProduct>();
        }
    
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
