using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinances.Application.Common.Database.DbModels;

namespace MyFinances.Infrastructure.Database.EntitiesConfiguration;

public class ExpenseTypeDbModelConfig : IEntityTypeConfiguration<ExpenseTypeDbModel>
{
	public void Configure(EntityTypeBuilder<ExpenseTypeDbModel> builder)
	{
		builder.ToTable("expense_types");

		builder.HasKey(e => e.Id);

		builder.Property(e => e.Name)
			.HasMaxLength(50)
			.IsRequired();

		builder.HasMany(e => e.PlannedExpenses)
			.WithOne(p => p.Type)
			.HasForeignKey(p => p.TypeId);

		builder.HasData
		(
			new ExpenseTypeDbModel { Id = 1, Name = "Appelant"},
			new ExpenseTypeDbModel { Id = 2, Name = "Sporadic"}
		);
	}
}
