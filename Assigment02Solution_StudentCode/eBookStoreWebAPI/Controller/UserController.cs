using BusinessObject.Models;
using DataAccess.Repository;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Linq;
using System.Text.Json;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ODataController
    {
        private IUserRepository _userRepository = new UserRepository();

        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> users = _userRepository.GetUsers();
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };
            return Ok(JsonSerializer.Serialize(users, options) );
        }

        [HttpGet("id")]
        public IActionResult GetbyId(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            _userRepository.SaveUser(user);
            return NoContent();

        }

        [HttpPut]
        public IActionResult Put(int key, [FromBody] User user)
        {
            var p = _userRepository.GetUserById(key);
            if (p == null)
            {
                return NotFound();
            }

            _userRepository.UpdateUser(p);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int key)
        {
            var user = _userRepository.GetUserById(key);
            if (user == null)
                return NotFound();

            _userRepository.DeleteUser(user);
            return NoContent();
        }
    }
}