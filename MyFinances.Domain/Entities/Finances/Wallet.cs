using MyFinances.Common.Result;
using MyFinances.Domain.ErrorList;

namespace MyFinances.Domain.Entities.Finances;

public class Wallet
{
	public int Id { get; private set;  }
	public string Name { get; private set; } = string.Empty;
	public string Description { get; private set; } = string.Empty;
	public IEnumerable<Category> Categories { get; private set; } = [];
	public int Amount => Categories.Sum(c => c.Balance);

	private Wallet() { }

	public static Result<Wallet> Create(string name, string description, IEnumerable<Category> categories)
	{
		if (categories.Sum(c => c.Percent) != 100)
			return Errors.Wallet.PercentCategorisIsNot100();

		return new Wallet()
		{
			Name = name,
			Description = description,
			Categories = categories
		};
	} 


}