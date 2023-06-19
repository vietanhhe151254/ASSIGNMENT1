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
    public class AuthorRepository: IAuthorRepository
    {
        public void SaveAuthor(Author author)
        {
            AuthorDAO.SaveAuthor(author);
        }

        public Author GetAuthorById(int id)
        {
            return AuthorDAO.FindAuthorById(id);
        }

        public void DeleteAuthor(Author author)
        {
            AuthorDAO.DeleteAuthor(author);
        }

        public List<Author> GetAuthors()
        {
            return AuthorDAO.GetAuthors();
        }

        public void UpdateAuthor(Author author)
        {
            AuthorDAO.UpdateAuthor(author);
        }
    }
}
