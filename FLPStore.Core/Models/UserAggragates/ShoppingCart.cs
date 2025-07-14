using FLPStore.Core.Models.Shared;

namespace FLPStore.Core.Models.UserAggragates;

public class ShoppingCart : ValueObject
{
    public Guid UserId { get; set; }
    public ICollection<ShoppingCartItem> Items { get; set; } = [];
    
    public ShoppingCart() { }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return UserId;
    }
}
