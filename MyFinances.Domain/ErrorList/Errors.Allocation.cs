using MyFinances.Common.Result;

namespace MyFinances.Domain.ErrorList;

public static partial class Errors
{
	public static class Allocation
	{
		public static Error PlannedExpenseIsEmpty()
			=> new("allocation.plannedExpenses.empty", "The planned expenses can't is empty");
	}
}
