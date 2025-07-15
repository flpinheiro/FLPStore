using FLPStore.Core.Models.Shared;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FLPStore.Infra.SqlServer.Data.Mappings.Shared;

internal class PhoneMapping
{
    public static void MapPhone<TClass>(OwnedNavigationBuilder<TClass, Phone> item)
        where TClass : class
    {
        item.Property(p => p.Number).IsRequired().HasMaxLength(20);
        item.Property(p => p.Type).IsRequired().HasMaxLength(50);
        item.Property(p => p.AreaCode).HasMaxLength(10);
        item.Property(p => p.CountryCode).HasMaxLength(10);
    }
}
