using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ProductService.Application;

public static class AddApplicationService
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
