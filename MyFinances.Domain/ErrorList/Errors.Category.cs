using MyFinances.Common.Result;

namespace MyFinances.Domain.ErrorList;

public static partial class Errors
{
	public static class Category
	{
		public static Error InvalidPercent()
			=> new("category.percent", "The percentage must be between 0% and 100%.");

		public static Error BalanceIsNegative()
			=> new("category.balance.negative", "The balance category cannot is negative.");

		public static Error ReservedAmountIsGreaterThanBalance()
			=> new("category.plannedExpense.reservedAmount", "The Reserved Amount is greater than balance.");
	}
}
