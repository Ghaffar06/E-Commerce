using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AppDbContext.Models
{
    public partial class Category
    {
        public Category()
        {
            CategoryAttribute = new HashSet<CategoryAttribute>();
            CategoryProduct = new HashSet<CategoryProduct>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<CategoryAttribute> CategoryAttribute { get; set; }
        public virtual ICollection<CategoryProduct> CategoryProduct { get; set; }
    }
}
