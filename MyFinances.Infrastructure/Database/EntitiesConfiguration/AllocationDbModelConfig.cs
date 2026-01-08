using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinances.Application.Common.Database.DbModels;

namespace MyFinances.Infrastructure.Database.EntitiesConfiguration;

public class AllocationDbModelConfig : IEntityTypeConfiguration<AllocationDbModel>
{
	public void Configure(EntityTypeBuilder<AllocationDbModel> builder)
	{
		builder.ToTable("allocations");

		builder.HasKey(a => a.Id);

		builder.Property(a => a.Name)
			.HasMaxLength(50)
			.IsRequired();

		builder.HasMany(a => a.Installments)
			.WithOne(i => i.Allocation)
			.HasForeignKey(i => i.AllocationId);

		builder.HasMany(a => a.Transactions)
			.WithOne(t => t.Allocation)
			.HasForeignKey(t => t.AllocationId);

		builder.HasData
		(
			new AllocationDbModel { Id = 1, Name = "Bank" },
			new AllocationDbModel { Id = 2, Name = "Investment" }
		);
	}
}
