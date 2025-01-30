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
            doctor.CityName = "Ef";
            _db.Doctors.Add(doctor);
            await _db.SaveChangesAsync();
            return doctor.ToDoctorResponse();
        }

        public async Task<bool> DeleteDoctor(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DoctorResponse>> GetAllDoctors()
        {
            List<DoctorResponse> doctorResponses = await _db.Doctors.Include("City")
                .Select(temp => temp.ToDoctorResponse()).ToListAsync();
            return doctorResponses;
        }

        public async Task<DoctorResponse>? GetDoctorById(Guid? DoctorId)
        {
            if(DoctorId == null)
            {
                throw new ArgumentNullException(nameof(DoctorId));
            }
            Doctor? doctor= await _db.Doctors.Include("City")
                .FirstOrDefaultAsync(temp => temp.DoctorId == DoctorId);
            if(doctor == null)
                throw new ArgumentNullException($"This Doctor Not Found");
            DoctorResponse doctorResponse = doctor.ToDoctorResponse();
            return doctorResponse;
        }

        public async Task<List<DoctorResponse>>? GetFilteredDoctors(string? searchBy, string? searchString)
        {
            List<DoctorResponse?> allDoctors = await GetAllDoctors();
            List<DoctorResponse> matchingDoctors = allDoctors;
            if(string.IsNullOrEmpty(searchBy) || string.IsNullOrEmpty(searchString))
                return matchingDoctors;

            matchingDoctors = (searchBy) switch
            {
                (nameof(DoctorResponse.DoctorName)) => allDoctors
                    .Where(
                        temp => !string.IsNullOrEmpty(temp.DoctorName) ?
                        temp.DoctorName.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList(),
                (nameof(DoctorResponse.Specialization)) => allDoctors
                .Where(
                        temp => !string.IsNullOrEmpty(temp.Specialization) ?
                        temp.Specialization.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList(),
                (nameof(DoctorResponse.Address)) => allDoctors
                .Where(
                    temp => !string.IsNullOrEmpty(temp.Address) ?
                    temp.Address.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList(),
                (nameof(DoctorResponse.CityName)) => allDoctors
                .Where(
                        temp => !string.IsNullOrEmpty(temp.CityName) ?
                        temp.CityName.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList(),
                _ => matchingDoctors
            };

            return matchingDoctors;
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
