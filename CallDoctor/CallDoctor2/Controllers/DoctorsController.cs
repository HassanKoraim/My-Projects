using Entities;
using Microsoft.AspNetCore.Mvc;
using Rotativa;
using Rotativa.AspNetCore;
using ServiceConstracts;
using ServiceConstracts.DTO;
using System.Text.Json;

namespace CallDoctor.Controllers
{
    [Route("[controller]")]
    public class DoctorsController : Controller
    {
        private readonly IDoctorsService _doctorsService;

        public DoctorsController(IDoctorsService doctorsService)
        {
            _doctorsService = doctorsService;
        }

        [HttpGet]
        [Route("/")]
        [Route("[action]")]
        public async Task<IActionResult> Index(string searchby, string searchString)
        {
            List<DoctorResponse> matchingDoctors = await _doctorsService.GetFilteredDoctors(searchby, searchString);
            ViewBag.CurrentSearchBy = searchby;
            ViewBag.CurrentSearchString = searchString;
            return View(matchingDoctors);
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
    }
}
