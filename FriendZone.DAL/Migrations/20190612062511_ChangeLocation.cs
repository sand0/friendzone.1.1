using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Friendzone.DAL.Migrations
{
    public partial class ChangeLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Locations_LocationId",
                table: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "0c5d19ff-1054-4772-9e95-6c891cbcd479", "7fa5991b-e5ff-4e76-90c5-d6752e5c8171" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "0d9dddd8-4bbe-46ad-8bc5-79f5f622fe40", "56c76ea9-83ad-4520-bfcd-0c1999166498" });

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "UserProfiles",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfiles_LocationId",
                table: "UserProfiles",
                newName: "IX_UserProfiles_CityId");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Events",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_LocationId",
                table: "Events",
                newName: "IX_Events_CityId");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a9b730a-ece4-466b-9104-978d2ddfee8c", "38be9f81-4d80-4ca5-9fe4-7a8001edc1d8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f2079b6c-d3fc-41cf-86c3-086d657ca2d3", "150fa8c9-bd67-42bb-9091-18793f67eb81", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Cities_CityId",
                table: "Events",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Cities_CityId",
                table: "UserProfiles",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Cities_CityId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Cities_CityId",
                table: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "7a9b730a-ece4-466b-9104-978d2ddfee8c", "38be9f81-4d80-4ca5-9fe4-7a8001edc1d8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "f2079b6c-d3fc-41cf-86c3-086d657ca2d3", "150fa8c9-bd67-42bb-9091-18793f67eb81" });

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "UserProfiles",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfiles_CityId",
                table: "UserProfiles",
                newName: "IX_UserProfiles_LocationId");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Events",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_CityId",
                table: "Events",
                newName: "IX_Events_LocationId");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c5d19ff-1054-4772-9e95-6c891cbcd479", "7fa5991b-e5ff-4e76-90c5-d6752e5c8171", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d9dddd8-4bbe-46ad-8bc5-79f5f622fe40", "56c76ea9-83ad-4520-bfcd-0c1999166498", "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Locations_LocationId",
                table: "UserProfiles",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
