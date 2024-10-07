using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Controllers;

[Route("/api/[controller]")]
public class ProductController : ControllerBase
{

    private readonly IProductServices ProductServices;

    public ProductController (IProductServices productServices)
    {
        ProductServices = productServices;
    }

    [HttpGet]
    public async Task<List<Product>> GetAll() => await ProductServices.GetAll();

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var product = await ProductServices.Get(id);
        if(product == null) { return NotFound($"no product found with id {id}"); }

        return Ok(product);
    }
    

}
