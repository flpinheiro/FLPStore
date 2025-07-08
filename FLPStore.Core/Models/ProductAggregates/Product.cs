using FLPStore.Core.Models.Shared;

namespace FLPStore.Core.Models.ProductAggregates;

public class Product: BasicEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}
