using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactsAPI.Web.Migrations
{
    public partial class AddUniqueEmployeeIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Contacts_EmployeeId",
                table: "Contacts",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contacts_EmployeeId",
                table: "Contacts");
        }
    }
}
