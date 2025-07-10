using OnlineShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop
{
    public interface IRolesRepository
    {
        
        List<Role> GetAll();
        Role TryGetByName(string Name);
        void Add(Role role);
        void Remove(string name);
    }
    public class RolesInMemoryRepository : IRolesRepository
    { 
        private readonly List<Role> roles=new List<Role>();
        public void Add(Role role)
        {
            roles.Add(role);
        }
        public List<Role> GetAll()
        {
            return roles;
        }
        public Role TryGetByName(string name)
        {
            return roles.FirstOrDefault(x => x.Name == name);
        }
        public void Remove(string name)
        {
            roles.RemoveAll(x => x.Name == name);
        }
    
    }
}