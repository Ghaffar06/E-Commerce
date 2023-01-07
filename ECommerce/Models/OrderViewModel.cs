using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AppDbContext.Models
{
    public partial class OrderViewModel
    {
        public OrderViewModel()
        {
            OrderProduct = new HashSet<OrderProductViewModel>();
            OrderState = new HashSet<OrderStateViewModel>();
        }

        public long Id { get; set; }
        public long DeliveryId { get; set; }
        public long UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public long AddressId { get; set; }
        public decimal? Rate { get; set; }

        public virtual DeliveryViewModel Delivery { get; set; }
        public virtual ICollection<OrderProductViewModel> OrderProduct { get; set; }
        public virtual ICollection<OrderStateViewModel> OrderState { get; set; }
    }
}
