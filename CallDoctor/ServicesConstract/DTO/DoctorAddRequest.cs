using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entities;

namespace ServiceConstracts.DTO
{
    public class DoctorAddRequest
    {
        [Required(ErrorMessage = "Doctor Name can't be blank")]
        [StringLength(40)]
        public string DoctorName { get; set; }

        [Required(ErrorMessage = "Please select a city")]
        public Guid? CityId { get; set; }
        public string? Specialization { get; set; }
        public int? ExaminationPrice { get; set; }
        [DataType(DataType.MultilineText)]
        [StringLength(200)]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Doctor Number can't be blank")]
        public string? PhoneNumber { get; set; }

        public Doctor ToDoctor()
        {
            return new Doctor
            {
                DoctorName = DoctorName,
                CityId = CityId,
                Specialization = Specialization,
                ExaminationPrice = ExaminationPrice,
                Address = Address,
                PhoneNumber = PhoneNumber

            };
        }
    }
}
