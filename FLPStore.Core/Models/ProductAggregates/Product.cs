using FLPStore.Core.Models.Shared;

namespace FLPStore.Core.Models.ProductAggregates;

public class Product : BasicEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public bool IsOnStock => Quantity > 0;

    public void AddProduct(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
        Quantity += quantity;
    }
    public void RemoveProduct(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
        if (quantity > Quantity)
            throw new InvalidOperationException("Cannot remove more products than available in stock.");
        Quantity -= quantity;
    }
}
