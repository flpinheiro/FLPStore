using FLPStore.Core.Models.Shared;
using FLPStore.Core.Models.UserAggragates;
using FLPStore.Infra.SqlServer.Data.Mappings.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FLPStore.Infra.SqlServer.Data.Mappings.Models;

internal class AppUserMapping : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(256);
        builder.Property(u => u.LastName).IsRequired().HasMaxLength(256);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(256).HasConversion(email => email.Value, value => Email.Create(value));
        builder.Property(u => u.Password).IsRequired().HasMaxLength(256);

        builder.HasIndex(u => u.Email)
            .IsUnique()
            .HasDatabaseName("IX_AppUser_Email");

        builder.OwnsMany(u => u.Addresses, item =>
        {
            item.WithOwner()
                .HasForeignKey("UserId")
                .HasPrincipalKey(u => u.Id);

            AddressMapping.MapAddress(item);
        });

        builder.OwnsMany(u => u.Phones, items =>
        {
            items.WithOwner()
                .HasForeignKey("UserId")
                .HasPrincipalKey(u => u.Id);

            PhoneMapping.MapPhone(items);
        });

        builder.HasMany(u => u.WhishLists)
            .WithOne()
            .HasForeignKey(w => w.UserId)
            .HasPrincipalKey(u => u.Id);

        builder.HasOne(U => U.ShoppingCart)
            .WithOne()
            .HasForeignKey<ShoppingCart>(sc => sc.UserId)
            .HasPrincipalKey<AppUser>(u => u.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Orders)
            .WithOne()
            .HasForeignKey(o => o.UserId)
            .HasPrincipalKey(u => u.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

internal class ShoppingCartMapping : IEntityTypeConfiguration<ShoppingCart>
{
    public void Configure(EntityTypeBuilder<ShoppingCart> builder)
    {
        builder.HasKey(sc => sc.UserId);
        builder.Property(sc => sc.UserId).IsRequired();

        //cart itens mapping on ShoppingCartItemMapping
        builder.OwnsMany(sc => sc.Items, item =>
        {
            item.WithOwner(i => i.Cart)
            .HasForeignKey(i => i.UserId)
            .HasPrincipalKey(sc => sc.UserId);
            item.HasKey(i => new { i.UserId, i.ProductId });
            item.Property(i => i.UserId).IsRequired();
            item.Property(i => i.ProductId).IsRequired();
            item.Property(i => i.Quantity).IsRequired().HasDefaultValue(1);
            item.Property(i => i.IsCheckout).IsRequired().HasDefaultValue(false);

        });

    }
}
internal class WhishListMapping : IEntityTypeConfiguration<WhishList>
{
    public void Configure(EntityTypeBuilder<WhishList> builder)
    {
        builder.HasKey(w => w.Id);
        builder.Property(w => w.UserId).IsRequired();
        builder.Property(w => w.Name).IsRequired().HasMaxLength(256);

        builder.OwnsMany(w => w.Items, item =>
        {
            item.WithOwner(i => i.WhishList)
                .HasForeignKey(i => i.WhishListId)
                .HasPrincipalKey(w => w.Id);
            
            item.HasOne(i => i.Product)
                .WithMany()
                .HasForeignKey(i => i.ProductId)
                .HasPrincipalKey(p => p.Id)
                .OnDelete(DeleteBehavior.Restrict);

            item.HasKey(i => new { i.ProductId, i.WhishListId });
            item.Property(i => i.ProductId).IsRequired();
            item.Property(i => i.WhishListId).IsRequired();
        });
    }
}
