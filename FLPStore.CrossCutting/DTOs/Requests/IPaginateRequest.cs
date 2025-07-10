using FLPStore.CrossCutting.Constants;

namespace FLPStore.CrossCutting.DTOs.Requests;

public interface IPaginateRequest
{
    int Page { get; init; }
    int PageSize { get; init; }
    string? SortBy { get; init; }
    SortOrder SortOrder { get; init; }
    string? Query { get; init; }
}
