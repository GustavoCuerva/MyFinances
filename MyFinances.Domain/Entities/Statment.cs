namespace MyFinances.Domain.Entities;

public class Statment
{
	public int Id { get; private set; }
	public int Balance { get; private set; }
	public string Descripton { get; private set; } = string.Empty;
	public DateTimeOffset Date { get; private set; }
	public Wallet Wallet { get; private set; }
	public Category Category { get; private set; }
	public PlannedExpense PlannedExpense { get; private set; }
	public int PreviusAmountCategoryWallet { get; private set; }
	public int BeforeAmountCategoryWallet { get; set; }
}
