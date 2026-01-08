using MyFinances.Domain.Enums;

namespace MyFinances.Application.Common.Database.DbModels;

public class PlannedExpenseDbModel
{
	public int Id { get; set; }
	public Guid ReferenceCode { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public DateTimeOffset Date { get; set; }
	public int TypeId { get; set; }
	public ExpenseTypeDbModel Type { get; set; }
	public int WalletCategoryId { get; set; }
	public WalletCategoryDbModel WalletCategory { get; set; }
	public ICollection<InstallmentDbModel> Installments { get; set; } = [];
}
