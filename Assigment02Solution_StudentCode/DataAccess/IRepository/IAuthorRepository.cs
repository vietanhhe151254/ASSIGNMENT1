using System;
using System.Collections.Generic;
using BusinessObject.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IAuthorRepository
    {
    void SaveAuthor(Author author);
    Author GetAuthorById(int id);
    void DeleteAuthor(Author author);
    List<Author> GetAuthors();
    void UpdateAuthor(Author author);
    }
}
