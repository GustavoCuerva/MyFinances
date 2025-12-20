using MyFinances.Domain.Enums;

namespace MyFinances.Domain.Entities;

public class WalletCategoryTransaction
{
	public int Id { get; private set; }
	public string Description { get; private set; } = string.Empty;
	public int Amount { get; private set; }
	public TransactionType TransactionType { get; private set; }
	public Allocation Allocation { get; private set; }
	public DateTimeOffset Date { get; private set; }

	private WalletCategoryTransaction() { }

	public static WalletCategoryTransaction Create(int id, string description, int amount, TransactionType transactionType, Allocation allocation, DateTimeOffset date) 
		=> new() {
			Id = id,
			Description = description,
			Amount = amount,
			TransactionType = transactionType,
			Allocation = allocation,
			Date = date
		};
}
