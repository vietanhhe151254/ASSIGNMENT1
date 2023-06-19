using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IUserRepository
    {
        void SaveUser(User user);
        User GetUserById(int id);
        void DeleteUser(User user);
        List<User> GetUsers();
        void UpdateUser(User user);
    }
}
