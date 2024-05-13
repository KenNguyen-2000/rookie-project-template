using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Services.Product.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class ProductCreatorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ProductCreatorDto Creator { get; set; } = null!;
        public CategoryDto CategoryDto { get; set; } = null!;
    }
}