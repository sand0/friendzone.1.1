using Microsoft.EntityFrameworkCore.Migrations;

namespace Friendzone.DAL.Migrations
{
    public partial class addEventProfileRelationship1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_UserProfiles_OwnerUserId",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1f19e427-c04b-4c08-bec3-531044386057", "473a93c4-84c0-413a-826e-f498b7ecb817" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c7f6e739-da8d-4d0d-8ad5-d6d57fedaf5d", "baee7021-de4b-45f6-b189-9db82cc1f1b3" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea41d1bb-8c72-47cc-a3a8-6e02ef2a86e8", "e794f37e-66f5-4181-a49f-82e164aa0444", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3dd19aee-377f-4afb-bc39-7ad1ca688ca4", "4ce28118-28e2-483b-9bb4-e6d4fb73dbd6", "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Events_UserProfiles_OwnerUserId",
                table: "Events",
                column: "OwnerUserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_UserProfiles_OwnerUserId",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "3dd19aee-377f-4afb-bc39-7ad1ca688ca4", "4ce28118-28e2-483b-9bb4-e6d4fb73dbd6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "ea41d1bb-8c72-47cc-a3a8-6e02ef2a86e8", "e794f37e-66f5-4181-a49f-82e164aa0444" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7f6e739-da8d-4d0d-8ad5-d6d57fedaf5d", "baee7021-de4b-45f6-b189-9db82cc1f1b3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1f19e427-c04b-4c08-bec3-531044386057", "473a93c4-84c0-413a-826e-f498b7ecb817", "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Events_UserProfiles_OwnerUserId",
                table: "Events",
                column: "OwnerUserId",
                principalTable: "UserProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
