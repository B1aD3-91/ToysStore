using System.ComponentModel.DataAnnotations;

namespace ToysStore.Domain.Model.DomainModel
{
    public class Shipping
    {
        [Required(ErrorMessage = "Катюха це ти? А ні, обізнався.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "А це, щоб ми точно вас знайшли!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "А адреса? А гроші де лежать? А ключі дасте?")]
        public string AdressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public string AdressLine3 { get; set; }

        [Required(ErrorMessage = "Українське місто яке ви любите, чи в якому проживаете. Чи не любите?")]
        public string City { get; set; }

        [Required(ErrorMessage = "А телефончик? Не бійтесь, реклами не буде!")]
        public string Phone { get; set; }

        public string Delivery { get; set; }

        public string Comments { get; set; }

        public bool GiftWrap { get; set; }
    }
}