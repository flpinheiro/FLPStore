using FLPStore.CrossCutting.DTOs.Responses;

namespace FLPStore.Domain.DTOs.Responses;

public record PaginatedBaseResponse<TData> : BaseResponse<TData>, IPaginatedBaseResponse<TData> where TData : class
{
    public PaginatedBaseResponse(TData data, int total) : base(data)
    {
        Total = total;
    }
    public int Total { get; }
}

public record BaseResponse<TData> : BaseResponse, IBaseResponse, IBaseResponse<TData> where TData : class
{
    public BaseResponse(TData? data) : base(true)
    {
        Data = data;
    }

    public BaseResponse(bool isSuccess = true, params IEnumerable<string> messages) : base(isSuccess, messages)
    {
    }

    public TData? Data { get; }
}

public record BaseResponse : IBaseResponse
{
    public BaseResponse(bool isSuccess = true, params IEnumerable<string> messages)
    {
        IsSuccess = isSuccess;
        Messages = messages;
    }

    public bool IsSuccess { get; }
    public IEnumerable<string> Messages { get; }
}
