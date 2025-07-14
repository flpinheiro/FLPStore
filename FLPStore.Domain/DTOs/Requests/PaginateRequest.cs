using FLPStore.CrossCutting.Constants;
using FLPStore.CrossCutting.DTOs.Requests;

namespace FLPStore.Domain.DTOs.Requests;

public record PaginateRequest : IPaginateRequest
{
    public int Page { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public string? SortBy { get; init; }
    public SortOrder SortOrder { get; init; } = SortOrder.Ascending;
    public string? Query { get; init; }
}