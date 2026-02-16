namespace MyFinances.Application.Commands.Categories.CreateCategory;

public class RequestCreateCategory
{
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
}
