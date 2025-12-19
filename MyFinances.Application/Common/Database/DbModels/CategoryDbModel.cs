namespace MyFinances.Application.Common.Database.DbModels;

public class CategoryDbModel
{
	public int Id { get; set; }
	public Guid ReferenceCode { get; set; }
	public int ClientId { get; set; }
	public ClientDbModel Client { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public double Percent {  get; set; }
	public ICollection<WalletCategoryDbModel> CategoryWallets { get; set; }
}
