using Laboppgave1.Models;
using Laboppgave1.Models.Entities;
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

        public ActionResult Create(Product p) {
            return p;
        }
    }
}
