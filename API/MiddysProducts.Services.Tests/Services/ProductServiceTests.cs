using Microsoft.Extensions.DependencyInjection;
using MiddysProducts.Data.Models;
using MiddysProducts.Data.Repositories;
using MiddysProducts.Services.Mapping;
using MiddysProducts.Services.Models;
using Moq;

namespace MiddysProducts.Services.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly ProductService _service;
        private readonly Mock<IProductRepository> _mockRepo;

        public ProductServiceTests()
        {
            var services = new ServiceCollection();

            _mockRepo = new Mock<IProductRepository>();

            services.AddSingleton(_mockRepo.Object);
            services.AddAutoMapper(typeof(ProductProfile));
            services.AddTransient<ProductService, ProductService>();

            var provider = services.BuildServiceProvider();

            _service = provider.GetRequiredService<ProductService>();
        }

        [Fact]
        public async Task GetAllAsync_ReturnsProducts()
        {
            //  Arrange
            var mockProducts = new List<Product>
            {
                new Product { Id = 1, ProductName = "Test", Price = 10 },
                new Product { Id = 2, ProductName = "Test2", Price = 20 }
            };

            _mockRepo.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(mockProducts);

            //  Act
            var result = await _service.GetAllAsync();

            //  Assert
            Assert.Equal(2, result.Count());
            Assert.Equal(1, result.First().Id);
            Assert.Equal("Test", result.First().ProductName);
            Assert.Equal(10, result.First().Price);
            Assert.Equal(2, result.Last().Id);
            Assert.Equal("Test2", result.Last().ProductName);
            Assert.Equal(20, result.Last().Price);
        }

        [Fact]
        public async Task GetByIdAsync_ExistingId_ReturnsProduct()
        {
            // Arrange
            var product = new Product
            {
                Id = 7,
                ProductName = "Sample Product",
                Price = 19.99M
            };

            _mockRepo.Setup(r => r.GetByIdAsync(7, It.IsAny<CancellationToken>()))
                .ReturnsAsync(product);
            
            // Act
            var result = await _service.GetByIdAsync(7);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(7, result.Id);
            Assert.Equal("Sample Product", result.ProductName);
            Assert.Equal(19.99M, result.Price);
        }


        [Fact]
        public async Task CreateAsync_ValidProduct_ReturnsCreated()
        {
            //  Arrange
            var product = new CreateProductDto
            {
                ProductName = "New",
                Price = 9.99M
            };
            _mockRepo.Setup(r => r.AddAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Product
                {
                    Id = 10,
                    ProductName = product.ProductName,
                    Price = product.Price
                });

            //  Act
            var result = await _service.CreateAsync(product);

            //  Assert
            Assert.Equal(10, result.Id);
            Assert.Equal("New", result.ProductName);
            Assert.Equal(9.99M, result.Price);
        }

        [Fact]
        public async Task UpdateAsync_ExistingProduct_ReturnsTrue()
        {
            // Arrange
            var existingProduct = new Product
            {
                Id = 5,
                ProductName = "Old Name",
                Price = 5.99M
            };

            var updateDto = new UpdateProductDto
            {
                ProductName = "Updated Name",
                Price = 10.99M
            };

            _mockRepo.Setup(r => r.GetByIdAsync(5, It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingProduct);

            _mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _service.UpdateAsync(5, updateDto);

            // Assert
            Assert.True(result);
            Assert.Equal("Updated Name", existingProduct.ProductName);
            Assert.Equal(10.99M, existingProduct.Price);
        }

        [Fact]
        public async Task CreateAsync_InvalidProduct_ThrowsException()
        {
            var product = new CreateProductDto { ProductName = "", Price = -1 };

            await Assert.ThrowsAsync<ArgumentException>(() => _service.CreateAsync(product));
        }

        [Fact]
        public async Task DeleteAsync_ProductExists_ReturnsTrue()
        {
            var product = new Product { Id = 1, ProductName = "ToDelete", Price = 10 };

            _mockRepo.Setup(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(product);
            _mockRepo.Setup(r => r.DeleteAsync(1, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            var result = await _service.DeleteAsync(1);

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_ProductDoesNotExist_ReturnsFalse()
        {
            _mockRepo.Setup(r => r.GetByIdAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync((Product?)null);

            var result = await _service.DeleteAsync(1);

            Assert.False(result);
        }
    }
}
