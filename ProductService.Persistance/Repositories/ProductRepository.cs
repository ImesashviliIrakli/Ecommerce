using Microsoft.EntityFrameworkCore;
using ProductService.Application.Contracts;
using ProductService.Domain;
using ProductService.Persistance.Data;

namespace ProductService.Persistance.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _context;
    private readonly DbSet<Product> _productSet;

    public ProductRepository(ProductDbContext context)
    {
        _context = context;
        _productSet = context.Set<Product>();
    }

    public async Task<Product> Add(Product entity)
    {
        await _productSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Guid id)
    {
        var product = await _productSet.FindAsync(id);
        if (product == null)
        {
            return false;
        }

        _productSet.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteRange(List<Guid> ids)
    {
        var products = await _productSet.Where(p => ids.Contains(p.Id)).ToListAsync();
        if (!products.Any())
        {
            return false;
        }

        _productSet.RemoveRange(products);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Product>> GetAll()
    {
        return await _productSet.ToListAsync();
    }

    public async Task<List<Product>> GetByCategory(Guid categoryId)
    {
        return await _productSet.Where(p => p.CategoryId == categoryId).ToListAsync();
    }

    public async Task<Product> GetById(Guid id)
    {
        return await _productSet.FindAsync(id);
    }

    public async Task<Product> Update(Product entity)
    {
        var existingProduct = await _productSet.FindAsync(entity.Id);
        if (existingProduct == null)
        {
            throw new InvalidOperationException($"Product with ID {entity.Id} not found.");
        }

        _productSet.Update(entity);
        await _context.SaveChangesAsync();

        return existingProduct;
    }
}
