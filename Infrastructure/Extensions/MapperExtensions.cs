using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Extensions;

public static class AutoMapperExtensions
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}