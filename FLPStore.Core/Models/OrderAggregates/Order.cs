using FLPStore.Core.Models.Shared;
using FLPStore.Core.Models.UserAggragates;

namespace FLPStore.Core.Models.OrderAggregates;

public class Order : BasicEntity
{
    public Guid UserId { get; set; }
    public AppUser? User { get; set; }

    public Address? ShippingAddress { get; set; }
    public ICollection<OrderItem> Products { get; set; } = [];

    public decimal TotalValue { get; set; }

    public Order(ShoppingCart cart, Address shippingAddress)
    {
        User = cart.User;
        UserId = cart.UserId;
        Products = SetOrderProducts(cart.Items);
        ShippingAddress = shippingAddress;
        CalculateTotalValue();
    }

    public Order(Guid userId, decimal totalValue, Address? shippingAddress, ICollection<OrderItem> products)
    {
        UserId = userId;
        ShippingAddress = shippingAddress;
        Products = products;
        TotalValue = totalValue;
    }

    private static List<OrderItem> SetOrderProducts(ICollection<ShoppingCartItem> cartProducts)
    {
        List<OrderItem> products = new(cartProducts.Count);
        foreach (var product in cartProducts)
        {
            if (product is not null && product.IsCheckout)
            {
                products.Add(new OrderItem(product.Product, product.ProductQuantity));
            }
        }
        return products;
    }
    private void CalculateTotalValue() => TotalValue = Products.ToList().Sum(x => x.TotalValue);
        
}
