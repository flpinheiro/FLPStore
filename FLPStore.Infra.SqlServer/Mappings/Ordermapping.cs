using FLPStore.Core.Models.OrderAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FLPStore.Infra.SqlServer.Mappings;

internal class Ordermapping : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id).IsRequired();
        builder.Property(o => o.TotalValue).IsRequired().HasPrecision(18,2);

        builder.OwnsOne(o => o.ShippingAddress)
            .WithOwner()
            .HasForeignKey("OrderId")
            .HasPrincipalKey(o => o.Id);

        builder.OwnsMany(o => o.Items)
            .WithOwner()
            .HasForeignKey(oi => oi.OrderId)
            .HasPrincipalKey(o => o.Id);
    }
}

internal class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(oi => new { oi.ProductId, oi.OrderId });
        builder.Property(oi => oi.ProductId).IsRequired();
        builder.Property(oi => oi.OrderId).IsRequired();
        builder.Property(oi => oi.Title).IsRequired().HasMaxLength(256);
        builder.Property(oi => oi.Quantity).IsRequired();
        builder.Property(oi => oi.UnitValue).IsRequired().HasPrecision(18,2);
    }
}