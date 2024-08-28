using Laboppgave1.Controllers;
using Laboppgave1.Models;
using Laboppgave1.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections;

namespace ProductUnitTest {
    [TestClass]
    public class ProductControllerTest {

        private Mock<IProductRepository> _moqRepository;
        //private IProductRepository _repository;
        [TestMethod]
        public void TestMethod1() {
        }
        [TestMethod]
        public void IndexReturnsNotNullResult() {
            _moqRepository = new Mock<IProductRepository>();

            var controller = new ProductController(_moqRepository.Object);
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result, "View Result is not null");
        }

        [TestMethod]
        public void IndexReturnsAllProducts() {
            _moqRepository = new Mock<IProductRepository>();

            List<Product> fakeProducts = new() {
            new Product { Name = "Hammer", Price = 122.50m, Category="Verktøy" },
            new Product { Name = "Vinkelsliper", Price = 1530.00m, Category="Verktøy" },
            new Product { Name = "Melk", Price = 16.50m, Category="Dagligvarer" },
            new Product { Name = "Kjøttkaker", Price = 33.00m, Category="Dagligvarer" },
            new Product { Name = "Brød", Price = 22.50m, Category="Dagligvarer" },
            };

            _moqRepository.Setup(x => x.GetAll()).Returns(fakeProducts);

            var controller = new ProductController(_moqRepository.Object);
            var result = (ViewResult)controller.Index();

            CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model, typeof(Product));

            Assert.IsNotNull(result, "View Result is not null");
            var products = result.ViewData.Model as List<Product>;
            Assert.AreEqual(5, products.Count, "Got wrong number fo products");
        }

        [TestMethod]
        public void SaveIsCalledWhenProductISCreated() {
            _moqRepository = new Mock<IProductRepository>();
            _moqRepository.Setup(x => x.Save(It.IsAny<Product>()));

            var controller = new ProductController(_moqRepository.Object);


            var result = controller.Create(new Product());

            _moqRepository.VerifyAll();

        }
    }
}