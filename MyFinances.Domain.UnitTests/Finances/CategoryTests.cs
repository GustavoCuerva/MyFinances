using MyFinances.Domain.Entities.Finances;
using MyFinances.Domain.Enums;
using MyFinances.Domain.ErrorList;
using Shouldly;

namespace MyFinances.Domain.UnitTests.Finances;

public class CategoryTests
{
	private Installment CreateInstallment(int reservedAmount) =>
		Installment.Create(1, DateTimeOffset.Now, (reservedAmount + 1), reservedAmount, "");

	private PlannedExpense CreatePlannedExpense(int reservedAmount) =>
		PlannedExpense.Create("Name", "Description", DateTimeOffset.Now, ExpenseTypes.Appellant, [CreateInstallment(reservedAmount)]);

	private WalletCategoryTransaction CreateWalletCategoryTransaction(int amount) =>
		WalletCategoryTransaction.Create(1, "Description", amount, TransactionType.Expense, Allocation.Bank, DateTimeOffset.Now);

	[Theory]
	[InlineData(101)]
	[InlineData(-1)]
	public void Create_PercentNotBetween0And100_ReturnsError(int percent)
	{
		// Arrange
		int amount = 2;
		int reservedAmount = 1;
		var transaction = CreateWalletCategoryTransaction(amount);
		var plannedExpense = CreatePlannedExpense(reservedAmount);

		// Act
		var result = Category.Create("Category", "Description", percent, [transaction], [plannedExpense]);

		// Assert
		result.IsFailure.ShouldBeTrue();
		var error = result.Errors.ShouldHaveSingleItem();
		error.Code.ShouldContain(Errors.Category.InvalidPercent().Code);
	}

	[Fact]
	public void Create_BalanceBelow0_ReturnsError()
	{
		// Arrange
		int percent = 50;
		int amount = -50;
		int reservedAmount = 1;
		var transaction = CreateWalletCategoryTransaction(amount);
		var plannedExpense = CreatePlannedExpense(reservedAmount);

		// Act
		var result = Category.Create("Category", "Description", percent, [transaction], [plannedExpense]);

		// Assert
		result.IsFailure.ShouldBeTrue();
		var error = result.Errors.ShouldHaveSingleItem();
		error.Code.ShouldContain(Errors.Category.BalanceIsNegative().Code);
	}

	[Fact]
	public void Create_TotalReservedAmountBelowBalance_ReturnsError()
	{
		// Arrange
		int percent = 50;
		int amount = 20;
		int reservedAmount = 30;
		var transaction = CreateWalletCategoryTransaction(amount);
		var plannedExpense = CreatePlannedExpense(reservedAmount);

		// Act
		var result = Category.Create("Category", "Description", percent, [transaction], [plannedExpense]);

		// Assert
		result.IsFailure.ShouldBeTrue();
		var error = result.Errors.ShouldHaveSingleItem();
		error.Code.ShouldContain(Errors.Category.ReservedAmountIsGreaterThanBalance().Code);
	}
}
