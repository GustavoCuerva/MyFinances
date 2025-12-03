using MyFinances.Common.Result;

namespace MyFinances.Common.ExceptionsPattern;

public sealed class ResultFailException : Exception
{
	public IReadOnlyList<Error> Errors { get; }

	internal ResultFailException(IEnumerable<Error> errors)
		: base($"Tentativa de acesso no valor de um resultado falho. O erro era: {errors}")
		=> Errors = [.. errors];
}
