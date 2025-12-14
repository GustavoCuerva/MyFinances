using MyFinances.Domain.Entities;
using MyFinances.Domain.Enums;
using MyFinances.Domain.ErrorList;
using Shouldly;

namespace MyFinances.Domain.UnitTests;

public class WalletTests
{
	[Fact]
	public void Create_CategoriesPercentNot100_ReturnsError()
	{
		var plannedExpense = PlannedExpense.Create("", "", DateTimeOffset.Now, ExpenseTypes.Appellant, [Installment.Create(1, DateTimeOffset.Now, 1, 0, "")]);

		var categories = new List<Category>()
		{
			Category.Create("Category", "Description", 100, [Allocation.Create("", [plannedExpense], 0)]),
			Category.Create("Category", "Description", 100, [Allocation.Create("", [plannedExpense], 0)])
		};

		var result = Wallet.Create("Wallet Test", "This Wallet is only test if the sum percent to categoris is not diferent 100", categories);

		result.IsFailure.ShouldBeTrue();
		var error = result.Errors.ShouldHaveSingleItem();
		error.Code.ShouldContain(Errors.Wallet.PercentCategorisIsNot100().Code);
	}
}
