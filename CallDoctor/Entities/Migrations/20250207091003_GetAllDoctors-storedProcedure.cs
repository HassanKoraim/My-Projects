﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class GetAllDoctorsstoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllDoctors =
                @" CREATE PROCEDURE [dbo].[GetAllDoctors]
                   AS BEGIN
                   SELECT DoctorId, DoctorName, Cities.CityName, Doctors.CityId, Address,
                   PhoneNumber, ExaminationPrice,Specialization
                   FROM [dbo].[Doctors]
                   LEFT JOIN Cities on Doctors.CityId = Cities.CityId;
                   END ";
           migrationBuilder.Sql(sp_GetAllDoctors);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllDoctors =
                @"DROP PROCEDURE [dbo].[GetAllDoctors]";
            migrationBuilder.Sql(sp_GetAllDoctors);
        }
    }
}
