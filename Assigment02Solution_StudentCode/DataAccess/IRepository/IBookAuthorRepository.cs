using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IBookAuthorRepository
    {
        BookAuthor GetBookAuthorById(int bid,int aid);
        void SaveBookAuthor(BookAuthor bookAuthor);
        void DeleteBookAuthor(BookAuthor bookAuthor);
        List<BookAuthor> GetAllBookAuthors();
        void UpdateBookAuthor(BookAuthor bookAuthor);
    }
}
