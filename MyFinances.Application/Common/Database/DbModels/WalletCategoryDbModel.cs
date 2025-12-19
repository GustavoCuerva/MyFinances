namespace MyFinances.Application.Common.Database.DbModels;

public class WalletCategoryDbModel
{
	public int Id { get; set; }
	public int WalletId { get; set; }
	public WalletDbModel Wallet { get; set; }
	public int CategoryId { get; set; }
	public CategoryDbModel Category {  get; set; }
	public ICollection<WalletCategoryTransactionDbModel> Transactions { get; set; } = [];
	public ICollection<PlannedExpenseDbModel> PlannedExpenses { get; set; } = [];
}
/*
Well, I think this scenario: 
I've the table Wallets:
	Id, Name, Description
I've the table Categories:
	Id, Name, Description
I've the table WalletCategories:
	Id, WalletId, CategoryId, Percent
I've the table FreeAmount (Need a better name):
	Id, WalletCategoryId, Amount, AllocationId
I've the table Allocation
	Id, Name (Has thow registers default - Bank, Invest)
I've the table PlannedExpense
	Id, Description, Date, WalletCategoryId, Type (Currenc or not)
I've the table Instalments
	Id, InstalmentNumber, PlannedExpenseId, RequiredAmount, ReservedAmount, DateForPayment, Status (Paied, Reserved, Pendente)
*/