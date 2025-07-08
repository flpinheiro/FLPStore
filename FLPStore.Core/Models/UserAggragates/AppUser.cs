using FLPStore.Core.Models.Shared;

namespace FLPStore.Core.Models.UserAggragates;

public class AppUser : BasicEntity
{
    public ICollection<Address> Addresses { get; set; } = [];
    public ICollection<Phone> Phones { get; set; } = [];
    public ICollection<WhishList> WhishLists { get; set; } = [];

    public ShoppingCart ShoppingCart { get; set; } = new();

}
