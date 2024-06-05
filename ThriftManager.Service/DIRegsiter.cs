namespace ThriftManager.Service;

public static class DIRegsiter
{
    public static IServiceCollection AddThriftServices(this IServiceCollection services)
    {
        services.AddInfrastructure();
        services.AddScoped<IMemberService, MemberService>();
        services.AddScoped<IGroupService, GroupService>();
        return services;
    }
}
