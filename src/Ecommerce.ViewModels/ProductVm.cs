namespace Ecommerce.ViewModels
{
    public class CategoryVmDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class ProductVmCreatorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
    public class ProductVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ProductVmCreatorDto Creator { get; set; } = null!;
        public CategoryVmDto CategoryDto { get; set; } = null!;
    }
}