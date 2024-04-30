using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Application.Contracts;
using ProductService.Domain;
using ProductService.Persistance.Data;
using ProductService.Persistance.Repositories;

namespace ProductService.Persistance;

public static class AddPersistanceService
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuartion)
    {
        services.AddDbContext<ProductDbContext>
        (
            options =>
            {
                options
                .UseLazyLoadingProxies()
                .UseSqlServer
                (
                    configuartion.GetConnectionString("DefaultConnection")
                );
            }
        );

        services.AddScoped<IGenericRepository<Category>, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
