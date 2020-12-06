using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToysStore.Web.Models.DomainModel
{
    public class Toy
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Введіть артикул")]
        [Range(1, 1000000, ErrorMessage = "Діапазон від 1 до 1 млн.")]
        public int Art { get; set; }

        [Required(ErrorMessage = "Ім'я повинно містити мінімум 2 символи."), MinLength(2), MaxLength(200)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Введіть кількість")]
        [Range(0, 10000, ErrorMessage = "Діапазон від 0 до 10 тис." )]
        public int Quantity { get; set; }

        [Range(0.0, 1000000.00, ErrorMessage = "Діапазон від 0 до 1 млн")]
        [Required(ErrorMessage = "Введіть ціну")]
        public decimal Price { get; set; }

        public string PicSrc { get; set; }
        
        public int CategoryId { get; set; }
        public ToyCategory Category{ get; set; }
    }

    public class ToyCategory
    {
        public ToyCategory()
        {
            this.Toys = new List<Toy>();
        }
        [Key]
        public int Id { get; set; }
        public string Categories { get; set; }
        
        public virtual ICollection<Toy> Toys { get; set; }

    }
}