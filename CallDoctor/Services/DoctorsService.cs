using Entities;
using Microsoft.EntityFrameworkCore;
using ServiceConstracts;
using ServiceConstracts.DTO;
using ServiceConstracts.Enums;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DoctorsService : IDoctorsService
    {
        private readonly DoctorsDbContext _db;
        private readonly ICitiesService _citiesService;
        public DoctorsService(DoctorsDbContext doctorsDbContext, ICitiesService citiesService)
        {
            _db = doctorsDbContext;
            _citiesService = citiesService;
        }
        public async Task<DoctorResponse> AddDoctor(DoctorAddRequest? doctorAddRequest)
        {
            if(doctorAddRequest == null)
                throw new ArgumentNullException(nameof(doctorAddRequest));
            
            ValidationHelper.ModelValidation(doctorAddRequest);
            // check for dublicate doctor
            if(await _db.Doctors.Where(doctor => doctor.DoctorName == doctorAddRequest.DoctorName).CountAsync() > 0)
            {
                throw new ArgumentException("Given doctor name is already exists ");
            }

            Doctor doctor = doctorAddRequest.ToDoctor();
            doctor.DoctorId = Guid.NewGuid();
            _db.Doctors.Add(doctor);
            await _db.SaveChangesAsync();
            return doctor.ToDoctorResponse();
        }

        public Task<bool> DeleteDoctor(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DoctorResponse>> GetAllDoctors()
        {
            throw new NotImplementedException();
        }

        public Task<DoctorResponse> GetDoctorById(Guid DoctorId)
        {
            throw new NotImplementedException();
        }

        public Task<List<DoctorResponse>> GetFilteredDoctors(string? searchBy, string? searchString)
        {
            throw new NotImplementedException();
        }

        public Task<List<DoctorResponse>> GetSortedDoctors(List<DoctorResponse> Alldoctors, string? sortBy, SortOrderOptions sortOrder)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDoctor()
        {
            throw new NotImplementedException();
        }
    }
}
