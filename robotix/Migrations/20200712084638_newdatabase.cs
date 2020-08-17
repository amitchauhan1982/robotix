using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace robotix.Migrations
{
    public partial class newdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    LastLoginDate = table.Column<DateTime>(nullable: true),
                    userrole = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cmspages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Rank = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cmspages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "Id", "CreatedDate", "LastLoginDate", "Password", "Username", "userrole" },
                values: new object[] { 1, new DateTime(2020, 7, 12, 8, 46, 37, 914, DateTimeKind.Utc).AddTicks(4618), new DateTime(2020, 7, 12, 8, 46, 37, 914, DateTimeKind.Utc).AddTicks(6213), "123456", "manager", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "cmspages");
        }
    }
}
