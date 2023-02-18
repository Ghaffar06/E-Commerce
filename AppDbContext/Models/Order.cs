using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ECommerceDbContext.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderProduct = new HashSet<OrderProduct>();
            OrderState = new HashSet<OrderState>();
        }

        public int Id { get; set; }
        public int? DeliveryId { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Address { get; set; }
        public decimal? Rate { get; set; }

        public virtual Delivery Delivery { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
        public virtual ICollection<OrderState> OrderState { get; set; }
    }
}
