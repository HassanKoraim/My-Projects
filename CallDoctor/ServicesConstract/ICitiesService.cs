using ServiceConstracts.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace ServiceConstracts
{
    public interface ICitiesService
    {
        Task<CityResponse> AddCity(CityAddRequest cityAddRequest);
        Task<CityResponse> GetCityById(Guid id);
        Task<List<CityResponse>> GetAllCities();
        Task<int> UploadCitiesFromExcel(IFormFile formFile);
    }
}
