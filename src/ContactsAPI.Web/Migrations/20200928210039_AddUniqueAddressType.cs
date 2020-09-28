using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactsAPI.Web.Migrations
{
    public partial class AddUniqueAddressType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ContactAddress_ContactId_AddressType",
                table: "ContactAddress",
                columns: new[] { "ContactId", "AddressType" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContactAddress_ContactId_AddressType",
                table: "ContactAddress");
        }
    }
}
