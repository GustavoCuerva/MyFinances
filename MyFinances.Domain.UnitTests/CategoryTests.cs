using MyFinances.Domain.Entities;
using MyFinances.Domain.Enums;
using MyFinances.Domain.ErrorList;
using Shouldly;

namespace MyFinances.Domain.UnitTests;

public class CategoryTests
{
	private Installment CreateInstallment() =>
		Installment.Create(1, DateTimeOffset.Now, 1, 0, "");

	private PlannedExpense CreatePlannedExpense() =>
		PlannedExpense.Create("", "", DateTimeOffset.Now, ExpenseTypes.Appellant, [CreateInstallment()]);

	[Theory]
	[InlineData(101)]
	[InlineData(-1)]
	public void Create_PercentNotBetween0And100_ReturnsError(int percent)
	{
		// Arrange
		int freeAmountAllocation = 0;
		var plannedExpense = CreatePlannedExpense();
		var allocation = Allocation.Create("", [plannedExpense], freeAmountAllocation);

		// Act
		var result = Category.Create("Category", "Description", percent, [allocation]);

		// Assert
		result.IsFailure.ShouldBeTrue();
		var error = result.Errors.ShouldHaveSingleItem();
		error.Code.ShouldContain(Errors.Category.InvalidPercent().Code);
	}

	[Fact]
	public void Create_ListAllocationEmpty_ReturnsError()
	{
		// Arrange
		int percent = 50;

		// Act
		var result = Category.Create("Category", "Description", percent, []);

		// Assert
		result.IsFailure.ShouldBeTrue();
		var error = result.Errors.ShouldHaveSingleItem();
		error.Code.ShouldContain(Errors.Category.AllocationIsEmpty().Code);
	}
}
