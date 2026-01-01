using MyFinances.Domain.Entities.Finances;

namespace MyFinances.Domain.Entities.Clients;

public class User
{
	public int Id { get; private set; }
	public string Name { get; private set; } = string.Empty;
	public IEnumerable<Wallet> Wallets { get; private set; } = [];

	private User() { }

	public static User Create(int id, string name, IEnumerable<Wallet> wallets)
		=> new()
		{
			Id = id,
			Name = name,
			Wallets = wallets
		};
}
