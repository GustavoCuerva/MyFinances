namespace MyFinances.Application.Common.Database.DbModels;

public class UserDbModel
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public ICollection<WalletDbModel> Wallets { get; set; } = [];
}
