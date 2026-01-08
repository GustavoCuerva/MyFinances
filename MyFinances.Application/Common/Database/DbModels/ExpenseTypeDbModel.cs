namespace MyFinances.Application.Common.Database.DbModels;

public class ExpenseTypeDbModel
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;

	public ICollection<PlannedExpenseDbModel> PlannedExpenses { get; set; } = [];
}
