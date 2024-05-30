using Microsoft.Extensions.DependencyInjection;

namespace ThriftManager.Infrastructure;

public static class DIRegister
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IThriftAppDbContext, ThriftAppDbContext>();
    }
}
