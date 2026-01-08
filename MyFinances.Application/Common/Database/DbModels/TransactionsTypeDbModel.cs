namespace MyFinances.Application.Common.Database.DbModels;

public class TransactionsTypeDbModel
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;

	public ICollection<WalletCategoryTransactionDbModel> Transactions { get; set; } = [];
}
