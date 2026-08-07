using Microsoft.AspNetCore.Mvc;
using GreetingApp.Models;

namespace GreetingApp.Controllers;

[Route("Home/[action]")]
[ApiController]
public class HomeController : ControllerBase
{
    [HttpPost]
    public IActionResult SaveName([FromBody] NameModel model)
    {
        if (model != null && !string.IsNullOrWhiteSpace(model.Name))
        {
            NameRepository.SaveName(model.Name);
            return Ok(new { success = true });
        }
        
        return BadRequest(new { success = false, message = "Name is required" });
    }

    [HttpGet]
    public IActionResult GetMessage()
    {
        var name = NameRepository.GetStoredName();
        if (string.IsNullOrEmpty(name))
        {
            return Ok(new { message = "" });
        }
        
        return Ok(new { message = $"Hello {name}!" });
    }

}
