namespace MyFinances.Application.Common.Database.DbModels;

public class WalletCategoryDbModel
{
	public int Id { get; set; }
	public int WalletId { get; set; }
	public WalletDbModel Wallet { get; set; }
	public int CategoryId { get; set; }
	public CategoryDbModel Category {  get; set; }
	public double Percent {  get; set; }
	public DateTimeOffset CreateAt { get; set; }
	public bool IsActive { get; set; }
	public ICollection<WalletCategoryTransactionDbModel> Transactions { get; set; } = [];
	public ICollection<PlannedExpenseDbModel> PlannedExpenses { get; set; } = [];
}