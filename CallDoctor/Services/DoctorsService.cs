using Entities;
using ServicesConstract;
using ServicesConstract.DTO;
using ServicesConstract.Enums;
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
        public Task<DoctorResponse> AddDoctor(DoctorAddRequest doctorAddRequest)
        {
            throw new NotImplementedException();
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
