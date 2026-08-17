namespace MyFinances.Application.Common.Database.DbModels;

public sealed class AuthCredentialsDbModel
{
	public Guid ClientId { get; set; }
	public required byte[] ClientSecret {  get; set; }
	public required byte[] ClientSecretSalt { get; set; }
	public int UserId { get; set; }
	public UserDbModel? User { get; set; }
}
