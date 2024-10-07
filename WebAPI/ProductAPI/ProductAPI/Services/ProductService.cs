using ProductAPI.Models;
using ProductAPI.Services;
namespace ProductAPI.Services;

public class ProductService : IProductServices
{
    private static List<Product> Products { get; }
   static ProductService()
    {
        Products = new List<Product>
        {
            new Product {ProductId = 1, ProductName = " Hammer", Price = 76.0m},
            new Product {ProductId = 2, ProductName = " Water Bottle", Price = 30.0m},
            new Product {ProductId = 3, ProductName = " Keyboard", Price = 1299.90m},
        };
    }
    public async Task<List<Product>> GetAll() => await Task.FromResult(Products);
    public async Task<Product?> Get(int id) => await Task.FromResult(Products.FirstOrDefault(product => product.ProductId == id));
}
