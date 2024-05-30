using Microsoft.Extensions.DependencyInjection;
using ThriftManager.Service.MemberServices;

namespace ThriftManager.Service;

public static class DIRegsiter
{
    public static IServiceCollection AddThriftServices(this IServiceCollection services)
    {
        services.AddInfrastructure();
        services.AddScoped<IMemberService, MemberService>();
        return services;
    }
}
