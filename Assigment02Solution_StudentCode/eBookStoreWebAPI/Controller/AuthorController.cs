using BusinessObject.Models;
using DataAccess.Repository;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Collections.Generic;
using System.Text.Json;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorsController : ODataController
    {
        private IAuthorRepository _authorRepository = new AuthorRepository();

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Author> authors = _authorRepository.GetAuthors();
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };
            return Ok(JsonSerializer.Serialize(authors, options));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Author author)
        {
            _authorRepository.SaveAuthor(author);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Author author)
        {
            var existingAuthor = _authorRepository.GetAuthorById(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }

            _authorRepository.UpdateAuthor(author);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author == null)
                return NotFound();

            _authorRepository.DeleteAuthor(author);
            return NoContent();
        }
    }
}
