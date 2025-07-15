using FLPStore.Core.Models.ProductAggregates;
using FLPStore.Core.Models.Shared;

namespace FLPStore.Core.Models.UserAggragates;

public class WhishList(Guid userId, string name, bool isPublic = false) : ValueObject
{
    public Guid? Id { get; set; }
    public Guid UserId { get; private set; } = userId;
    public string Name { get; private set; } = name;
    public bool IsPublic { get; private set; } = isPublic;

    public ICollection<WhishListItem> Items { get; set; } = [];

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return UserId;
    }
    private bool HasProduct(Product product)
    {
        return Items.Any(x => x.ProductId == product.Id);
    }
    public void AddProduct(Product product)
    {
        if (HasProduct(product)) return;
        Items.Add(new WhishListItem() { Product = product, ProductId = product.Id ?? Guid.Empty });
    }

    public void RemoveProduct(Product product)
    {
        if (!HasProduct(product)) return;
        Items.Remove(new WhishListItem() { Product = product, ProductId = product.Id ?? Guid.Empty });
    }
}

public class WhishListItem : ValueObject
{
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public Guid WhishListId { get; set; }
    public WhishList? WhishList { get; set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return ProductId;
        yield return WhishListId;
    }
}
