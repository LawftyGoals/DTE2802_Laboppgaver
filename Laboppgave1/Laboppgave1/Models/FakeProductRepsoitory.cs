using Laboppgave1.Models.Entities;

namespace Laboppgave1.Models
{
    public class FakeProductRepsoitory : IProductRepository
    {

        readonly List<Product> products = new() {
            new Product { Name = "Hammer", Price = 121.50m, Category="Verktøy" },
            new Product { Name = "Vinkelsliper", Price = 1520.00m, Category="Verktøy" },
            new Product { Name = "Melk", Price = 14.50m, Category="Dagligvarer" },
            new Product { Name = "Kjøttkaker", Price = 32.00m, Category="Dagligvarer" },
            new Product { Name = "Brød", Price = 25.50m, Category="Dagligvarer" },
        };

        public IEnumerable<Product> GetAll() => products;

        public Task Save(Product product)
        {
            products.Add(product);
            return Task.CompletedTask;
        }


    }
}
