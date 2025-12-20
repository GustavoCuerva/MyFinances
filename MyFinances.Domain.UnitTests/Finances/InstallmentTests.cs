using MyFinances.Domain.Entities.Finances;
using MyFinances.Domain.ErrorList;
using Shouldly;

namespace MyFinances.Domain.UnitTests.Finances;

public class InstallmentTests
{
	[Theory]
	[InlineData(-1)]
	[InlineData(0)]
	public void Create_RequiredAmountBelow1_ReturnError(int requiredAmount)
	{
		// Arrange
		int installmentNumber = 1;
		int reservedAmount = 0;

		// Act
		var result = Installment.Create(installmentNumber, DateTimeOffset.Now, requiredAmount, reservedAmount, "");

		// Assert
		result.IsFailure.ShouldBeTrue();
		var error = result.Errors.ShouldHaveSingleItem();
		error.Code.ShouldContain(Errors.Installment.RequiredAmountIsSmaller1().Code);
	}

	[Fact]
	public void Create_ReservedAmountBelow0_ResturnError()
	{
		// Arrange
		int installmentNumber = 1;
		int reservedAmount = -1;
		int requiredAmount = 1;

		// Act
		var result = Installment.Create(installmentNumber, DateTimeOffset.Now, requiredAmount, reservedAmount, "");

		// Assert
		result.IsFailure.ShouldBeTrue();
		var error = result.Errors.ShouldHaveSingleItem();
		error.Code.ShouldContain(Errors.Installment.ReservedAmountIsSmaller0().Code);
	}
}
