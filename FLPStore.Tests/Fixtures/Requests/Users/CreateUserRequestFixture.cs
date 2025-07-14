using FLPStore.Domain.DTOs.Requests.Users;

namespace FLPStore.Tests.Fixtures.Requests.Users;

internal class CreateUserRequestFixture : BasicFixture<CreateUserRequest>
{
    public CreateUserRequestFixture() : base()
    {
        Faker
            .RuleFor(x => x.FirstName, f => f.Person.FirstName)
            .RuleFor(x => x.LastName, f => f.Person.LastName)
            .RuleFor(x => x.Email, f => f.Person.Email)
            .RuleFor(x => x.Password, f => f.Internet.Password())
            .RuleFor(x => x.ConfirmPassword, (f, c) => c.Password)
            .RuleFor(x => x.BirthDate, f => f.Person.DateOfBirth);
    }
}
