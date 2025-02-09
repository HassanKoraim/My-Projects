 CREATE PROCEDURE [dbo].[GetAllDoctors]
                   AS BEGIN
                   SELECT DoctorId, DoctorName, Cities.CityName, Doctors.CityId, Address,
                   PhoneNumber, ExaminationPrice,Specialization
                   FROM [dbo].[Doctors]
				   Left Join Cities On Doctors.CityId = Cities.CityId
                   END