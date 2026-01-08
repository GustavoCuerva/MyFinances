using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinances.Application.Common.Database.DbModels;

namespace MyFinances.Infrastructure.Database.EntitiesConfiguration;

public class InstallmentDbModelConfig : IEntityTypeConfiguration<InstallmentDbModel>
{
	public void Configure(EntityTypeBuilder<InstallmentDbModel> builder)
	{
		builder.ToTable("installments");

		builder.HasKey(i => i.Id);


		builder.HasIndex(i => i.ReferenceCode)
			.IsUnique()
			.HasDatabaseName("UX_Installments_ReferenceCode");

		builder.HasIndex(i => i.PlannedExpenseId)
			.HasDatabaseName("IX_Installments_PlannedExpenseId");

		builder.HasIndex(i => i.DateForPayment)
			.HasDatabaseName("IX_Installments_DateForPayment");


		builder.Property(i => i.ReferenceCode)
			.HasDefaultValueSql("NEWSEQUENTIALID()")
			.ValueGeneratedOnAdd()
			.IsRequired();

		builder.Property(i => i.PlannedExpenseId)
			.IsRequired();

		builder.Property(i => i.InstallmentNumber)
			.IsRequired();

		builder.Property(i => i.DateForPayment)
			.IsRequired();

		builder.Property(i => i.IsPayed)
			.IsRequired();

		builder.Property(i => i.RequiredAmount)
			.IsRequired();

		builder.Property(i => i.ReservedAmount)
			.IsRequired();

		builder.Property(i => i.Responsible)
			.HasMaxLength(200)
			.IsRequired();

		builder.Property(i => i.AllocationId)
			.IsRequired();

		builder.HasOne(i => i.Allocation)
			.WithMany(i => i.Installments)
			.HasForeignKey(i => i.AllocationId)
			.OnDelete(DeleteBehavior.NoAction);

		builder.HasOne(i => i.PlannedExpense)
			.WithMany(p => p.Installments)
			.HasForeignKey(i => i.PlannedExpenseId)
			.OnDelete(DeleteBehavior.NoAction);
	}
}
