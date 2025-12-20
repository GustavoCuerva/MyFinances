using MyFinances.Common.Result;
using MyFinances.Domain.Enums;
using MyFinances.Domain.ErrorList;

namespace MyFinances.Domain.Entities.Finances;

public class Installment
{
	public int Id { get; private set; }
	public int InstallmentNumber { get; private set; }
	public DateTimeOffset DateForPayment { get; private set; }
	public bool IsPayed { get; private set; }
	public int RequiredAmount { get; private set; }
	public int ReservedAmount { get; private set; }
	public string Responsible { get; private set; } = string.Empty;
	public PlannedExpenseStatus StatusReserved 
		=> ReservedAmount >= ReservedAmount ? PlannedExpenseStatus.Full
							: ReservedAmount > 0 ? PlannedExpenseStatus.Partial
							: PlannedExpenseStatus.None;

	private Installment() { }

	public static Result<Installment> Create(int installmentNumber, DateTimeOffset dateForPayment, int requiredAmount, int reservedAmount, string responsible){

		if (requiredAmount < 1)
			return Errors.Installment.RequiredAmountIsSmaller1();

		if (reservedAmount < 0)
			return Errors.Installment.ReservedAmountIsSmaller0();

		return new Installment()
		{
			InstallmentNumber = installmentNumber,
			DateForPayment = dateForPayment,
			RequiredAmount = requiredAmount,
			ReservedAmount = reservedAmount,
			Responsible = responsible
		};
	}
}
