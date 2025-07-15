var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var username = builder.AddParameter("username");
var password = builder.AddParameter("password", "Chageme@123", secret: true);

var sql = builder.AddSqlServer("sql", password: password, port: 14330)
    .WithDataVolume()
    .WithEndpoint(name: "sqlEndpoint", targetPort: 14330)
    .WithLifetime(ContainerLifetime.Persistent)
    .AddDatabase("sqldata");

var keycloak = builder.AddKeycloak("keycloak", 8080)
    .WithLifetime(ContainerLifetime.Persistent)
    .WithDataVolume()
    .WithReference(sql)
    .WaitFor(sql)
    ;

var migration = builder.AddProject<Projects.FLPStore_Infra_SqlServer_MigrationService>("migrations")
    .WithReference(sql)
    .WaitFor(sql);

var apiService = builder.AddProject<Projects.FLPStore_ApiService>("apiservice")
    .WithReference(keycloak)
    .WaitFor(keycloak)
    .WaitFor(migration)
    .WithReference(migration)
    .WaitFor(sql)
    .WithReference(sql);

builder.AddProject<Projects.FLPStore_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(keycloak)
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
