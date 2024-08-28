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
            Console.WriteLine(products.Count());

            return View(products);
        }

        // Create: GET
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("ProductId,Name,Description,Price,Category")] Product product) {
            try {
                if (!ModelState.IsValid) {
                    return View();
                }

                this.repository.Save(product);

                TempData["message"] = $"{product.Name} has been created.";

                return RedirectToAction("Index");
            }
            catch (Exception ex) {
                Console.Write(ex.ToString());

                TempData["message"] = $"{product.Name} failed to be created.";
                return RedirectToAction("Index");
            }
        }
    }
}
