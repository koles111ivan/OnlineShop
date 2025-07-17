using OnlineShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop
{
    public class UsersManager : IUsersManager
    {
        private readonly List<UserAccount> users = new List<UserAccount>();
        private int nextId = 1;
        public List<UserAccount> GetAll()
        {
            return users;
        }

        public void Add(UserAccount user)
        {
            user.Id = nextId++;
            users.Add(user);
        }
        public UserAccount TryGetByName(string name)
        {
            return users.FirstOrDefault(x => x.Name == name);
        }
        public UserAccount TryGetById(int id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

        public void ChangePassword(string userName, string newpassword)
        {
            var account = TryGetByName(userName);
            account.Password = newpassword;
        }
        public void ChangePassword(int id, string newpassword)
        {
            var account = TryGetById(id);
            if (account != null)
            {
                account.Password = newpassword;
            }
        }

        public void ChangePasswordById(int userId, string password)
        {
            var account = TryGetById(userId);
            if (account != null)
            {
                account.Password = password;
            }
        }
        public void ChangeRole(int id, string role)
        {
            var user = TryGetById(id);
            if (user != null)
            {
                user.Role = role;
            }
        }
        public void Remove(int id)
        {
            var user = TryGetById(id);
            if (user != null)
            {
                users.Remove(user);
            }
        }
    }
}
