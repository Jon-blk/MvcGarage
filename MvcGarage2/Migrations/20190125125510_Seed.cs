using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcGarage2.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "Brand", "Color", "NumberOfWheels", "RegistrationNumber", "StartTime", "VehicleModel", "VehicleType" },
                values: new object[,]
                {
                    { 1, "Volvo", 0, 4, "ABC123", new DateTime(2019, 1, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), "V70", 0 },
                    { 2, "Volvo", 9, 4, "BCD123", new DateTime(2019, 1, 10, 12, 10, 0, 0, DateTimeKind.Unspecified), "S80", 0 },
                    { 3, "SAAB", 7, 4, "CDE123", new DateTime(2019, 1, 10, 12, 20, 0, 0, DateTimeKind.Unspecified), "900", 0 },
                    { 4, "Yamaha", 0, 2, "ABC001", new DateTime(2019, 1, 10, 12, 30, 0, 0, DateTimeKind.Unspecified), "ZX750", 1 },
                    { 5, "BMW", 9, 2, "ABC002", new DateTime(2019, 1, 10, 12, 40, 0, 0, DateTimeKind.Unspecified), "CC750", 1 },
                    { 6, "BMW", 15, 2, "ABC003", new DateTime(2019, 1, 10, 12, 50, 0, 0, DateTimeKind.Unspecified), "CC900", 1 },
                    { 7, "Scania", 15, 6, "AOO111", new DateTime(2019, 1, 10, 13, 0, 0, 0, DateTimeKind.Unspecified), "1200 KK", 2 },
                    { 8, "Volvo", 12, 6, "AOO222", new DateTime(2019, 1, 10, 13, 10, 0, 0, DateTimeKind.Unspecified), "1200 KK", 2 },
                    { 9, "Mercedes", 15, 4, "AOO333", new DateTime(2019, 1, 10, 13, 20, 0, 0, DateTimeKind.Unspecified), "1200 KK", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
