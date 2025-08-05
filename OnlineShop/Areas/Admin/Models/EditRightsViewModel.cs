using System.Collections.Generic;

namespace OnlineShop.Areas.Admin.Models
{
    public class EditRightsViewModel
    {
        public string UserName { get; set; }
        public List<RoleViewModel> UserRoles { get; set; }
        public List <RoleViewModel> AllRoles { get; set; }
    }
}
