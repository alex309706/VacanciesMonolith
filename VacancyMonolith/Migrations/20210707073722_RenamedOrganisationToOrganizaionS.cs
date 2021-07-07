using Microsoft.EntityFrameworkCore.Migrations;

namespace VacancyMonolith.Migrations
{
    public partial class RenamedOrganisationToOrganizaionS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Organization_OrganizationID",
                table: "Vacancies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organization",
                table: "Organization");

            migrationBuilder.RenameTable(
                name: "Organization",
                newName: "Organizations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Organizations_OrganizationID",
                table: "Vacancies",
                column: "OrganizationID",
                principalTable: "Organizations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Organizations_OrganizationID",
                table: "Vacancies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.RenameTable(
                name: "Organizations",
                newName: "Organization");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organization",
                table: "Organization",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Organization_OrganizationID",
                table: "Vacancies",
                column: "OrganizationID",
                principalTable: "Organization",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
