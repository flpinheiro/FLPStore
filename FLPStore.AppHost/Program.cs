var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var password = builder.AddParameter("password", "Chageme@123", secret: true);

var sql = builder.AddSqlServer("sql", password: password, port: 14330)
    .WithDataVolume()
    .WithEndpoint(name: "sqlEndpoint", targetPort: 14330)
    .WithLifetime(ContainerLifetime.Persistent)
    .AddDatabase("sqldata");

var migration = builder.AddProject<Projects.FLPStore_Infra_SqlServer_MigrationService>("migrations")
    .WithReference(sql)
    .WaitFor(sql);

var apiService = builder.AddProject<Projects.FLPStore_ApiService>("apiservice")
    .WaitFor(migration)
    .WithReference(migration)
    .WaitFor(sql)
    .WithReference(sql);

builder.AddProject<Projects.FLPStore_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.AddProject<Projects.FLPStore_Infra_SqlServer_MigrationService>("flpstore-infra-sqlserver-migrationservice");

builder.Build().Run();
