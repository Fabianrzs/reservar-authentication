using Infrastructura;
using Microsoft.Extensions.DependencyInjection;
using Notes.Domain.Services.Base;
using System.Reflection;

namespace Infrastrunture.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection svc)
    {
        var _services = new List<Type>();

        Assembly assembly = Assembly.Load(AppConstants.DomainProject);

        _services.AddRange(assembly.GetTypes()
               .Where(p => p.CustomAttributes.Any(x => x.AttributeType 
               == typeof(DomainServiceAttribute))));

        _services.ForEach(serviceType => svc.AddTransient(serviceType));

        return svc;
    }
}
