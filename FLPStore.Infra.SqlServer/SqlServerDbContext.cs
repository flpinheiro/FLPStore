﻿using FLPStore.Core.Models.OrderAggregates;
using FLPStore.Core.Models.ProductAggregates;
using FLPStore.Core.Models.UserAggragates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FLPStore.Infra.SqlServer;

public class SqlServerDbContext : DbContext
{
    public SqlServerDbContext(DbContextOptions options) : base(options)
    {
    }

    protected SqlServerDbContext()
    {
    }

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<AppUser> Users { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure your entity mappings here
        base.OnModelCreating(modelBuilder);

        // Apply configurations from the assembly where the context is defined
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfraAssembly).Assembly);
    }
}


public class SqlServerContextFactory : IDesignTimeDbContextFactory<SqlServerDbContext>
{
    public SqlServerDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

        var optionsBuilder = new DbContextOptionsBuilder<SqlServerDbContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("sqldata"));

        return new SqlServerDbContext(optionsBuilder.Options);
    }
}
