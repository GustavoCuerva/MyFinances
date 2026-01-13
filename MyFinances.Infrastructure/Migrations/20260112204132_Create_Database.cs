using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyFinances.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "allocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_allocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "expense_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expense_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "transactions_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wallets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "wallets_categories_join",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WalletId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Percent = table.Column<double>(type: "float(5)", precision: 5, scale: 2, nullable: false),
                    CreateAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wallets_categories_join", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wallets_categories_join_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_wallets_categories_join_wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "wallets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "planned_expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    expense_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    WalletCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planned_expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_planned_expenses_expense_types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "expense_types",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_planned_expenses_wallets_categories_join_WalletCategoryId",
                        column: x => x.WalletCategoryId,
                        principalTable: "wallets_categories_join",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    WalletCategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false),
                    AllocationId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transactions_allocations_AllocationId",
                        column: x => x.AllocationId,
                        principalTable: "allocations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_transactions_transactions_type_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "transactions_type",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_transactions_wallets_categories_join_WalletCategoryId",
                        column: x => x.WalletCategoryId,
                        principalTable: "wallets_categories_join",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "installments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    PlannedExpenseId = table.Column<int>(type: "int", nullable: false),
                    InstallmentNumber = table.Column<int>(type: "int", nullable: false),
                    DateForPayment = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsPayed = table.Column<bool>(type: "bit", nullable: false),
                    RequiredAmount = table.Column<int>(type: "int", nullable: false),
                    ReservedAmount = table.Column<int>(type: "int", nullable: false),
                    AllocationId = table.Column<int>(type: "int", nullable: false),
                    Responsible = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_installments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_installments_allocations_AllocationId",
                        column: x => x.AllocationId,
                        principalTable: "allocations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_installments_planned_expenses_PlannedExpenseId",
                        column: x => x.PlannedExpenseId,
                        principalTable: "planned_expenses",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "allocations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bank" },
                    { 2, "Investment" }
                });

            migrationBuilder.InsertData(
                table: "expense_types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Appelant" },
                    { 2, "Sporadic" }
                });

            migrationBuilder.InsertData(
                table: "transactions_type",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Icome" },
                    { 2, "Expense" },
                    { 3, "Transfer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserId",
                table: "categories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UX_Categories_ReferenceCode",
                table: "categories",
                column: "ReferenceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Categories_UserId_Name",
                table: "categories",
                columns: new[] { "UserId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_installments_AllocationId",
                table: "installments",
                column: "AllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Installments_DateForPayment",
                table: "installments",
                column: "DateForPayment");

            migrationBuilder.CreateIndex(
                name: "IX_Installments_PlannedExpenseId",
                table: "installments",
                column: "PlannedExpenseId");

            migrationBuilder.CreateIndex(
                name: "UX_Installments_ReferenceCode",
                table: "installments",
                column: "ReferenceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Planned_Expenses_Date",
                table: "planned_expenses",
                column: "expense_date");

            migrationBuilder.CreateIndex(
                name: "IX_Planned_Expenses_Name",
                table: "planned_expenses",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Planned_Expenses_TypeId",
                table: "planned_expenses",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Planned_Expenses_WalletCategoryId",
                table: "planned_expenses",
                column: "WalletCategoryId");

            migrationBuilder.CreateIndex(
                name: "UX_Planned_Expenses_ReferenceCode",
                table: "planned_expenses",
                column: "ReferenceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AllocationId",
                table: "transactions",
                column: "AllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Amount",
                table: "transactions",
                column: "Amount");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Date",
                table: "transactions",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TypeId",
                table: "transactions",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_WalletCategoryId",
                table: "transactions",
                column: "WalletCategoryId");

            migrationBuilder.CreateIndex(
                name: "UX_Transactions_ReferenceCode",
                table: "transactions",
                column: "ReferenceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_UserId",
                table: "wallets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UX_Wallet_ReferenceCode",
                table: "wallets",
                column: "ReferenceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Wallet_UserId_Name",
                table: "wallets",
                columns: new[] { "UserId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_Categories_Join_CategoryId",
                table: "wallets_categories_join",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "UX_Wallets_Categories_Join_WalletId_CategoryId",
                table: "wallets_categories_join",
                columns: new[] { "WalletId", "CategoryId" },
                unique: true,
                filter: "[IsActive] = 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "installments");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "planned_expenses");

            migrationBuilder.DropTable(
                name: "allocations");

            migrationBuilder.DropTable(
                name: "transactions_type");

            migrationBuilder.DropTable(
                name: "expense_types");

            migrationBuilder.DropTable(
                name: "wallets_categories_join");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "wallets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
