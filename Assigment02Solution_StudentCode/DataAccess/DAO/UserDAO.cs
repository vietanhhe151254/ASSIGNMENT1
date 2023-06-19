using BusinessObject.Models;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class UserDAO
    {
        public static List<User> GetUsers()
        {
            var userList = new List<User>();

            try
            {
                using (var context = new MyDbContext())
                {
                    userList = context.Users.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return userList;
        }

        public static User FindUserById(int id)
        {
            User user = new User();

            try
            {
                using (var context = new MyDbContext())
                {
                    user = context.Users.SingleOrDefault(u=> u.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

        public static void SaveUser(User user)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while saving the entity changes.", e);
            }

        }

        public static void UpdateUser(User user)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry<User>(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteUser(User user)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var u = context.Users.SingleOrDefault(u => u.Id == user.Id);
                    if (u != null)
                    {
                        context.Users.Remove(u);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

}
