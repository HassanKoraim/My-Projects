using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Rotativa;
using Rotativa.AspNetCore;
using ServiceConstracts;
using ServiceConstracts.DTO;
using ServiceConstracts.Enums;
using System.Text.Json;

namespace CallDoctor.Controllers
{
    [Route("[controller]")]
    public class DoctorsController : Controller
    {
        private readonly IDoctorsService _doctorsService;
        private readonly ICitiesService _citiesService;
        public DoctorsController(IDoctorsService doctorsService, ICitiesService citiesService)
        {
            _doctorsService = doctorsService;
            _citiesService = citiesService;
        }

        [HttpGet]
        [Route("/")]
        [Route("[action]")]
        public async Task<IActionResult> Index(string searchby, string searchString, string sortBy = nameof(DoctorResponse.DoctorName) , SortOrderOptions sortOrder = SortOrderOptions.Asc)
        {
            ViewBag.SearchFields = new Dictionary<string, string>()
            {
                {nameof(DoctorResponse.DoctorName),"DoctorName" },
                {nameof(DoctorResponse.CityName),"CityName" },
                {nameof(DoctorResponse.Address),"Address" },
                {nameof(DoctorResponse.Specialization),"Specialization" },
            };
            List<DoctorResponse> matchingDoctors = await _doctorsService.GetFilteredDoctors(searchby, searchString);
            ViewBag.CurrentSearchBy = searchby;
            ViewBag.CurrentSearchString = searchString;

            List<DoctorResponse> sortedDoctors = await _doctorsService.GetSortedDoctors(matchingDoctors, sortBy, sortOrder);
            ViewBag.CurrentSortBy = sortBy;
            ViewBag.CurrentSortOrder = sortOrder;

            return View(sortedDoctors);
        }

        [Route("[action]")]
        public async Task<IActionResult> DoctorsPdf(string doctorsList)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var doctors = JsonSerializer.Deserialize<List<DoctorResponse>>(doctorsList,options);

            return new ViewAsPdf("DoctorsPdf", doctors, ViewData)
            {
                PageMargins = new Rotativa.AspNetCore.Options.Margins()
                {
                    Left = 20,
                    Right = 20,
                    Top = 20,
                    Bottom = 20
                },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Create()
        {
            List<CityResponse> cities = await _citiesService.GetAllCities();
            ViewBag.cities = cities;
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(DoctorAddRequest? doctorAddRequest)
        {
            DoctorResponse doctorRespose = await _doctorsService.AddDoctor(doctorAddRequest);
            return RedirectToAction("Index" , "Doctors");
        }

       

    }
}
