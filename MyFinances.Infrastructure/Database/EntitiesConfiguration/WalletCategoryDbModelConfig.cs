using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinances.Application.Common.Database.DbModels;

namespace MyFinances.Infrastructure.Database.EntitiesConfiguration;

public class WalletCategoryDbModelConfig : IEntityTypeConfiguration<WalletCategoryDbModel>
{
	public void Configure(EntityTypeBuilder<WalletCategoryDbModel> builder)
	{
		builder.ToTable("wallets_categories_join");

		builder.HasKey(wc => wc.Id);

		builder.HasIndex(wc => new { wc.WalletId, wc.CategoryId })
			.IsUnique()
			.HasFilter("[IsActive] = 1")
			.HasDatabaseName("UX_Wallets_Categories_Join_WalletId_CategoryId");

		builder.HasIndex(wc => wc.CategoryId)
			.HasDatabaseName("IX_Wallets_Categories_Join_CategoryId");


		builder.Property(wc => wc.WalletId)
			.IsRequired();

		builder.Property(wc => wc.CategoryId)
			.IsRequired();

		builder.Property(wc => wc.Percent)
			.HasPrecision(5,2)
			.IsRequired();

		builder.Property(wc => wc.CreateAt)
			.HasDefaultValueSql("GETDATE()")
			.ValueGeneratedOnAdd()
			.IsRequired();

		builder.Property(wc => wc.IsActive)
			.HasDefaultValue(true)
			.IsRequired();

		builder.HasOne(wc => wc.Wallet)
			.WithMany(w => w.WalletCategories)
			.HasForeignKey(wc => wc.WalletId)
			.OnDelete(DeleteBehavior.NoAction);

		builder.HasOne(wc => wc.Category)
			.WithMany(c => c.CategoryWallets)
			.HasForeignKey(wc => wc.CategoryId)
			.OnDelete(DeleteBehavior.NoAction);

		builder.HasMany(wc => wc.Transactions)
			.WithOne(t => t.WalletCategory)
			.HasForeignKey(t => t.WalletCategoryId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasMany(wc => wc.PlannedExpenses)
			.WithOne(p => p.WalletCategory)
			.HasForeignKey(p =>  p.WalletCategoryId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
