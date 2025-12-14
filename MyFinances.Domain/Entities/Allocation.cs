using MyFinances.Common.Result;
using MyFinances.Domain.ErrorList;

namespace MyFinances.Domain.Entities;

public class Allocation
{
	public int Id { get; private set; }
	public string Name { get; private set; } = string.Empty;
	public IEnumerable<PlannedExpense> PlannedExpenses { get; private set; } = [];
	public int FreeAmount { get; private set; }
	public int AmountReserved => PlannedExpenses.Sum(pe => pe.TotalReservedAmount);
	public int TotalAmount => FreeAmount + AmountReserved;

	private Allocation() { }

	public static Result<Allocation> Create(string name, IEnumerable<PlannedExpense> plannedExpenses, int freeAmount)
	{
		if (!plannedExpenses.Any())
			return Errors.Allocation.PlannedExpenseIsEmpty();

		return new Allocation()
		{
			Name = name,
			PlannedExpenses = plannedExpenses,
			FreeAmount = freeAmount
		};
	}
		
}
