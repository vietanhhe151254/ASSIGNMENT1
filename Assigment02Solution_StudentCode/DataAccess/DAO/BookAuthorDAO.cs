using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
using BusinessObjects;

namespace DataAccess.DAO
{
    public class BookAuthorDAO
    {
        public static List<BookAuthor> GetBookAuthors()
        {
            var listProducts = new List<BookAuthor>();

            try
            {
                using (var context = new MyDbContext())
                {
                    listProducts = context.BookAuthors.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listProducts;
        }
        public static void AddBookAuthor(BookAuthor bookAuthor)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.BookAuthors.Add(bookAuthor);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while saving the entity changes.", e);
            }
        }
        public static BookAuthor FindBookAuthorById(int bid,int aid)
        {
            BookAuthor product = new BookAuthor();

            try
            {
                using (var context = new MyDbContext())
                {
                    product = context.BookAuthors.SingleOrDefault(p => p.AuthorId==aid && p.BookId == bid);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return product;
        }
        public static void UpdateBookAuthor(BookAuthor bookAuthor)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry<BookAuthor>(bookAuthor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void RemoveBookAuthor(BookAuthor bookAuthor)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var ba = context.BookAuthors.SingleOrDefault(ba => ba.BookId == bookAuthor.BookId && ba.AuthorId == bookAuthor.AuthorId);
                    if (ba != null)
                    {
                        context.BookAuthors.Remove(ba);
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
