namespace MiddysProducts.Services.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

    public class CreateProductDto : ProductDto
    {
    }

    public class UpdateProductDto : ProductDto
    {
    }
}
