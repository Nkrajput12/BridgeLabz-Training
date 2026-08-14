using Microsoft.AspNetCore.Mvc;
using AddressBookWeb.Models;
using AddressBookWeb.Service.Services;

namespace AddressBookWeb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressBookController : ControllerBase
    {
        private readonly IAddressBookService _service;

        public AddressBookController(IAddressBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressBook>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressBook>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound($"AddressBook entry with ID {id} not found.");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<AddressBook>> Create([FromBody] AddressBook entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _service.AddAsync(entry);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AddressBook entry)
        {
            if (id != entry.Id)
            {
                return BadRequest("ID mismatch.");
            }

            var updated = await _service.UpdateAsync(entry);
            if (updated == null)
            {
                return NotFound($"AddressBook entry with ID {id} not found.");
            }

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success)
            {
                return NotFound($"AddressBook entry with ID {id} not found.");
            }

            return NoContent();
        }

        [HttpGet("search/state/{state}")]
        public async Task<ActionResult<IEnumerable<AddressBook>>> SearchByState(string state)
        {
            var result = await _service.SearchByStateAsync(state);
            return Ok(result);
        }

        [HttpGet("search/city/{city}")]
        public async Task<ActionResult<IEnumerable<AddressBook>>> SearchByCity(string city)
        {
            var result = await _service.SearchByCityAsync(city);
            return Ok(result);
        }
    }
}
