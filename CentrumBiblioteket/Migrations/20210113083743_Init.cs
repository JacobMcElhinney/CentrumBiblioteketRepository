using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentrumBiblioteket.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "BookEditions",
                columns: table => new
                {
                    BookEditionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookTitle = table.Column<string>(nullable: false),
                    YearPublished = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    ISBN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookEditions", x => x.BookEditionId);
                });

            migrationBuilder.CreateTable(
                name: "LibraryCards",
                columns: table => new
                {
                    LibraryCardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryCards", x => x.LibraryCardId);
                });

            migrationBuilder.CreateTable(
                name: "BookCopies",
                columns: table => new
                {
                    BookCopyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Available = table.Column<string>(nullable: false),
                    BookEditionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopies", x => x.BookCopyId);
                    table.ForeignKey(
                        name: "FK_BookCopies_BookEditions_BookEditionId",
                        column: x => x.BookEditionId,
                        principalTable: "BookEditions",
                        principalColumn: "BookEditionId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BookEdition_Authors",
                columns: table => new
                {
                    BookEditionId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookEdition_Authors", x => new { x.BookEditionId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_BookEdition_Authors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookEdition_Authors_BookEditions_BookEditionId",
                        column: x => x.BookEditionId,
                        principalTable: "BookEditions",
                        principalColumn: "BookEditionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookLoans",
                columns: table => new
                {
                    BookLoanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryCardId = table.Column<int>(nullable: false),
                    BookEditionId = table.Column<int>(nullable: false),
                    BookCopyId = table.Column<int>(nullable: false),
                    LoanDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLoans", x => x.BookLoanId);
                    table.ForeignKey(
                        name: "FK_BookLoans_BookCopies_BookCopyId",
                        column: x => x.BookCopyId,
                        principalTable: "BookCopies",
                        principalColumn: "BookCopyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLoans_BookEditions_BookEditionId",
                        column: x => x.BookEditionId,
                        principalTable: "BookEditions",
                        principalColumn: "BookEditionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLoans_LibraryCards_LibraryCardId",
                        column: x => x.LibraryCardId,
                        principalTable: "LibraryCards",
                        principalColumn: "LibraryCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCopies_BookEditionId",
                table: "BookCopies",
                column: "BookEditionId");

            migrationBuilder.CreateIndex(
                name: "IX_BookEdition_Authors_AuthorId",
                table: "BookEdition_Authors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLoans_BookCopyId",
                table: "BookLoans",
                column: "BookCopyId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLoans_BookEditionId",
                table: "BookLoans",
                column: "BookEditionId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLoans_LibraryCardId",
                table: "BookLoans",
                column: "LibraryCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookEdition_Authors");

            migrationBuilder.DropTable(
                name: "BookLoans");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "BookCopies");

            migrationBuilder.DropTable(
                name: "LibraryCards");

            migrationBuilder.DropTable(
                name: "BookEditions");
        }
    }
}
