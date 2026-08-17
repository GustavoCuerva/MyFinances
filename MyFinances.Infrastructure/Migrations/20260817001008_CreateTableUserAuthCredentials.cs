using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFinances.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableUserAuthCredentials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_auth_credentials",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ClientSecret = table.Column<byte[]>(type: "varbinary(900)", nullable: false),
                    ClientSecretSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_auth_credentials", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_user_auth_credentials_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_auth_credentials_UserId",
                table: "user_auth_credentials",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Auth_Credentials_ClientId_ClientSecret",
                table: "user_auth_credentials",
                columns: new[] { "ClientId", "ClientSecret" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_auth_credentials");
        }
    }
}
