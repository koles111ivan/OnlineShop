using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class Role
    {
        [Required(ErrorMessage ="Напишите название роли")]
        public string Name { get; set; }
    }
}
