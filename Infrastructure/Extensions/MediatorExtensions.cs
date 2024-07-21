using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Extensions;

public static class MediatorExtensions
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}
