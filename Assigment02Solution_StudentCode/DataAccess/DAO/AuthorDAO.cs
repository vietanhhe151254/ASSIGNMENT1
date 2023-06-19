using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
using BusinessObjects;

namespace DataAccess.DAO
{
    public class AuthorDAO
    {
        public static List<Author> GetAuthors()
        {
            var authorList = new List<Author>();

            try
            {
                using (var context = new MyDbContext())
                {
                    authorList = context.Authors.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return authorList;
        }

        public static Author FindAuthorById(int id)
        {
            Author author = new Author();

            try
            {
                using (var context = new MyDbContext())
                {
                    author = context.Authors.SingleOrDefault(a => a.AuthorId==id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return author;
        }

        public static void SaveAuthor(Author author)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Authors.Add(author);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while saving the entity changes.", e);
            }

        }

        public static void UpdateAuthor(Author author)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry<Author>(author).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteAuthor(Author author)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var a = context.Authors.SingleOrDefault(a => a.AuthorId == author.AuthorId);
                    if (a != null)
                    {
                        context.Authors.Remove(a);
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
