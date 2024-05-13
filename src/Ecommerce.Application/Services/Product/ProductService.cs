using Ecommerce.Application.Common.Interfaces.Repositories;
using Ecommerce.Application.Common.Interfaces.Services;
using Ecommerce.Application.Services.Product.Dtos;

namespace Ecommerce.Application.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IProductRepository _productRepository;

        public ProductService(IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
            _productRepository = productRepository;
        }

        public async Task<ICollection<ProductDto>> GetListProduct(CancellationToken cancellationToken = default)
        {
            var products = await _productRepository.GetListAsync(cancellationToken: cancellationToken);
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                Creator = new ProductCreatorDto
                {
                    Id = p.User.Id,
                    Name = p.User.Name
                },
                CategoryDto = new CategoryDto
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name
                }
            }).ToList();
        }
    }
}