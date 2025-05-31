using AutoMapper;
using MiddysProducts.Data.Models;
using MiddysProducts.Data.Repositories;
using MiddysProducts.Services.Models;

namespace MiddysProducts.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var items = await _repository.GetAllAsync(cancellationToken);
            return items.Select(x => _mapper.Map<ProductDto>(x));
        }

        public async Task<ProductDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _repository.GetByIdAsync(id, cancellationToken);
            return _mapper.Map<ProductDto>(result);
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto product, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(product.ProductName) || product.Price <= 0)
            {
                throw new ArgumentException("Invalid product data");
            }

            var result = await _repository.AddAsync(_mapper.Map<Product>(product), cancellationToken);

            return _mapper.Map<ProductDto>(result);
        }

        public async Task<bool> UpdateAsync(int id, UpdateProductDto product, CancellationToken cancellationToken = default)
        {
            var existing = await _repository.GetByIdAsync(id, cancellationToken);
            if (existing == null)
            {
                return false;
            }

            existing.ProductName = product.ProductName;
            existing.Price = product.Price;
            await _repository.UpdateAsync(existing, cancellationToken);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var existing = await _repository.GetByIdAsync(id, cancellationToken);
            if (existing == null) return false;

            await _repository.DeleteAsync(id, cancellationToken);
            return true;
        }
    }
}
