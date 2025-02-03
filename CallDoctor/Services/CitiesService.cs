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

        public async Task<List<CityResponse>> GetAllCities()
        {
            List<CityResponse> cities = _db.Cities.Select(temp => temp.ToCityResponse()).ToList();
            return cities;
        }

        public Task<CityResponse> GetCityById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
