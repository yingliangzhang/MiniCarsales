using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniCarsales.Models.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAT = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(maxLength: 30, nullable: false),
                    Make = table.Column<string>(maxLength: 60, nullable: false),
                    Model = table.Column<string>(maxLength: 60, nullable: false),
                    NumberOfWheels = table.Column<int>(nullable: false),
                    NumberOfDoors = table.Column<int>(nullable: false),
                    Engine = table.Column<string>(nullable: false),
                    BodyType = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
