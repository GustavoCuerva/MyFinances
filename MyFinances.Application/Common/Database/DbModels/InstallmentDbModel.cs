namespace MyFinances.Application.Common.Database.DbModels;

public class InstallmentDbModel
{
	public int Id { get; set; }
	public Guid ReferenceCode { get; set; }
	public int PlannedExpenseId { get; set; }
	public PlannedExpenseDbModel PlannedExpense { get; set; }
	public int InstallmentNumber { get; set; }
	public DateTimeOffset DateForPayment { get; set; }
	public bool IsPayed { get; set; }
	public int RequiredAmount { get; set; }
	public int ReservedAmount { get; set; }
	public string Responsible { get; set; } = string.Empty;
}