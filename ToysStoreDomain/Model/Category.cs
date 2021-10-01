using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToysStore.Domain.Model
{
    public class Category
    {
        public Category()
        {
            this.Product = new List<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "Категорія")]
        public string Name { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
