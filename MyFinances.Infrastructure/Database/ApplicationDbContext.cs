using Microsoft.EntityFrameworkCore;
using MyFinances.Application.Common.Database.DbModels;
using MyFinances.Infrastructure.Database.EntitiesConfiguration;

namespace MyFinances.Infrastructure.Database;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options) { }

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

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new WalletDbModelConfig());
		
		modelBuilder.ApplyConfiguration(new CategoryDbModelConfig());
		
		modelBuilder.ApplyConfiguration(new WalletCategoryDbModelConfig());

		modelBuilder.ApplyConfiguration(new WalletCategoryTransactionDbModelConfig());
		
		modelBuilder.ApplyConfiguration(new PlannedExpenseDbModelConfig());
		
		modelBuilder.ApplyConfiguration(new InstallmentDbModelConfig());
		
		modelBuilder.ApplyConfiguration(new AllocationDbModelConfig());
		
		modelBuilder.ApplyConfiguration(new ExpenseTypeDbModelConfig());

		modelBuilder.ApplyConfiguration(new TransactionsTypeDbModelConfig());
	}
}