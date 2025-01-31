using System;
using System.Collections.Generic;
using Entities;

namespace ServiceConstracts.DTO
{
    public class DoctorResponse
    {
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string CityName { get; set; }
        public Guid? CityId { get; set; }
        public string? Specialization { get; set; }
        public int? ExaminationPrice { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
    public static class DoctorExtension
    {
        /// <summary>
        /// An Extensin method that converts an object of Doctor class into DoctorResponse class 
        /// </summary>
        /// <param name="doctor">The Doctor object to convert </param>
        /// <returns>Return the Converted DoctorResponse object</returns>
        public static DoctorResponse? ToDoctorResponse(this Doctor doctor)
        {
            return new DoctorResponse
            {
                DoctorId = doctor.DoctorId,
                DoctorName = doctor.DoctorName,
                CityId = doctor.CityId,
                CityName = doctor.City.CityName,
                Specialization = doctor.Specialization,
                ExaminationPrice = doctor.ExaminationPrice,
                Address = doctor.Address,
                PhoneNumber = doctor.PhoneNumber
            };
        }
    }
}
