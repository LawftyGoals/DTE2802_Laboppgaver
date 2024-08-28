using System.ComponentModel.DataAnnotations;

namespace Laboppgave1.Models.Entities {
    public class Product {
        public int ProductId { get; set; }
        public string Name { get; set; } = "No Name";
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; } = "No Category";

    }
}
