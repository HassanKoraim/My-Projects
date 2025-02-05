using Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceConstracts;

namespace CallDoctor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitiesController : Controller
    {
        private readonly ICitiesService _citiesService;

        public CitiesController(ICitiesService citiesService)
        {
            _citiesService = citiesService;
        }

        [HttpGet]
        public IActionResult GetAllCities()
        {
            var cities = _citiesService.GetAllCities();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCityById(Guid id)
        {
            var city = _citiesService.GetCityById(id);
            if (city == null)
                return NotFound();
            return Ok(city);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> UploadCitiesFromExcel()
        {
            return View();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UploadCitiesFromExcel(IFormFile formFile)
        {
            if(formFile == null || formFile.Length == 0)
            {
                ViewBag.ErrorMessage = "Please an xlsx File";
            }
            if (!Path.GetExtension(formFile.FileName).Equals(".xlxs", StringComparison.OrdinalIgnoreCase))
            {
                ViewBag.ErrorMessage = "Unsupported file. 'xlsx' is expected";
                return View();
            }
            ViewBag.CitiesInsertes = await _citiesService.UploadCitiesFromExcel(formFile);
            ViewBag.Message = $"{@ViewBag.CitiesInsertes} Cities Inserted Sucessfully";
            return View();
        }

    }
}
