using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinances.Application.Common.Database.DbModels;

namespace MyFinances.Infrastructure.Database.EntitiesConfiguration;

public class TransactionsTypeDbModelConfig : IEntityTypeConfiguration<TransactionsTypeDbModel>
{
	public void Configure(EntityTypeBuilder<TransactionsTypeDbModel> builder)
	{
		builder.ToTable("transactions_type");

		builder.HasKey(t => t.Id);

		builder.Property(t => t.Name)
			.HasMaxLength(50)
			.IsRequired();

		builder.HasMany(t => t.Transactions)
			.WithOne(t => t.TransactionType)
			.HasForeignKey(t => t.TransactionTypeId)
			.OnDelete(DeleteBehavior.NoAction);

		builder.HasData
		(
			new TransactionsTypeDbModel { Id = 1, Name = "Icome" },
			new TransactionsTypeDbModel { Id = 2, Name = "Expense" },
			new TransactionsTypeDbModel { Id = 3, Name = "Transfer" }
		);
	}
}
