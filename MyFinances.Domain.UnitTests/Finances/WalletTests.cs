using MyFinances.Domain.Entities.Finances;
using MyFinances.Domain.ErrorList;
using Shouldly;

namespace MyFinances.Domain.UnitTests.Finances;

public class WalletTests
{
	[Fact]
	public void Create_CategoriesPercentNot100_ReturnsError()
	{
		// Arrange
		var categories = new List<Category>()
		{
			Category.Create("Category", "Description", 100, [], []),
			Category.Create("Category", "Description", 100, [], [])
		};

		// Act
		var result = Wallet.Create("Wallet Test", "This Wallet is only test if the sum percent to categories is not diferent 100", categories);
		
		// Assert
		result.IsFailure.ShouldBeTrue();
		var error = result.Errors.ShouldHaveSingleItem();
		error.Code.ShouldContain(Errors.Wallet.PercentCategorisIsNot100().Code);
	}
}
