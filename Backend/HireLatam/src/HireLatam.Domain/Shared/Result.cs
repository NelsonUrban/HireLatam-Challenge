namespace HireLatam.Domain.Shared;

public class Result<TData>
{
    public bool IsSuccessful { get; }
    public string Message { get; set; }
    public TData Data { get; }

    public Result(TData data)
    {
        IsSuccessful = true;
        Data = data;
    }

    public Result(string message)
    {
        IsSuccessful = false;
        Message = message;
    }

    public static Result<TData> Success(TData data) => new Result<TData>(data);
    public static Result<TData> Error(string message) => new Result<TData>(message);
}
