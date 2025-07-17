using NSwag;
using NSwag.Generation.Processors.Security;

namespace FLPStore.ApiService;
public static class OpenApiBuilderExtensions
{
    public static IHostApplicationBuilder AddStandardDocumentation(this IHostApplicationBuilder builder)
    {
        builder.Services.AddOpenApiDocument(options =>
        {
            options.AddSecurity("JWT", [], new OpenApiSecurityScheme
            {
                Type = OpenApiSecuritySchemeType.ApiKey,
                Name = "Authorization",
                In = OpenApiSecurityApiKeyLocation.Header,
                Description = "Type into the textbox: Bearer {your JWT token}."
            });

            options.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));

            options.PostProcess = document =>
                {
                    document.Info = new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Store API",
                        Description = "An ASP.NET Core Web API for managing a Study Store",
                        TermsOfService = "https://example.com/terms",
                        Contact = new OpenApiContact
                        {
                            Name = "Example Contact",
                            Url = "https://example.com/contact"
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Example License",
                            Url = "https://example.com/license"
                        }
                    };
                };
        });

        return builder;
    }

    public static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app)
    {
        // Add OpenAPI 3.0 document serving middleware
        // Available at: http://localhost:<port>/swagger/v1/swagger.json
        app.UseOpenApi();

        // Add web UIs to interact with the document
        // Available at: http://localhost:<port>/swagger
        app.UseSwaggerUi(); // UseSwaggerUI is called only in Development.

        // Add ReDoc UI to interact with the document
        // Available at: http://localhost:<port>/redoc
        app.UseReDoc(options =>
        {
            options.Path = "/redoc";
        });

        return app;
    }
}