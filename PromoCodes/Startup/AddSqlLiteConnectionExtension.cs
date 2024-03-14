using PromoCodes.EntityFramework;

namespace PromoCodes.Startup;

public static class AddSqlLiteConnectionExtension
{
    public static IServiceCollection AddSqlLiteConnection(this IServiceCollection services)
    {
        services.AddDbContext<SqlLiteContext>();

        return services;
    }
}