using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OfficeOpenXml;
using ServiceConstracts;
using ServiceConstracts.DTO;
using Services.Helpers;
using System.ComponentModel;

namespace Services
{
    public class CitiesService : ICitiesService
    {
        private readonly DoctorsDbContext _db;

        public CitiesService(DoctorsDbContext doctorsDbContext)
        {
            _db = doctorsDbContext;
        }
        public async Task<CityResponse>? AddCity(CityAddRequest? cityAddRequest)
        {
           if(cityAddRequest == null) throw new ArgumentNullException(nameof(cityAddRequest));
           ValidationHelper.ModelValidation(cityAddRequest);
           if(_db.Cities.Where(temp => temp.CityName == cityAddRequest.CityName).Count()> 0)
            {
                throw new ArgumentException("The given City is already exists");
            }
           City city = new City() { CityName = cityAddRequest.CityName , CityId = Guid.NewGuid()};
           _db.Cities.Add(city);
           await _db.SaveChangesAsync();
           return city.ToCityResponse();
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

        public async Task<int> UploadCitiesFromExcel(IFormFile formFile)
        {
            MemoryStream stream = new MemoryStream();
            await formFile.CopyToAsync(stream);
            int citiesInserted = 0;
            using(ExcelPackage excelPackage = new ExcelPackage(stream))
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets["Cities"];
                int rowNumber = excelWorksheet.Dimension.Rows;
                for(int i = 2; i <= rowNumber; i++)
                {
                    string? cellValue = Convert.ToString(excelWorksheet.Cells[rowNumber, 1].Value);
                    if (!string.IsNullOrEmpty(cellValue))
                    {
                        string cityName = cellValue;
                        if (_db.Cities.Where(temp => temp.CityName == cityName).Count() == 0)
                        {
                            CityAddRequest cityAddRequest = new CityAddRequest() { CityName = cityName };
                            await AddCity(cityAddRequest);
                            citiesInserted++;
                        }
                    }
                }
            }
            return citiesInserted;
        }
    }
}
