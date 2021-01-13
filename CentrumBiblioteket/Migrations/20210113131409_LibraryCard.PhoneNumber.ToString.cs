using Microsoft.EntityFrameworkCore.Migrations;

namespace CentrumBiblioteket.Migrations
{
    public partial class LibraryCardPhoneNumberToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "LibraryCards",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "LibraryCards",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
