using Entities;
using Microsoft.AspNetCore.Mvc;
using ServicesConstract;

namespace CallDoctor.Controllers
{
    [Route("[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsService _doctorsService;

        public DoctorsController(IDoctorsService doctorsService)
        {
            _doctorsService = doctorsService;
        }

        [HttpGet]
        public IActionResult GetAllDoctors()
        {
            var doctors = _doctorsService.GetAllDoctors();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctorById(Guid id)
        {
            var doctor = _doctorsService.GetDoctorById(id);
            if (doctor == null)
                return NotFound();
            return Ok(doctor);
        }

    }
}
