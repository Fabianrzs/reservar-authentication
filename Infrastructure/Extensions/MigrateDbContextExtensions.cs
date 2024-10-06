using Infrastructura.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Infrastructure.Extensions;

public static class MigrateDbContextExtensions
{
    public static void MigrateDbContextServices(IServiceScope scope)
    {
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<DatabaseMigrator>>();
        var dbConnection = services.GetRequiredService<IDbConnection>();
        var migrator = new DatabaseMigrator(dbConnection, logger);

        try
        {
            // Generar scripts de migración
            var migrationScripts = MigrationScriptService.GenerateScripts();

            // Ejecutar migraciones
            migrator.MigrateAsync(migrationScripts).Wait();
            logger.LogInformation("Database migration completed successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while migrating the database.");
        }
    }

    public static IApplicationBuilder UseCors(this IApplicationBuilder app)
    {
       /* using (var scope = app.ApplicationServices.CreateScope())
        {
            if (env.IsDevelopment())
            {
                MigrateDbContextExtensions.MigrateDbContextServices(scope);
            }
        }*/
        return app;
    }
}
