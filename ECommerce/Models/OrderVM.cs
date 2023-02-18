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
            OrderProduct = new List<OrderProductVM>();
            OrderState = new List<OrderStateVM>();
        }

        public long Id { get; set; }
        public long DeliveryId { get; set; }
        public long UserId { get; set; }
        public double TotalPrice { get; set; }
        public string Address { get; set; }
        public decimal? Rate { get; set; }

        public virtual DeliveryVM Delivery { get; set; }
        public virtual IList<OrderProductVM> OrderProduct { get; set; }
        public virtual IList<OrderStateVM> OrderState { get; set; }
    }
}
