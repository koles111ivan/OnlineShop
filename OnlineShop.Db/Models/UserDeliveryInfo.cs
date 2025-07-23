using System.ComponentModel.DataAnnotations;
namespace OnlineShop.Models
{
    public class UserDeliveryInfo
    {
        [Required(ErrorMessage = "Не заполнено ФИО")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не заполнен номер телефона")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Не заполнен адрес доставки")]
        public string Address { get; set; }
    }
}
