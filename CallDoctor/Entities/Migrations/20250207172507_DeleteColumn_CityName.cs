using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class DeleteColumn_CityName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityName",
                table: "Doctors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "Doctors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: new Guid("6f9619ff-8b86-d011-b42d-00cf4fc964ff"),
                column: "CityName",
                value: "New York");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: new Guid("98d076c5-6528-4b4f-90d0-d01f5cd3f004"),
                column: "CityName",
                value: "Houston");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: new Guid("9c2e7f52-d3df-4fa3-b646-1dd93b467f94"),
                column: "CityName",
                value: "Los Angeles");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: new Guid("de305d54-75b4-431b-adb2-eb6b9e546013"),
                column: "CityName",
                value: "Chicago");
        }
    }
}
