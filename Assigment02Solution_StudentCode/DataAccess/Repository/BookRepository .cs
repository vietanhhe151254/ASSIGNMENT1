using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
using DataAccess.DAO;

namespace DataAccess.Repository
{
    public class BookRepository
    {
        public void SaveBook(Book book)
        {
            BookDAO.SaveBook(book);
        }

        public Book GetBookById(int id)
        {
            return BookDAO.FindBookById(id);
        }

        public void DeleteBook(Book book)
        {
            BookDAO.DeleteBook(book);
        }

        public List<Book> GetBooks()
        {
            return BookDAO.GetBooks();
        }

        public void UpdateBook(Book book)
        {
            BookDAO.UpdateBook(book);
        }
    }
}
