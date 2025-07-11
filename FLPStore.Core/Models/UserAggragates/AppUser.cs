using FLPStore.Core.Models.Shared;

namespace FLPStore.Core.Models.UserAggragates;

public class AppUser : BasicEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public Email Email { get; set; } = Email.Empty;
    public string Password { get; set; } = null!;

    public ICollection<Address> Addresses { get; set; } = [];
    public ICollection<Phone> Phones { get; set; } = [];
    public ICollection<WhishList> WhishLists { get; set; } = [];

    public ShoppingCart ShoppingCart { get; set; } = new();

}
