using FLPStore.Core.Models.Shared;

namespace FLPStore.Core.Models.UserAggragates;

public class ShoppingCart : ValueObject
{
    public Guid UserId { get; set; }
    public AppUser? User { get; set; }
    public ICollection<ShoppingCartProduct> Products { get; set; } = [];

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return UserId;
    }
}
