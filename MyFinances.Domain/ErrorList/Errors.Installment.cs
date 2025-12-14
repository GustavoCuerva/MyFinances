using MyFinances.Common.Result;

namespace MyFinances.Domain.ErrorList;

public static partial class Errors
{
	public static class Installment
	{
		public static Error RequiredAmountIsSmaller1()
			=> new("installment.requiredAmount", "Required Amount must be greater than 0.");

		public static Error ReservedAmountIsSmaller0()
			=> new("installment.reservedAmount", "Reserved Amount must be greater or equal than 0");
	}
}
