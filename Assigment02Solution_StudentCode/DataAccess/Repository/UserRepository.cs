using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
using DataAccess.DAO;
using DataAccess.IRepository;

namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        public void SaveUser(User user)
        {
            UserDAO.SaveUser(user);
        }

        public User GetUserById(int id)
        {
            return UserDAO.FindUserById(id);
        }

        public void DeleteUser(User user)
        {
            UserDAO.DeleteUser(user);
        }

        public List<User> GetUsers()
        {
            return UserDAO.GetUsers();
        }

        public void UpdateUser(User user)
        {
            UserDAO.UpdateUser(user);
        }
    }
}
