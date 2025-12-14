using MyFinances.Domain.Entities;
using MyFinances.Domain.ErrorList;
using Shouldly;

namespace MyFinances.Domain.UnitTests;

public class AllocationTests
{
	[Fact]
	public void Create_PlannedExpensesEmpty_ReturnError()
	{
		// Arrange
		int freeAmount = 0;

		// Act
		var result = Allocation.Create("", [], freeAmount);

		// Assert
		result.IsFailure.ShouldBeTrue();
		var error = result.Errors.ShouldHaveSingleItem();
		error.Code.ShouldContain(Errors.Allocation.PlannedExpenseIsEmpty().Code);
	}
}
