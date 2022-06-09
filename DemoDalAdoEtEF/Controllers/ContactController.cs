using Dal.Entities;
using Dal.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoDalAdoEtEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _repository;

        public ContactController(IContactRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<ContactController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Contact? contact = _repository.Get(id);

            return contact is null ? NotFound() : Ok(contact);
        }
    }
}
