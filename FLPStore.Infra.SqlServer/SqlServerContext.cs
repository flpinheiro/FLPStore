using FLPStore.Core.Models.ProductAggregates;
using FLPStore.Core.Models.UserAggragates;
using Microsoft.EntityFrameworkCore;

namespace FLPStore.Infra.SqlServer;

public class SqlServerContext(DbContextOptions<SqlServerContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<AppUser> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure your entity mappings here
        base.OnModelCreating(modelBuilder);

        // Apply configurations from the assembly where the context is defined
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfraAssembly).Assembly);
    }
}
