using MyFinances.Common.Result;

namespace MyFinances.Domain.Entities;

public class Category
{
	public int Id { get; private set; }
	public string Name { get; private set; } = string.Empty;
	public string Description { get; private set; } = string.Empty;
	public decimal Percent {  get; private set; } // I think it's not here
	public IEnumerable<Allocation> Allocations { get; private set; } = [];
	public int Amount => Allocations.Sum(a => a.TotalAmount);

	private Category() { }

	public static Result<Category> Create(string name, string description, decimal percent, IEnumerable<Allocation> allocations)
	{
		if (percent > 100)
			return new Error("category.percent", "The percentage can't be more than 100%.");

		if (percent < 0)
			return new Error("category.percent", "The percentage can't be smaller than 0%.");

		if (!allocations.Any())
			return new Error("category.allocations.empty", "The allocations can't is empty.");

		return new Category()
		{
			Name = name,
			Description = description,
			Percent = percent,
			Allocations = allocations
		};
	}
}
