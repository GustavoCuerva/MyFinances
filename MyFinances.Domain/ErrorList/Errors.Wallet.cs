using MyFinances.Common.Result;

namespace MyFinances.Domain.ErrorList;

public static partial class Errors
{
	public static class Wallet
	{
		public static Error PercentCategorisIsNot100() 
			=> new("wallet.percent", "The division of categories must equal 100");
	}
}
