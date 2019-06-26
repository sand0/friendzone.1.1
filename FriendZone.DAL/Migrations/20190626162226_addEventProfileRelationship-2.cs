using Microsoft.EntityFrameworkCore.Migrations;

namespace Friendzone.DAL.Migrations
{
    public partial class addEventProfileRelationship2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "3dd19aee-377f-4afb-bc39-7ad1ca688ca4", "4ce28118-28e2-483b-9bb4-e6d4fb73dbd6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "ea41d1bb-8c72-47cc-a3a8-6e02ef2a86e8", "e794f37e-66f5-4181-a49f-82e164aa0444" });

            migrationBuilder.AlterColumn<string>(
                name: "OwnerUserId",
                table: "Events",
                nullable: true,
                defaultValue: "Unname",
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "174901bf-81b2-4705-af9e-6d06ea674a4a", "288ae4c7-eb78-4383-8e96-edc0275f56a6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d2dfccfa-a9f6-49db-82a7-73e7940d4fb2", "78478fa2-8fa0-4462-96c0-99634f318b83", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "174901bf-81b2-4705-af9e-6d06ea674a4a", "288ae4c7-eb78-4383-8e96-edc0275f56a6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "d2dfccfa-a9f6-49db-82a7-73e7940d4fb2", "78478fa2-8fa0-4462-96c0-99634f318b83" });

            migrationBuilder.AlterColumn<string>(
                name: "OwnerUserId",
                table: "Events",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "Unname");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea41d1bb-8c72-47cc-a3a8-6e02ef2a86e8", "e794f37e-66f5-4181-a49f-82e164aa0444", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3dd19aee-377f-4afb-bc39-7ad1ca688ca4", "4ce28118-28e2-483b-9bb4-e6d4fb73dbd6", "User", "USER" });
        }
    }
}
