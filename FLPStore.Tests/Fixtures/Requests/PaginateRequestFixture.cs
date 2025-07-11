using FLPStore.CrossCutting.Constants;
using FLPStore.CrossCutting.DTOs.Requests;

namespace FLPStore.Tests.Fixtures.Requests;

internal class PaginateRequestFixture<TPaginated> : BasicFixture<TPaginated>
    where TPaginated : class, IPaginateRequest
{
    public PaginateRequestFixture() : base()
    {
        Faker.RuleFor(x => x.Page, x => x.Random.Int(1, 100))
            .RuleFor(x => x.PageSize, x => x.Random.Int(1, 100))
            .RuleFor(x => x.SortBy, x => x.Random.Word())
            .RuleFor(x => x.SortOrder, Xunit => Xunit.PickRandom<SortOrder>())
            .RuleFor(x => x.Query, Xunit => Xunit.Random.Word());
    }
}
