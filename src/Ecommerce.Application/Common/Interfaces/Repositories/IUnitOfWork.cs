namespace Ecommerce.Application.Common.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken  = default);
    }
}