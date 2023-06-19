using BusinessObject.Models;
using DataAccess.DAO;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BookAuthorRepository : IBookAuthorRepository
    {
      

        public void SaveBookAuthor(BookAuthor bookAuthor)
        {
            BookAuthorDAO.AddBookAuthor(bookAuthor);
        }

        public BookAuthor GetBookAuthorById(int bid,int aid)
        {
            return BookAuthorDAO.FindBookAuthorById(bid,aid);
        }

        public void DeleteBookAuthor(BookAuthor bookAuthor)
        {
            BookAuthorDAO.RemoveBookAuthor(bookAuthor);
        }

        public List<BookAuthor> GetAllBookAuthors()
        {
            return BookAuthorDAO.GetBookAuthors();
        }

        public void UpdateBookAuthor(BookAuthor bookAuthor)
        {
            BookAuthorDAO.UpdateBookAuthor(bookAuthor);
        }

        
    }
}
