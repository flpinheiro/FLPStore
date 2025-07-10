namespace FLPStore.CrossCutting.DTOs.Responses;
public interface IPaginatedBaseResponse<out TData> : IBaseResponse<TData> where TData : class
{
    int Total { get;  }
}

public interface IBaseResponse<out TData> : IBaseResponse where TData : class
{
    TData? Data { get;  }
}
public interface IBaseResponse
{
    bool IsSuccess { get; }
    IEnumerable<string> Messages { get;  }
}
