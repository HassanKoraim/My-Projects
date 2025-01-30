using Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceConstracts;
using ServiceConstracts.DTO;

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
    }
}
