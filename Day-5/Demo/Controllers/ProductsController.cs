using Microsoft.AspNetCore.Mvc;
using Demo.Models;
using Demo.Services;

namespace Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    // GET: api/products
    [HttpGet]
    public IActionResult Get()
    {
        var products = _service.GetAllProducts();
        return Ok(products);
    }

    // POST: api/products
    [HttpPost]
    public IActionResult Post(Product product)
    {
        try
        {
            _service.CreateProduct(product);
            return Ok(new { Message = "Product created successfully!" });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}
