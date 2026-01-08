using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinances.Application.Common.Database.DbModels;

namespace MyFinances.Infrastructure.Database.EntitiesConfiguration;

public class WalletDbModelConfig : IEntityTypeConfiguration<WalletDbModel>
{
	public void Configure(EntityTypeBuilder<WalletDbModel> builder)
	{
		builder.ToTable("wallets");

		
		builder.HasKey(w => w.Id);

		
		builder.HasIndex(w => w.ReferenceCode)
			.IsUnique()
			.HasDatabaseName("UX_Wallet_ReferenceCode");

		builder.HasIndex(w => w.UserId)
			.HasDatabaseName("IX_Wallet_UserId");

		builder.HasIndex(w => new {w.UserId, w.Name })
			.IsUnique()
			.HasDatabaseName("UX_Wallet_UserId_Name");


		builder.Property(w => w.ReferenceCode)
			.HasDefaultValueSql("NEWSEQUENTIALID()")
			.ValueGeneratedOnAdd()
			.IsRequired();

		builder.Property(w => w.Name)
			.HasMaxLength(150)
			.IsRequired();

		builder.Property(w => w.UserId)
			.IsRequired();

		builder.Property(w => w.Description)
			.HasMaxLength(500)
			.IsRequired();

		builder.Property(w => w.IsActive)
			.HasDefaultValue(true)
			.IsRequired();

		// Relation wallet with user
		builder.HasOne(w => w.User)
			.WithMany(u => u.Wallets)
			.HasForeignKey(w => w.UserId)
			.OnDelete(DeleteBehavior.NoAction);

		// Relation wallet with walletCategories (Join table)
		builder.HasMany(w => w.WalletCategories)
			.WithOne(w => w.Wallet)
			.HasForeignKey(w => w.WalletId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
