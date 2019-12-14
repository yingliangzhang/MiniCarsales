using Microsoft.EntityFrameworkCore.Migrations;
using MiniCarsales.Models.Constants;
using System;

namespace MiniCarsales.Models.Migrations
{
    public partial class SeedCarsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Cars",
               columns: new[] { "Id", "Type", "Make", "Model", "NumberOfWheels", "NumberOfDoors", "Engine", "BodyType", "CreatedAt", "UpdatedAt" },
               values: new object[] { Guid.NewGuid(), VehicleType.Car, "BMW", "320i", 4, 4, "2.0L", CarBodyType.Sedan, DateTime.Now, DateTime.Now });;

            migrationBuilder.InsertData(
               table: "Cars",
               columns: new[] { "Id", "Type", "Make", "Model", "NumberOfWheels", "NumberOfDoors", "Engine", "BodyType", "CreatedAt", "UpdatedAt" },
               values: new object[] { Guid.NewGuid(), VehicleType.Car, "VW", "Golf", 4, 5, "1.4T", CarBodyType.Hatchback, DateTime.Now, DateTime.Now });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
