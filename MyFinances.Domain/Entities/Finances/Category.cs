using MyFinances.Common.Result;
using MyFinances.Domain.ErrorList;

namespace MyFinances.Domain.Entities.Finances;

public class Category
{
	public int Id { get; private set; }
	public string Name { get; private set; } = string.Empty;
	public string Description { get; private set; } = string.Empty;
	public decimal Percent {  get; private set; }
	public IEnumerable<WalletCategoryTransaction> Transactions { get; private set; } = [];
	public IEnumerable<PlannedExpense> PlannedExpenses { get; private set; } = [];
	public int Balance => Transactions.Sum(t => t.Amount);
	public int TotalReservedAmount => PlannedExpenses.Sum(p => p.TotalReservedAmount);

	private Category() { }

	public static Result<Category> Create(string name, string description, decimal percent, IEnumerable<WalletCategoryTransaction> transactions, IEnumerable<PlannedExpense> plannedExpenses)
	{
		if (percent > 100)
			return Errors.Category.InvalidPercent();

		if (percent < 0)
			return Errors.Category.InvalidPercent();

		var category = new Category()
		{
			Name = name,
			Description = description,
			Percent = percent,
			Transactions = transactions,
			PlannedExpenses = plannedExpenses
		};

		if (category.Balance < 0)
			return Errors.Category.BalanceIsNegative();

		if (category.TotalReservedAmount > category.Balance)
			return Errors.Category.ReservedAmountIsGreaterThanBalance();

		return category;
	}
}
