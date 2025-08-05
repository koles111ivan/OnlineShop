using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Напишите название роли")]
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            var role = (RoleViewModel)obj;
            return Name == role.Name;
        }
    }
}
