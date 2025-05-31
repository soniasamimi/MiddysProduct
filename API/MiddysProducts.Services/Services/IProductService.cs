using MiddysProducts.Data.Models;
using MiddysProducts.Services.Models;

namespace MiddysProducts.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<ProductDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<ProductDto> CreateAsync(CreateProductDto product, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(int id, UpdateProductDto product, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
