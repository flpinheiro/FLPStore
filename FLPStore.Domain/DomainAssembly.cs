using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace FLPStore.Domain;

internal class DomainAssembly
{
    // This class is intentionally left empty.
    // It serves as a marker for the assembly and can be used for assembly-level attributes or configurations in the future.
}

public static class DomainAssemblyExtensions
{
    // This static class can be used to extend the functionality of the Domain assembly in the future.
    public static void ConfigureDomainAssembly(this IServiceCollection services)
    {
        // Add any domain-specific configurations or services here.
        // For example, you could register domain event handlers, validators, etc.
        // Register MediatR services
        var domainAssembly = typeof(DomainAssembly).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(domainAssembly));
        //Add FluentValidation
        services.AddFluentValidation([domainAssembly]);
        //Add AutoMapper
        services.AddAutoMapper(cfg => cfg.AddMaps(domainAssembly));
    }
}
