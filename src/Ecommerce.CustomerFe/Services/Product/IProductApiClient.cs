using Ecommerce.ViewModels;

namespace Ecommerce.CustomerFe.Services.Product
{
    public interface IProductApiClient
    {
        Task<IList<ProductVm>> GetProducts(CancellationToken cancellationToken);
    }
}