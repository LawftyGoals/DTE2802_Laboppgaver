using ProductAPI.Models;
using System.Runtime.CompilerServices;

namespace ProductAPI.Services;

public interface IProductServices
{
    Task<List<Product>> GetAll();
    Task<Product?> Get(int id);
    Task Delete(int id);
    Task Create(Product product);
    Task<Task> Save(Product product);
}
