using Domain.Ports;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using System.Data;
using Infrastructura.Adapters;
using Infrastructura.Context;

namespace Authentication.Infrastrunture.Extensions;

public static class PersistenceExtension
{
    public static IServiceCollection AddPesistence(this IServiceCollection svc, IConfiguration config)
    {
        svc.AddTransient<IDbConnection>((sp) => new SqlConnection(config.GetConnectionString("DefaultConnection")));
        svc.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        svc.AddScoped<IUnitOfWork, UnitOfWork>();
        svc.AddTransient<DatabaseMigrator>();
        return svc;
    }
}
