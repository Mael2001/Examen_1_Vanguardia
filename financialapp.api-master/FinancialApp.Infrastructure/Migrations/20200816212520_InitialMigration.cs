using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancialApp.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    ConversionRate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountId = table.Column<long>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Amount", "ConversionRate", "Currency", "Name" },
                values: new object[] { -1L, 475.0, 1.0, "USD", "Cuenta en dolares 1" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Amount", "ConversionRate", "Currency", "Name" },
                values: new object[] { -2L, 1500.0, 1.1799999999999999, "EUR", "Cuenta en euros única" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Amount", "ConversionRate", "Currency", "Name" },
                values: new object[] { -3L, 0.0, 1.0, "USD", "Cuenta en dolares 2" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "AccountId", "Amount", "Description", "TransactionDate" },
                values: new object[] { -5L, -1L, 500.0, "Salario", new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "AccountId", "Amount", "Description", "TransactionDate" },
                values: new object[] { -1L, -1L, -20.0, "Comida Dennys", new DateTime(2020, 8, 15, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "AccountId", "Amount", "Description", "TransactionDate" },
                values: new object[] { -3L, -1L, -5.0, "Corte de pelo", new DateTime(2020, 8, 14, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "AccountId", "Amount", "Description", "TransactionDate" },
                values: new object[] { -2L, -2L, 1500.0, "Salario", new DateTime(2020, 8, 16, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AccountId",
                table: "Transaction",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
