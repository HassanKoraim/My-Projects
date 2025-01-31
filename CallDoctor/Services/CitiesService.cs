using Entities;
using ServiceConstracts;
using ServiceConstracts.DTO;

namespace Services
{
    public class CitiesService : ICitiesService
    {
        private readonly DoctorsDbContext _db;

        public CitiesService(DoctorsDbContext doctorsDbContext)
        {
            _db = doctorsDbContext;
        }
        public Task<CityResponse> AddCity(CityAddRequest cityAddRequest)
        {
            throw new NotImplementedException();
        }

        public Task<List<CityResponse>> GetAllCities()
        {
            throw new NotImplementedException();
        }

        public Task<CityResponse> GetCityById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
