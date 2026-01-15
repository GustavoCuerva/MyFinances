using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MyFinances.Application.Common.Database.DbModels;

namespace MyFinances.Application.Common.Database;

public interface IApplicationDbContext
{
	public DatabaseFacade Database { get; }

	public DbSet<WalletDbModel> Wallets { get; set; }
	public DbSet<CategoryDbModel> Categories { get; set; }
	public DbSet<WalletCategoryDbModel> WalletCategories { get; set; }
	public DbSet<WalletCategoryTransactionDbModel> Transactions { get; set; }
	public DbSet<PlannedExpenseDbModel> PlannedExpenses { get; set; }
	public DbSet<InstallmentDbModel> Installments { get; set; }
	public DbSet<AllocationDbModel> Allocations { get; set; }
	public DbSet<ExpenseTypeDbModel> ExpenseTypes { get; set; }
	public DbSet<TransactionsTypeDbModel> TransactionTypes { get; set; }
	public DbSet<UserDbModel> Users { get; set; }

	Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
