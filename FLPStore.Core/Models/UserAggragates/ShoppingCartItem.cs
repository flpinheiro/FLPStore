﻿using FLPStore.Core.Models.ProductAggregates;
using FLPStore.Core.Models.Shared;

namespace FLPStore.Core.Models.UserAggragates;

public class ShoppingCartItem : ValueObject
{
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }

    public int Quantity { get; set; }
    public bool IsCheckout { get; set; }

    public Guid UserId { get; set; }
    public ShoppingCart? Cart { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return ProductId;
        yield return UserId;
    }
}