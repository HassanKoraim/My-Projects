using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class AddDoctor_StoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_AddDoctor = @" CREATE PROCEDURE [dbo].[AddDoctor](
            @DoctorId uniqueidentifier, @DoctorName nvarchar(40),
            @CityId uniqueidentifier, @Specialization nvarchar(100), @ExaminationPrice int,
            @Address nvarchar(max), @PhoneNumber nvarchar(100))
            AS BEGIN
                INSERT INTO [dbo].[Doctors]( DoctorId , DoctorName ,
                CityId , Specialization , ExaminationPrice ,
                Address , PhoneNumber )
                Values (@DoctorId , @DoctorName,
                @CityId, @Specialization , @ExaminationPrice ,
                @Address , @PhoneNumber)
            END";

            migrationBuilder.Sql(sp_AddDoctor);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_AddDoctor = @" DROP PROCEDURE [dbo].[AddDoctor]";
            migrationBuilder.Sql(sp_AddDoctor);
        }
    }
}
