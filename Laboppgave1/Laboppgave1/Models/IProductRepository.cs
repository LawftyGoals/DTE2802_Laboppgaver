using Laboppgave1.Models.Entities;

namespace Laboppgave1.Models {
    public interface IProductRepository {
        IEnumerable<Product> GetAll();
        void Save(Product product) {

        }



    }
}
