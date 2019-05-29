using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcEmlak.Migrations
{
    public partial class EmlakCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emlak",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Il = table.Column<string>(nullable: true),
                    Ilce = table.Column<string>(nullable: true),
                    Mahalle = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    IlanTarihi = table.Column<DateTime>(nullable: false),
                    Photo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emlak", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emlak");
        }
    }
}
