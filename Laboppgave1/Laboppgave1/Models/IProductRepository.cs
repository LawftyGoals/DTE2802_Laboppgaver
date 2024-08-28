using Laboppgave1.Models.Entities;

namespace Laboppgave1.Models {
    public interface IProductRepository {
        IEnumerable<Product> GetAll();

        Task Save(Product product);

    }
}
