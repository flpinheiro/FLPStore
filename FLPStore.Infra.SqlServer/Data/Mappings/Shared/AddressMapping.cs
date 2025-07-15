using FLPStore.Core.Models.Shared;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FLPStore.Infra.SqlServer.Data.Mappings.Shared;

internal class AddressMapping
{
    public static void MapAddress<TClass>(OwnedNavigationBuilder<TClass, Address> item)
        where TClass : class
    {
        item.Property(a => a.Street).IsRequired().HasMaxLength(256);
        item.Property(a => a.City).IsRequired().HasMaxLength(128);
        item.Property(a => a.State).HasMaxLength(128);
        item.Property(a => a.Country).IsRequired().HasMaxLength(128);
        item.Property(a => a.ZipCode).IsRequired().HasMaxLength(20);
    }
}
