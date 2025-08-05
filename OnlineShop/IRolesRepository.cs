using OnlineShop.Areas.Admin.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop
{
    public interface IRolesRepository
    {
        
        List<RoleViewModel> GetAll();
        RoleViewModel TryGetByName(string Name);
        void Add(RoleViewModel role);
        void Remove(string name);
    }
    public class RolesInMemoryRepository : IRolesRepository
    { 
        private readonly List<RoleViewModel> roles=new List<RoleViewModel>();
        public void Add(RoleViewModel role)
        {
            roles.Add(role);
        }
        public List<RoleViewModel> GetAll()
        {
            return roles;
        }
        public RoleViewModel TryGetByName(string name)
        {
            return roles.FirstOrDefault(x => x.Name == name);
        }
        public void Remove(string name)
        {
            roles.RemoveAll(x => x.Name == name);
        }
    
    }
}