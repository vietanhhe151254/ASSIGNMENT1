using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class BookDAO
    {
        public static List<Book> GetBooks()
        {
            var bookList = new List<Book>();

            try
            {
                using (var context = new MyDbContext())
                {
                    bookList = context.Books.Include(b => b.Publisher).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return bookList;
        }

        public static Book FindBookById(int id)
        {
            Book book = new Book();

            try
            {
                using (var context = new MyDbContext())
                {
                    book = context.Books.SingleOrDefault(b => b.BookId.Equals(id));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return book;
        }

        public static void SaveBook(Book book)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Books.Add(book);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while saving the entity changes.", e);
            }
        }

        public static void UpdateBook(Book book)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry<Book>(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteBook(Book book)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var b = context.Books.SingleOrDefault(b => b.BookId == book.BookId);
                    if (b != null)
                    {
                        context.Books.Remove(b);
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
