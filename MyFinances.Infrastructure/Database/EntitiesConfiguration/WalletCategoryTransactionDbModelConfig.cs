using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinances.Application.Common.Database.DbModels;

namespace MyFinances.Infrastructure.Database.EntitiesConfiguration;

public class WalletCategoryTransactionDbModelConfig : IEntityTypeConfiguration<WalletCategoryTransactionDbModel>
{
	public void Configure(EntityTypeBuilder<WalletCategoryTransactionDbModel> builder)
	{
		builder.ToTable("transactions");

		builder.HasKey(t => t.Id);

		
		builder.HasIndex(t => t.ReferenceCode)
			.IsUnique()
			.HasDatabaseName("UX_Transactions_ReferenceCode");

		builder.HasIndex(t => t.WalletCategoryId)
			.HasDatabaseName("IX_Transactions_WalletCategoryId");

		builder.HasIndex(t => t.Amount)
			.HasDatabaseName("IX_Transactions_Amount");

		builder.HasIndex(t => t.TransactionTypeId)
			.HasDatabaseName("IX_Transactions_TypeId");

		builder.HasIndex(t => t.Date)
			.HasDatabaseName("IX_Transactions_Date");

		builder.HasIndex(t => t.AllocationId)
			.HasDatabaseName("IX_Transactions_AllocationId");


		builder.Property(t => t.ReferenceCode)
			.HasDefaultValueSql("NEWSEQUENTIALID()")
			.ValueGeneratedOnAdd()
			.IsRequired();

		builder.Property(t => t.WalletCategoryId)
			.IsRequired();

		builder.Property(t => t.Description)
			.HasMaxLength(500)
			.IsRequired();

		builder.Property(t => t.Amount)
			.IsRequired();

		builder.Property(t => t.TransactionTypeId)
			.IsRequired();

		builder.Property(t => t.Date)
			.HasDefaultValueSql("GETDATE()")
			.IsRequired();

		builder.Property(t => t.AllocationId)
			.IsRequired();

		builder.HasOne(t => t.Allocation)
			.WithMany(a => a.Transactions)
			.HasForeignKey(t => t.AllocationId)
			.OnDelete(DeleteBehavior.NoAction);

		builder.HasOne(t => t.WalletCategory)
			.WithMany(wc => wc.Transactions)
			.HasForeignKey(t => t.WalletCategoryId)
			.OnDelete(DeleteBehavior.NoAction);

		builder.HasOne(t => t.TransactionType)
			.WithMany(t => t.Transactions)
			.HasForeignKey(t => t.TransactionTypeId)
			.OnDelete(DeleteBehavior.NoAction);
	}
}
