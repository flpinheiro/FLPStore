using FLPStore.Core.Models.ProductAggregates;
using FLPStore.Core.Models.Shared;

namespace FLPStore.Core.Models.OrderAggregates;

public class OrderItem : ValueObject
{
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public Guid OrderId { get; set; }
    public string? Title { get; set; }
    public int Quantity { get; set; }
    public decimal UnitValue { get; set; }
    public decimal TotalValue => Quantity * UnitValue;

    public OrderItem()
    {
    }
    public OrderItem(Product? product, int quantity)
    {
        ArgumentNullException.ThrowIfNull(product, nameof(product));

        ProductId = product.Id ?? throw new ArgumentNullException(nameof(product));
        Title = product.Title ?? throw new ArgumentNullException(nameof(product));
        Quantity = quantity;
        UnitValue = product.Price;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return ProductId;
        yield return OrderId;
    }
}
