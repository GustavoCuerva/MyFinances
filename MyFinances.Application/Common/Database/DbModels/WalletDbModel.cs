namespace MyFinances.Application.Common.Database.DbModels;

public class WalletDbModel
{
	public int Id { get; set; }
	public Guid ReferenceCode { get; set; }
	public int UserId { get; set; }
	public UserDbModel User { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Description {  get; set; } = string.Empty;
	public bool IsActive { get; set; }
	public ICollection<WalletCategoryDbModel> WalletCategories { get; set; } = [];
}
