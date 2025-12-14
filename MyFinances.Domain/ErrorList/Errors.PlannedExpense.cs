using MyFinances.Common.Result;

namespace MyFinances.Domain.ErrorList;

public static partial class Errors
{
	public static class PlannedExpense
	{
		public static Error InstallmentIsEmpty()
			=> new("plannedExpense.installments.empty", "The installments can't is empty.");
	}
}
