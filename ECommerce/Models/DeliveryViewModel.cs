using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AppDbContext.Models
{
    public partial class DeliveryViewModel
    {
        public DeliveryViewModel()
        {
            Order = new HashSet<OrderViewModel>();
        }

        public long Id { get; set; }
        public long SellerAssistantId { get; set; }
        public TimeSpan ExpectedTime { get; set; }
        public string Vehicle { get; set; }
        public string DeliveryPrice { get; set; }

        public virtual ICollection<OrderViewModel> Order { get; set; }
    }
}
