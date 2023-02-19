using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ECommerce.Models
{
    public partial class CategoryVM
    {
        public CategoryVM()
        {
            Attributes = new List<AttributeVM>();
            Products = new List<ProductVM>();
        }

        public long Id { get; set; }
        [StringLength(50, ErrorMessage = "Name length can't be more than 8.")]

        public string Name { get; set; }
        [StringLength(500, ErrorMessage = "Name length can't be more than 8.")]

        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public  IList<AttributeVM> Attributes { get; set; }
        public IList<ProductVM> Products { get; set; }
    }
}
