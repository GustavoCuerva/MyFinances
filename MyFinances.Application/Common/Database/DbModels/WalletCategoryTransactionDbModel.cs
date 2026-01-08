using MyFinances.Domain.Enums;

namespace MyFinances.Application.Common.Database.DbModels;

public class WalletCategoryTransactionDbModel
{
	public int Id { get; set; }
	public Guid ReferenceCode { get; set; }
	public int WalletCategoryId { get; set; }
	public WalletCategoryDbModel WalletCategory {  get; set; }
	public string Description { get; set; } = string.Empty;
	public int Amount { get; set; }
	public int TransactionTypeId { get; set; }
	public TransactionsTypeDbModel TransactionType { get; set; }
	public int AllocationId { get; set; }
	public AllocationDbModel Allocation { get; set; }
	public DateTimeOffset Date {  get; set; }
}
