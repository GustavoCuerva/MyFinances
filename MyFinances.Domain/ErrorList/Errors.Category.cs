using MyFinances.Common.Result;

namespace MyFinances.Domain.ErrorList;

public static partial class Errors
{
	public static class Category
	{
		public static Error InvalidPercent()
			=> new("category.percent", "The percentage must be between 0% and 100%.");

		public static Error AllocationIsEmpty()
			=> new("category.allocations.empty", "The allocations can't is empty.");
	}
}
