using Microsoft.EntityFrameworkCore.Migrations;

namespace VacancyMonolith.Migrations
{
    public partial class addedContactPersonsToVacancyContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_ContactPerson_ContactPersonID",
                table: "Vacancies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactPerson",
                table: "ContactPerson");

            migrationBuilder.RenameTable(
                name: "ContactPerson",
                newName: "ContactPersons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactPersons",
                table: "ContactPersons",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_ContactPersons_ContactPersonID",
                table: "Vacancies",
                column: "ContactPersonID",
                principalTable: "ContactPersons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_ContactPersons_ContactPersonID",
                table: "Vacancies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactPersons",
                table: "ContactPersons");

            migrationBuilder.RenameTable(
                name: "ContactPersons",
                newName: "ContactPerson");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactPerson",
                table: "ContactPerson",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_ContactPerson_ContactPersonID",
                table: "Vacancies",
                column: "ContactPersonID",
                principalTable: "ContactPerson",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
