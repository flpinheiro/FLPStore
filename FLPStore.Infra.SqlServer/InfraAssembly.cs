using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FLPStore.Infra.SqlServer;

internal class InfraAssembly
{

    // This class is intentionally left empty.
    // It serves as a marker for the assembly and can be used for reflection or other purposes if needed.
}

public static class InfraConfigurationExtensions
{
    public static void AddInfraConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SqlServerContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));
    }
}
