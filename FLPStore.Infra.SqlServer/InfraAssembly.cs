using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FLPStore.Infra.SqlServer;

internal class InfraAssembly
{

    // This class is intentionally left empty.
    // It serves as a marker for the assembly and can be used for reflection or other purposes if needed.
}

public static class InfraConfigurationExtensions
{
    private static void AddInfraConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SqlServerContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("sqldata")));
    }

    public static IServiceCollection AddInfraConfiguration(this WebApplicationBuilder builder)
    {
        builder.AddSqlServerDbContext<SqlServerContext>("sqldata");
        builder.Services.AddInfraConfiguration(builder.Configuration);

        return builder.Services;
    }
}
