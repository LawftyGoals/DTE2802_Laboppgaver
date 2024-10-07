using ProductAPI.Models;

namespace ProductAPI.Services;

public interface IProductServices
{
    Task<List<Product>> GetAll();
    Task<Product?> Get(int id);
}
