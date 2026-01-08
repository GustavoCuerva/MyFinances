using MyFinances.Domain.Entities.Finances;

namespace MyFinances.Application.Common.Database.DbModels;

public class AllocationDbModel
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;

	public ICollection<InstallmentDbModel> Installments { get; set; } = [];
	public ICollection<WalletCategoryTransactionDbModel> Transactions { get; set; } = [];
}
