using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AppDbContext.Models
{
    public partial class User  : IdentityUser
    {
        public User() {
            RequestedOrders = new HashSet<Order>();
            DeliveredOrders = new HashSet<Order>();
        }
        public string Role { get;set; }

        [InverseProperty("Customer")]
        public virtual ICollection<Order> RequestedOrders { get; set; }

        [InverseProperty("Deliverer")]
        public virtual ICollection<Order> DeliveredOrders { get; set; }
    }
}
