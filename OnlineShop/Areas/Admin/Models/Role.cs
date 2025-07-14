using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Areas.Admin.Models
{
    public class Role
    {
        [Required(ErrorMessage ="Напишите название роли")]
        public string Name { get; set; }
    }
}
