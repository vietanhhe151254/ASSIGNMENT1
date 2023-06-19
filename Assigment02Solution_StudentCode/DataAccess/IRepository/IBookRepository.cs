using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IBookRepository
    {
        void SaveBook(Book book);
        Book GetBookById(int id);
        void DeleteBook(Book book);
        List<Book> GetBooks();
        void UpdateBook(Book book);
    }
}
