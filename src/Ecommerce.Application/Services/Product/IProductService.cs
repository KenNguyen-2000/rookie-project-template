using Ecommerce.Application.Services.Product.Dtos;

namespace Ecommerce.Application.Services.Product
{
    public interface IProductService
    {
        Task<ICollection<ProductDto>> GetListProduct(CancellationToken cancellationToken = default);
    }
}