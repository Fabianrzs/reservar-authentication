using Microsoft.Extensions.DependencyInjection;

namespace Infrastrunture.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        //services.AddTransient<AuthenticationService>();
        return services;
    }
}
