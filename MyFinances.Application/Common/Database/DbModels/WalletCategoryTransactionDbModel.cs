namespace MyFinances.Application.Common.Database.DbModels;

public class WalletCategoryTransactionDbModel
{
	public int Id { get; set; }
	public Guid ReferenceCode { get; set; }
	public int WalletCategoryId { get; set; }
	public WalletCategoryDbModel WalletCategory {  get; set; }
	public string Description { get; set; } = string.Empty;
	public int Amount { get; set; }
	public string EntryType { get; set; } = string.Empty; // Income, Expense, Transfer
	public string Allocation { get; set; } = string.Empty;
	public DateTimeOffset Date {  get; set; }
}
