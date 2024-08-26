using Laboppgave1.Controllers;
using Laboppgave1.Models;
using Laboppgave1.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections;


namespace ProductUnitTest {
    [TestClass]
    public class ProductControllerTest {

        private IProductRepository _repository;
        [TestMethod]
        public void TestMethod1() {
        }
        [TestMethod]
        public void IndexReturnsNotNullResult() {
            var controller = new ProductController(_repository);
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result, "View Result is not null");
        }
        [TestMethod]
        public void IndexReturnsAllProducts(IProductRepository repository) {
            this._repository = repository;
            var controller = new ProductController(_repository);

            var result = controller.Index() as ViewResult;

            CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model, typeof(Product));

            Assert.IsNotNull(result, "View Result is not null");
            var products = result.ViewData.Model as List<Product>;
            Assert.AreEqual(5, products.Count, "Got wrong number fo products");
        }
    }
}