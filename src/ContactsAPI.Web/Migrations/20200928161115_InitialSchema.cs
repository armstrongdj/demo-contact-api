using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactsAPI.Web.Migrations
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Line1 = table.Column<string>(maxLength: 100, nullable: true),
                    Line2 = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    State = table.Column<string>(maxLength: 2, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    EmployeeId = table.Column<string>(maxLength: 10, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    CellPhone = table.Column<string>(maxLength: 25, nullable: true),
                    HomePhone = table.Column<string>(maxLength: 25, nullable: true),
                    OfficePhone = table.Column<string>(maxLength: 25, nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    DateOfHire = table.Column<DateTime>(nullable: true),
                    CurrentlyEmployed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactAddress",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    AddressType = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactAddress", x => new { x.ContactId, x.AddressId, x.AddressType });
                    table.ForeignKey(
                        name: "FK_ContactAddress_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactAddress_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactRelationship",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false),
                    RelatedContactId = table.Column<int>(nullable: false),
                    Relationship = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactRelationship", x => new { x.ContactId, x.RelatedContactId });
                    table.ForeignKey(
                        name: "FK_ContactRelationship_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactRelationship_Contacts_RelatedContactId",
                        column: x => x.RelatedContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactAddress_AddressId",
                table: "ContactAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactRelationship_RelatedContactId",
                table: "ContactRelationship",
                column: "RelatedContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_LastName",
                table: "Contacts",
                column: "LastName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactAddress");

            migrationBuilder.DropTable(
                name: "ContactRelationship");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
