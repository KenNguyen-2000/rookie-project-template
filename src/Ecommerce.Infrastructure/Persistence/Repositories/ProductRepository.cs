using System.Linq.Expressions;
using Ecommerce.Application.Common.Interfaces.Repositories;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceDbContext _context;

        public ProductRepository(EcommerceDbContext context)
        {
            _context = context;
        }

        public void Add(Product entity, CancellationToken cancellationToken)
        {
            _context.Products.Add(entity);
        }

        public void Delete(Product entity, CancellationToken cancellationToken)
        {
           _context.Products.Remove(entity);
        }

       

        public async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(new object[] { id }, cancellationToken);
            if(product == null)
            {
                throw new Exception("Product not found");
            }

            return product;
        }

        public async Task<IEnumerable<Product>> GetListAsync(Expression<Func<Product, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            return predicate is null 
            ? await _context.Products.ToListAsync()  
            : await _context.Products.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId, CancellationToken cancellationToken)
        {
            return await _context.Products.Where(p => p.Id == categoryId).ToListAsync(cancellationToken);
        }

        public void Update(Product entity, CancellationToken cancellationToken)
        {
            _context.Products.Update(entity);
        }

      
    }
}