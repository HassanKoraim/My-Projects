using Entities;
using Microsoft.AspNetCore.Mvc;
using ServicesConstract;

namespace CallDoctor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitiesController : ControllerBase
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

        
    }
}
