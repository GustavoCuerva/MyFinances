using MyFinances.Common.Result;
using MyFinances.Domain.Enums;

namespace MyFinances.Domain.Entities;

public class PlannedExpense
{
	public int Id { get; private set; }
	public string Name { get; private set; } = string.Empty;
	public string Description { get; private set; } = string.Empty;
	public DateTimeOffset Date { get; private set; }
	public ExpenseTypes Type {  get; private set; }
	public IEnumerable<Installment> Installments { get; private set; } = [];
	public int TotalReservedAmount => Installments.Where(i => !i.IsPayed).Sum(i => i.ReservedAmount);
	public int TotalInstallments => Installments.Count();

	private PlannedExpense() { }

	public static Result<PlannedExpense> Create(string name, string description, DateTimeOffset data, ExpenseTypes type, IEnumerable<Installment> installments)
	{
		if (!installments.Any())
			return new Error("plannedExpense.installments.empty", "The installments can't is empty.");

		return new PlannedExpense()
		{
			Name = name,
			Description = description,
			Date = data,
			Type = type,
			Installments = installments
		}; 
	}
}
