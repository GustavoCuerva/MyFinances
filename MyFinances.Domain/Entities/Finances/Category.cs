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

		var category = new Category()
		{
			Name = name,
			Description = description,
			Percent = percent,
			Transactions = transactions,
			PlannedExpenses = plannedExpenses
		};

		var resultIsValid = IsValid(category);

		return resultIsValid.IsFailure ? resultIsValid.Errors : category;
	}

	private static Result IsValid(Category category)
	{
		if (category.Percent is > 100 or < 0)
			return Errors.Category.InvalidPercent();

		if (category.Balance < 0)
			return Errors.Category.BalanceIsNegative();

		if (category.TotalReservedAmount > category.Balance)
			return Errors.Category.ReservedAmountIsGreaterThanBalance();

		if (string.IsNullOrEmpty(category.Name))
			return Errors.Category.NameCannotIsNullOrEmpty();

		if (string.IsNullOrEmpty(category.Description))
			return Errors.Category.DescriptionCannotIsNullOrEmpty();

		return Result.Success();
	}
}
