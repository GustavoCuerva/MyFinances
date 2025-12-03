using MyFinances.Common.ExceptionsPattern;

namespace MyFinances.Common.Result;

public class Result<T> : Result
{
	private readonly T _data;

	public T Data => IsSuccess ? _data : throw new ResultFailException(Errors);

	public Result(bool isSucces, IEnumerable<Error> errors, T data) : base(isSucces, errors) => _data = data;

	public static implicit operator Result<T>(T data) => Success(data);
	public static implicit operator Result<T>(Error error) => Fail<T>(error);
	public static implicit operator Result<T>(List<Error> errors) => Fail<T>(errors);
	public static implicit operator T(Result<T> result) => result.IsSuccess ? result.Data : throw new ResultFailException(result.Errors);
}
