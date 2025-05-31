using Microsoft.EntityFrameworkCore;
using MiddysProducts.Data.Data;
using MiddysProducts.Data.Models;

namespace MiddysProducts.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _context.Products.ToListAsync(cancellationToken);

        public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
            => await _context.Products.FindAsync(id, cancellationToken);

        public async Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var product = await _context.Products.FindAsync(id, cancellationToken);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
