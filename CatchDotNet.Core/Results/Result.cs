namespace CatchDotNet.Core;

public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error!=Error.None)
        {
            throw new InvalidOperationException();
        }

        if(!isSuccess && error==Error.None)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public Error Error { get; }

    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);
    public static Result<T> Failure<T>(Error error) => new(default!, false, error);
    public static Result<T> Create<T>(T? value) =>
 value is not null ? Success(value) : Failure<T>(Error.NullValue);

    public static Result Create(Error? error) => error is not null ? Success() : Failure(error); 
    //implicit operator convert Error > Result 
    public static implicit operator Result(Error error) => Create(error);
}


public class Result<TValue> :Result
{
    private readonly TValue? _value;

    protected internal Result(TValue? value, bool isSuccess, Error error)
        :base(isSuccess, error) 
    {
        _value = value;
    }



    
    public TValue? Value => IsSuccess ? 
        _value : 
        throw new InvalidOperationException("The value of a failure result can not be accessed");
    //implicit operator convert Error > Result 
    public static implicit operator Result<TValue>(TValue? value) => Create(value);

    public static implicit operator Result<TValue>(Error? error) => new(default!,true, error);

  
}
