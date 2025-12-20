using MyFinances.Domain.Entities.Finances;

namespace MyFinances.Domain.Entities.Clients;

public class Client
{
	public int Id { get; private set; }
	public string Name { get; private set; } = string.Empty;
	public IEnumerable<Wallet> Wallets { get; private set; } = [];

	private Client() { }

	public static Client Create(int id, string name, IEnumerable<Wallet> wallets)
		=> new()
		{
			Id = id,
			Name = name,
			Wallets = wallets
		};
}
