using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage ="Введите валидный email")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Укажите пароль")]
        [StringLength(25, MinimumLength=4, ErrorMessage = "Пароль должен содержать от 4 до 25 символов")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
