using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCMS.Migrations
{
    /// <inheritdoc />
    public partial class HeadCategory_AccountingHead_transaction_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountingHeads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountingHeadId = table.Column<int>(type: "int", nullable: false),
                    AccountingHeadName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHeadActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingHeads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeadCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeadCategoryId = table.Column<int>(type: "int", nullable: false),
                    HeadCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadCategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHeadCategoryActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountingHeadId = table.Column<int>(type: "int", nullable: false),
                    IncomeFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ExpenseFor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    TransactionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountingHeads");

            migrationBuilder.DropTable(
                name: "HeadCategories");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
