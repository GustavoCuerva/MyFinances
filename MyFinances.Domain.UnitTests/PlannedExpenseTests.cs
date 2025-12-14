using MyFinances.Domain.Entities;
using MyFinances.Domain.Enums;
using MyFinances.Domain.ErrorList;
using Shouldly;

namespace MyFinances.Domain.UnitTests;

public class PlannedExpenseTests
{
	[Fact]
	public void Create_InstallmentEmpty_ReturnError()
	{
		// Act
		var result = PlannedExpense.Create("", "", DateTimeOffset.Now, ExpenseTypes.Sporadic, []);

		// Assert
		result.IsFailure.ShouldBeTrue();
		var error = result.Errors.ShouldHaveSingleItem();
		error.Code.ShouldContain(Errors.PlannedExpense.InstallmentIsEmpty().Code);
	}
}
