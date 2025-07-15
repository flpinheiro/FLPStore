using FLPStore.Core.Models.OrderAggregates;
using FLPStore.Infra.SqlServer.Data.Mappings.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FLPStore.Infra.SqlServer.Data.Mappings.Models;

internal class Ordermapping : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(o => o.TotalValue).IsRequired().HasPrecision(18,2);

        builder.OwnsOne(o => o.ShippingAddress, item => 
        { 
            item.WithOwner()
                 .HasForeignKey("OrderId")
                 .HasPrincipalKey(o => o.Id);

            AddressMapping.MapAddress(item);
        });
        builder.OwnsOne(o => o.ShippingPhone, item =>
        {
            item.WithOwner()
                 .HasForeignKey("OrderId")
                 .HasPrincipalKey(o => o.Id);
            PhoneMapping.MapPhone(item);
        });

        builder.OwnsMany(o => o.Items, items =>
        {
            items.WithOwner()
                 .HasForeignKey(oi => oi.OrderId)
                 .HasPrincipalKey(o => o.Id);

            items.HasOne(oi => oi.Product)
                 .WithMany()
                 .HasForeignKey(oi => oi.ProductId)
                 .HasPrincipalKey(p => p.Id)
                 .OnDelete(DeleteBehavior.Restrict);

            items.HasKey(oi => new { oi.ProductId, oi.OrderId });

            items.Property(oi => oi.ProductId).IsRequired();
            items.Property(oi => oi.OrderId).IsRequired();
            items.Property(oi => oi.Title).IsRequired().HasMaxLength(256);
            items.Property(oi => oi.Quantity).IsRequired();
            items.Property(oi => oi.UnitValue).IsRequired().HasPrecision(18, 2);
        });
    }
}