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
    public static IServiceCollection AddSqlServerInfra(this IHostApplicationBuilder builder)
    {
        builder.AddSqlServerDbContext<SqlServerDbContext>("sqldata");
        return builder.Services;
    }
}
