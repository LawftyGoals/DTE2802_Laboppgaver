using Laboppgave1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboppgave1.Controllers {
    public class ProductController : Controller {

        private IProductRepository repository;

        public ProductController(IProductRepository repository) {
            this.repository = repository;
        }
        public IActionResult Index() {

            var products = this.repository.GetAll();

            return View(products);
        }
    }
}
