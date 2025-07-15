using FLPStore.Infra.SqlServer.MigrationService;
using FLPStore.ServiceDefaults;
using FLPStore.Infra.SqlServer;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.AddSqlServerInfra();

builder.Services.AddHostedService<Worker>();
builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));

var host = builder.Build();
host.Run();
