using Microsoft.EntityFrameworkCore.Migrations;

namespace Friendzone.DAL.Migrations
{
    public partial class addEventProfileRelationship3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                nullable: false,
                defaultValue: "Unname",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "Unname");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "68b46095-fff5-402e-8566-2cc678599cf2", "27020beb-259c-4cd6-ae94-1117f3203928", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f948dd72-6256-4bd5-b7d3-9f0c1979251a", "36e4f573-0c8a-4ad6-b5a0-6e0ebfc83bc6", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "68b46095-fff5-402e-8566-2cc678599cf2", "27020beb-259c-4cd6-ae94-1117f3203928" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "f948dd72-6256-4bd5-b7d3-9f0c1979251a", "36e4f573-0c8a-4ad6-b5a0-6e0ebfc83bc6" });

            migrationBuilder.AlterColumn<string>(
                name: "OwnerUserId",
                table: "Events",
                nullable: true,
                defaultValue: "Unname",
                oldClrType: typeof(string),
                oldDefaultValue: "Unname");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "174901bf-81b2-4705-af9e-6d06ea674a4a", "288ae4c7-eb78-4383-8e96-edc0275f56a6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d2dfccfa-a9f6-49db-82a7-73e7940d4fb2", "78478fa2-8fa0-4462-96c0-99634f318b83", "User", "USER" });
        }
    }
}
