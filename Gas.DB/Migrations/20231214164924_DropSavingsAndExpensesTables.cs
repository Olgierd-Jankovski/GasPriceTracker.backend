using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gas.DB.Migrations
{
    /// <inheritdoc />
    public partial class DropSavingsAndExpensesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
        name: "Savings");

            migrationBuilder.DropTable(
                name: "Expenses");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
