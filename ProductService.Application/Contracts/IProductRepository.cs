using ProductService.Domain;

namespace ProductService.Application.Contracts;

public interface IProductRepository : IGenericRepository<Product>
{
    public Task<List<Product>> GetByCategory(Guid categoryId);
}
