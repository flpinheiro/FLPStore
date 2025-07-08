namespace FLPStore.Core.DTOs.Requests;

public interface IPaginateRequest
{
    int Page { get; init; }
    int PageSize { get; init; }
}

public record PaginateRequest : IPaginateRequest
{
    public int Page { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
