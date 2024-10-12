using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Controllers;

[Route("/api/[controller]")]
public class ProductController : ControllerBase
{

    private readonly IProductServices _services;

    public ProductController (IProductServices productServices)
    {
        _services = productServices;
    }

    [HttpGet]
    public async Task<List<Product>> GetAll() => await _services.GetAll();

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var product = await _services.Get(id);
        if(product is null) {
            return NotFound($"no product found with id {id}");
        }

        return Ok(product);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var product = await _services.Get(id);
        if (product == null) { return NotFound($"no product found with id {id}"); }

        await _services.Delete(id);
        return Ok($"Product {product.ProductId} - {product.ProductName} deleted successfully.");
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductBindTarget target)
    {
        if(target == null)
        {
            return NotFound("Empty object cannot be created");
        }
        var product = target.ToProduct();
        await _services.Create(product);

        return CreatedAtAction(nameof(Get), new { id = product.ProductId }, product);
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Product product)
    {
        if (id != product.ProductId) { return BadRequest("Provided id does not match products id"); }


        await _services.Save(product);

        return Ok($"Product {product.ProductId} - {product.ProductName} updated successfully");
    }
}
