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
            OrderStatus = new HashSet<OrderStatus>();
        }

        public int Id { get; set; }
        public string? DelivererId { get; set; }
        public string CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Address { get; set; }
        public decimal? Rate { get; set; }
        public DateTime CreatedAt { get; set; }



		public virtual User Customer { get; set; }
        public virtual User Deliverer { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
        public virtual ICollection<OrderStatus> OrderStatus { get; set; }
    }
}
