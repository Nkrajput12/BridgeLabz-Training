using EntityContactApp.Models;
using EntityContactApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EntityContactApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactService _service;

    public ContactsController(IContactService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var contacts = await _service.GetAllContactsAsync();
        return Ok(contacts);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var contact = await _service.GetContactAsync(id);

        if (contact is null)
            return NotFound(new { message = $"Contact with Id {id} not found." });

        return Ok(contact);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Contact contact)
    {
        var created = await _service.CreateContactAsync(contact);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Contact contact)
    {
        bool updated = await _service.UpdateContactAsync(id, contact);

        if (!updated)
            return NotFound(new { message = $"Contact with Id {id} not found." });

        return Ok(new { message = "Contact updated successfully." });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool deleted = await _service.DeleteContactAsync(id);

        if (!deleted)
            return NotFound(new { message = $"Contact with Id {id} not found." });

        return Ok(new { message = "Contact deleted successfully." });
    }
}
