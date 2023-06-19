using BusinessObject.Models;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private IPublisherRepository _publisherRepository;

        public PublishersController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Publisher> publishers = _publisherRepository.GetPublishers();
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };
            return Ok(JsonSerializer.Serialize(publishers, options));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var publisher = _publisherRepository.GetPublisherById(id);
            if (publisher == null)
                return NotFound();

            return Ok(publisher);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Publisher publisher)
        {
            _publisherRepository.SavePublisher(publisher);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Publisher publisher)
        {
            var existingPublisher = _publisherRepository.GetPublisherById(id);
            if (existingPublisher == null)
            {
                return NotFound();
            }

            _publisherRepository.UpdatePublisher(publisher);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var publisher = _publisherRepository.GetPublisherById(id);
            if (publisher == null)
                return NotFound();

            _publisherRepository.DeletePublisher(publisher);
            return NoContent();
        }
    }
}
