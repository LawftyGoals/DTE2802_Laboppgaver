namespace ProductAPI.Models
{
    public class ProductBindTarget
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }

        public Product ToProduct() => new Product
        {
            ProductName = this.Name,
            Price = this.Price
        };

    }
}
