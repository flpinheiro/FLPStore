using FLPStore.Core.Models.ProductAggregates;
using FLPStore.Core.Models.Shared;

namespace FLPStore.Core.Models.UserAggragates;

public class WhishList(Guid userId, string name, bool isPublic = false) : ValueObject
{
    public Guid? Id { get; set; }
    public Guid UserId { get; set; } = userId;
    public string Name { get; private set; } = name;
    public bool IsPublic { get; set; } = isPublic;

    public ICollection<Product> Products { get; private set; } = [];

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return UserId;
    }

    public void AddProduct(Product product)
    {
        if (Products.Any(x => x.Id == product.Id)) return;
        Products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        if (!Products.Any(x => x.Id == product.Id)) return;
        Products.Remove(product);
    }
}
