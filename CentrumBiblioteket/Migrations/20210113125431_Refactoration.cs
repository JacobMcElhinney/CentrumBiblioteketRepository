using Microsoft.EntityFrameworkCore.Migrations;

namespace CentrumBiblioteket.Migrations
{
    public partial class Refactoration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookLoans_BookEditions_BookEditionId",
                table: "BookLoans");

            migrationBuilder.DropIndex(
                name: "IX_BookLoans_BookEditionId",
                table: "BookLoans");

            migrationBuilder.DropColumn(
                name: "BookEditionId",
                table: "BookLoans");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookEditionId",
                table: "BookLoans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookLoans_BookEditionId",
                table: "BookLoans",
                column: "BookEditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookLoans_BookEditions_BookEditionId",
                table: "BookLoans",
                column: "BookEditionId",
                principalTable: "BookEditions",
                principalColumn: "BookEditionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
