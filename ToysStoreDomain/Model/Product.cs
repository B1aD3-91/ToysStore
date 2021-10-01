using System.ComponentModel.DataAnnotations;
using ToysStore.Domain.Model;

namespace ToysStore.Domain.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Введіть артикул")]
        [Range(1, 1000000, ErrorMessage = "Діапазон від 1 до 1 млн.")]
        [Display(Name = "Артикул")]
        public int Art { get; set; }

        [Display(Name = "Назва")]
        [Required(ErrorMessage = "Ім'я повинно містити мінімум 2 символи."), MinLength(2), MaxLength(200)]
        public string Name { get; set; }

        [Display(Name = "Кількість")]
        [Required(ErrorMessage = "Введіть кількість")]
        [Range(0, 10000, ErrorMessage = "Діапазон від 0 до 10 тис." )]
        public int Quantity { get; set; }

        [Display(Name = "Ціна")]
        [Range(0.0, 1000000.00, ErrorMessage = "Діапазон від 0 до 1 млн")]
        [Required(ErrorMessage = "Введіть ціну")]
        public decimal Price { get; set; }

        [Display(Name = "Зображення")]
        public string PicturePath { get; set; }
 
        public int CategoryId { get; set; }

        public Category Category{ get; set; }
    }
}