namespace FLPStore.Core.DTOs.Response;

public interface IBaseReponse<TData> : IBaseResponse where TData : class
{
    TData? Data { get; }
}
public interface IBaseResponse
{
    bool IsSuccess { get; }
    IEnumerable<string>? Messages { get;  }
}
public record BaseResponse(bool IsSuccess, params IEnumerable<string> Messages) : IBaseResponse;
public record BaseReponse<TData>(TData Data) : BaseResponse(true), IBaseReponse<TData> where TData : class;
