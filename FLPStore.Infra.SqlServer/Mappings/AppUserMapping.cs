using FLPStore.Core.Models.UserAggragates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FLPStore.Infra.SqlServer.Mappings;

internal class AppUserMapping : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(256);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(256);
        builder.Property(u => u.Password).IsRequired();
        
        builder.HasIndex(u => u.Email)
            .IsUnique()
            .HasDatabaseName("IX_AppUser_Email");

        builder.OwnsMany(u => u.Addresses)
            .WithOwner()
            .HasForeignKey("UserId")
            .HasPrincipalKey(u => u.Id);

        builder.OwnsMany(u => u.Phones)
            .WithOwner()
            .HasForeignKey("UserId")
            .HasPrincipalKey(u => u.Id);

        builder.OwnsMany(u => u.WhishLists)
            .WithOwner()
            .HasForeignKey(w => w.UserId)
            .HasPrincipalKey(u => u.Id);

        builder.OwnsOne(U => U.ShoppingCart)
            .WithOwner()
            .HasForeignKey(sc => sc.UserId)
            .HasPrincipalKey(u => u.Id);

        builder.HasMany(u => u.Orders)
            .WithOne()
            .HasForeignKey(o => o.UserId)
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
    }
}
internal class ShoppingCartItemMapping : IEntityTypeConfiguration<ShoppingCartItem>
{
    public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
    {
        builder.HasKey(i => new { i.UserId, i.ProductId });
        builder.Property(i => i.UserId).IsRequired();
        builder.Property(i => i.ProductId).IsRequired();
        builder.Property(i => i.Quantity).IsRequired().HasDefaultValue(1);
        builder.Property(i => i.IsCheckout).IsRequired().HasDefaultValue(false);
        
        builder.HasOne(i => i.Cart)
            .WithMany(sc => sc.Items)
            .HasForeignKey(i => i.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(i => i.Product)
            .WithMany()
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

internal class WhishListMapping : IEntityTypeConfiguration<WhishList>
{
    public void Configure(EntityTypeBuilder<WhishList> builder)
    {
        builder.HasKey(w => w.Id);
        builder.Property(w => w.UserId).IsRequired();
        builder.Property(w => w.Name).IsRequired().HasMaxLength(256);

        // user mapping on AppUserMapping
        // WhishListItems mapping on WhishListItemMapping
        builder.HasMany(w => w.Items)
            .WithOne()
            .HasForeignKey(i => i.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
