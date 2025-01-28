using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class IntailCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ExaminationPrice = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_Doctors_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName" },
                values: new object[,]
                {
                    { new Guid("74a72b9b-b0b8-487b-86d8-d1ad8b3ecb73"), "Houston" },
                    { new Guid("ad7a5e2b-79ef-4237-b3ad-3f1e31f24a6f"), "Los Angeles" },
                    { new Guid("c9b9e1dc-ded7-4a11-bdf4-37251f1d4ae1"), "Chicago" },
                    { new Guid("d5a458f1-0c2a-4979-8369-79e5cb1eaf8e"), "New York" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "Address", "CityId", "CityName", "DoctorName", "ExaminationPrice", "PhoneNumber", "Specialization" },
                values: new object[,]
                {
                    { new Guid("6f9619ff-8b86-d011-b42d-00cf4fc964ff"), "123 Main Street, New York, NY 10001", new Guid("d5a458f1-0c2a-4979-8369-79e5cb1eaf8e"), "New York", "Dr. John Smith", 150, "+1-555-123-4567", "Cardiologist" },
                    { new Guid("98d076c5-6528-4b4f-90d0-d01f5cd3f004"), "321 Lone Star Rd, Houston, TX 77002", new Guid("74a72b9b-b0b8-487b-86d8-d1ad8b3ecb73"), "Houston", "Dr. Michael Brown", 180, "010000", "Pediatrician" },
                    { new Guid("9c2e7f52-d3df-4fa3-b646-1dd93b467f94"), "456 Sunset Blvd, Los Angeles, CA 90028", new Guid("ad7a5e2b-79ef-4237-b3ad-3f1e31f24a6f"), "Los Angeles", "Dr. Emily Davis", 200, "+1-555-654-3210", "Dermatologist" },
                    { new Guid("de305d54-75b4-431b-adb2-eb6b9e546013"), "789 Windy City Ave, Chicago, IL 60616", new Guid("c9b9e1dc-ded7-4a11-bdf4-37251f1d4ae1"), "Chicago", "Dr. Sarah Johnson", 250, "+1-555-987-6543", "Neurologist" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CityId",
                table: "Doctors",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
