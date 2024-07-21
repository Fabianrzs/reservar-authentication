using Authentication.Infrastrunture.Extensions;
using Infrastructure.Extensions;
using Infrastrunture.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastrunture;

public static class Startup
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddPesistence(config);
        services.AddDomainServices();
        services.AddJwtSettings(config);
        services.AddMediator();
        services.AddMapper();
        services.AddValidator();
        services.AddSwagger();
        services.AddCorsPolicy();
    }

    public static void UseInfrastructure(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCorsPolicy();
        app.UseSwaggers(env);
        app.UseExceptionMiddleware();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseHttpsRedirection();
    }
}
