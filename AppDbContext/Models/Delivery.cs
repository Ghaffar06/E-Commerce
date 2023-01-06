using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AppDbContext.Models
{
    public partial class Delivery
    {
        public Delivery()
        {
            Order = new HashSet<Order>();
        }

        public long Id { get; set; }
        public long SellerAssistantId { get; set; }
        public TimeSpan ExpectedTime { get; set; }
        public string Vehicle { get; set; }
        public string DeliveryPrice { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
