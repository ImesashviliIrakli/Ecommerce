using Microsoft.EntityFrameworkCore;
using ProductService.Domain;

namespace ProductService.Persistance.Data;

public class ProductDbContext: DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options){}

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}
