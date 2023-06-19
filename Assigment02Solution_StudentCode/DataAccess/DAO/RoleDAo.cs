using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
using BusinessObjects;


namespace DataAccess.DAO
{
    public class RoleDAO
    {
        public static List<Role> GetRoles()
        {
            var roleList = new List<Role>();

            try
            {
                using (var context = new MyDbContext())
                {
                    roleList = context.Roles.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return roleList;
        }

        public static Role FindRoleById(int id)
        {
            Role role = new Role();

            try
            {
                using (var context = new MyDbContext())
                {
                    role = context.Roles.SingleOrDefault(r => r.RoleId.Equals(id));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return role;
        }

        public static void SaveRole(Role role)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Roles.Add(role);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while saving the entity changes.", e);
            }
        }

        public static void UpdateRole(Role role)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry<Role>(role).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteRole(Role role)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var r = context.Roles.SingleOrDefault(r => r.RoleId == role.RoleId);
                    if (r != null)
                    {
                        context.Roles.Remove(r);
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
