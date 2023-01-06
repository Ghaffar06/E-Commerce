using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AppDbContext.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderProduct = new HashSet<OrderProduct>();
            OrderState = new HashSet<OrderState>();
        }

        public long Id { get; set; }
        public long DeliveryId { get; set; }
        public long UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public long AddressId { get; set; }
        public decimal? Rate { get; set; }

        public virtual Delivery Delivery { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
        public virtual ICollection<OrderState> OrderState { get; set; }
    }
}
