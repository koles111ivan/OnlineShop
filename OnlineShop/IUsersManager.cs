using OnlineShop.Models;
using System.Collections.Generic;

namespace OnlineShop
{
    public interface IUsersManager
    {
        void Add(UserAccount user);
        List<UserAccount> GetAll();
        UserAccount TryGetByName(string name);
    }
}

