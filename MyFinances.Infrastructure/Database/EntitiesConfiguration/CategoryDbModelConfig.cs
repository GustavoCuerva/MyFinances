using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinances.Application.Common.Database.DbModels;

namespace MyFinances.Infrastructure.Database.EntitiesConfiguration;

public class CategoryDbModelConfig : IEntityTypeConfiguration<CategoryDbModel>
{
	public void Configure(EntityTypeBuilder<CategoryDbModel> builder)
	{
		builder.ToTable("categories");


		builder.HasIndex(c => c.ReferenceCode)
			.IsUnique()
			.HasDatabaseName("UX_Categories_ReferenceCode");

		builder.HasIndex(c => c.UserId)
			.HasDatabaseName("IX_Categories_UserId");

		builder.HasIndex(c => new { c.UserId, c.Name })
			.IsUnique()
			.HasDatabaseName("UX_Categories_UserId_Name");


		builder.HasKey(x => x.Id);

		builder.Property(c => c.ReferenceCode)
			.HasDefaultValueSql("NEWSEQUENTIALID()")
			.ValueGeneratedOnAdd()
			.IsRequired();

		builder.Property(c => c.UserId)
			.IsRequired();

		builder.Property(c => c.Name)
			.HasMaxLength(250)
			.IsRequired();

		builder.Property(c => c.Description)
			.HasMaxLength(500)
			.IsRequired();

		builder.HasMany(c => c.CategoryWallets)
			.WithOne(cw => cw.Category)
			.HasForeignKey(cw => cw.CategoryId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
