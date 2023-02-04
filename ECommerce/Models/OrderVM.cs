using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ECommerce.Models
{
    public partial class OrderVM
    {
        public OrderVM()
        {
            OrderProduct = new HashSet<OrderProductVM>();
            OrderState = new HashSet<OrderStateVM>();
        }

        public long Id { get; set; }
        public long DeliveryId { get; set; }
        public long UserId { get; set; }
        public double TotalPrice { get; set; }
        public string Address { get; set; }
        public decimal? Rate { get; set; }

        public virtual DeliveryVM Delivery { get; set; }
        public virtual ICollection<OrderProductVM> OrderProduct { get; set; }
        public virtual ICollection<OrderStateVM> OrderState { get; set; }
    }
}
