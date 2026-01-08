using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinances.Application.Common.Database.DbModels;

namespace MyFinances.Infrastructure.Database.EntitiesConfiguration;

public class PlannedExpenseDbModelConfig : IEntityTypeConfiguration<PlannedExpenseDbModel>
{
	public void Configure(EntityTypeBuilder<PlannedExpenseDbModel> builder)
	{
		builder.ToTable("planned_expenses");

		builder.HasKey(p => p.Id);

		
		builder.HasIndex(p => p.ReferenceCode)
			.IsUnique()
			.HasDatabaseName("UX_Planned_Expenses_ReferenceCode");

		builder.HasIndex(p => p.Name)
			.HasDatabaseName("IX_Planned_Expenses_Name");

		builder.HasIndex(p => p.Date)
			.HasDatabaseName("IX_Planned_Expenses_Date");

		builder.HasIndex(p => p.TypeId)
			.HasDatabaseName("IX_Planned_Expenses_TypeId");

		builder.HasIndex(p => p.WalletCategoryId)
			.HasDatabaseName("IX_Planned_Expenses_WalletCategoryId");


		builder.Property(p => p.ReferenceCode)
			.HasDefaultValueSql("NEWSEQUENTIALID()")
			.ValueGeneratedOnAdd()
			.IsUnicode()
			.IsRequired();

		builder.Property(p => p.Name)
			.HasMaxLength(255)
			.IsRequired();

		builder.Property(p => p.Description)
			.HasMaxLength(500)
			.IsRequired();

		builder.Property(p => p.Date)
			.HasColumnName("expense_date")
			.IsRequired();

		builder.Property(p => p.TypeId)
			.IsRequired();

		builder.Property(p => p.WalletCategoryId)
			.IsRequired();

		builder.HasOne(p => p.WalletCategory)
			.WithMany(wc => wc.PlannedExpenses)
			.HasForeignKey(p => p.WalletCategoryId)
			.OnDelete(DeleteBehavior.NoAction);

		builder.HasMany(p => p.Installments)
			.WithOne(i => i.PlannedExpense)
			.HasForeignKey(i => i.PlannedExpenseId);

		builder.HasOne(p => p.Type)
			.WithMany(t => t.PlannedExpenses)
			.HasForeignKey(i => i.TypeId)
			.OnDelete(DeleteBehavior.NoAction);
	}
}
