using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinances.Application.Common.Database.DbModels;

namespace MyFinances.Infrastructure.Database.EntitiesConfiguration;

public class AuthCredentialsDbModelConfig : IEntityTypeConfiguration<AuthCredentialsDbModel>
{
	public void Configure(EntityTypeBuilder<AuthCredentialsDbModel> builder)
	{
		builder.ToTable("user_auth_credentials");

		builder.HasIndex(c => new { c.ClientId, c.ClientSecret })
			.IsUnique()
			.HasDatabaseName("UX_Auth_Credentials_ClientId_ClientSecret");

		builder.HasKey(c => c.ClientId);

		builder.Property(c => c.ClientId)
			.HasDefaultValueSql("NEWSEQUENTIALID()")
			.ValueGeneratedOnAdd()
			.IsRequired();

		builder.Property(c => c.ClientSecret)
			.IsRequired();

		builder.Property(c => c.ClientSecretSalt)
			.IsRequired();

		builder.Property(c => c.UserId)
			.IsRequired();

		builder.HasOne(c => c.User)
			.WithOne(u => u.Credentials);
	}
}
