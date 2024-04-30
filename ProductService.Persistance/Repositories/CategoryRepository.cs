using Microsoft.EntityFrameworkCore;
using ProductService.Application.Contracts;
using ProductService.Domain;
using ProductService.Persistance.Data;

namespace ProductService.Persistance.Repositories;

public class CategoryRepository : IGenericRepository<Category>
{
    private readonly ProductDbContext _context;
    private readonly DbSet<Category> _categorySet;

    public CategoryRepository(ProductDbContext context)
    {
        _context = context;
        _categorySet = context.Set<Category>();
    }

    public async Task<Category> Add(Category entity)
    {
        await _categorySet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Guid id)
    {
        var category = await _categorySet.FindAsync(id);
        if (category == null)
        {
            return false;
        }

        _categorySet.Remove(category);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteRange(List<Guid> ids)
    {
        var categories = await _categorySet.Where(c => ids.Contains(c.Id)).ToListAsync();
        if (!categories.Any())
        {
            return false;
        }

        _categorySet.RemoveRange(categories);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Category>> GetAll()
    {
        return await _categorySet.ToListAsync();
    }

    public async Task<Category> GetById(Guid id)
    {
        return await _categorySet.FindAsync(id);
    }

    public async Task<Category> Update(Category entity)
    {
        var existingCategory = await _categorySet.FindAsync(entity.Id);
        if (existingCategory == null)
        {
            throw new InvalidOperationException($"Category with ID {entity.Id} not found.");
        }

        // Update properties
        existingCategory.Name = entity.Name; // Adjust with correct property
        // Add other properties as needed

        _categorySet.Update(existingCategory);
        await _context.SaveChangesAsync();

        return existingCategory;
    }
}
