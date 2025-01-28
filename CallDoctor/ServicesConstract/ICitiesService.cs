using ServicesConstract.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesConstract
{
    public interface ICitiesService
    {
        Task<CityResponse> AddCity(CityAddRequest cityAddRequest);
        Task<CityResponse> GetCityById(Guid id);
        Task<List<CityResponse>> GetAllCities();
    }
}
