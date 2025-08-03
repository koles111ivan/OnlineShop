using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Не указан email")]
        [EmailAddress(ErrorMessage ="Введите валидный email")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Укажите пароль")]
        [StringLength(25, MinimumLength = 4, ErrorMessage ="Пароль должен содержать от 4 до 25 символов")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
