using OnlineShop.Models;
using System.Collections.Generic;

namespace OnlineShop
{
    public interface IUsersManager
    {
        void Add(UserAccount user);
        List<UserAccount> GetAll();
        UserAccount TryGetByName(string name);
        UserAccount TryGetById(int id);
        void ChangePassword(string userName, string newpassword);
        void ChangePasswordById(int userId, string password);
        void Remove(int id);
        void ChangeRole(int id, string role);
    }
}

