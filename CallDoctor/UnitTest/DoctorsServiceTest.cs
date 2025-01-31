using Microsoft.EntityFrameworkCore;
using ServiceConstracts;
using ServiceConstracts.DTO;
using Entities;
using Services;
using Xunit.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace UnitTest
{
    public class DoctorsServiceTest
    {
       // private readonly DoctorsDbContext _context;
        private readonly IDoctorsService _doctorsService;
        private readonly ICitiesService _citiesService;
        private readonly ITestOutputHelper _testOutputHelper;
        public DoctorsServiceTest(ITestOutputHelper testOutputHelper)
        {
            _citiesService = new CitiesService(new DoctorsDbContext(new DbContextOptionsBuilder<DoctorsDbContext>().Options));
            _doctorsService = new DoctorsService(new DoctorsDbContext(new DbContextOptionsBuilder<DoctorsDbContext>().Options), _citiesService);
            _testOutputHelper = testOutputHelper;
        }
        #region AddDoctor
        [Fact]
        public async Task AddDoctor_nullDoctor()
        {
            //Arrange
            DoctorAddRequest? doctorAddRequest = null;

            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                // Act
                await _doctorsService.AddDoctor(doctorAddRequest);
            });
            

        }

        [Fact]
        public async Task AddDoctor_nullName()
        {
            //Arrange
            DoctorAddRequest doctorAddRequest = new DoctorAddRequest()
            {
                DoctorName = null,
                CityId = Guid.NewGuid(),
                Specialization = "Childern",
                ExaminationPrice = 150,
                Address = "Elwakf bejuar elajoz",
                PhoneNumber = "01067818771"
            };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await _doctorsService.AddDoctor(doctorAddRequest);
            });
        }

        [Fact]
        public async Task AddDoctor_nullCityId()
        {
            //Arrange
            DoctorAddRequest doctorAddRequest = new DoctorAddRequest()
            {
                DoctorName = "Hassan",
                CityId = null,
                Specialization = "Childern",
                ExaminationPrice = 150,
                Address = "Elwakf bejuar elajoz",
                PhoneNumber = "01067818771"
            };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await _doctorsService.AddDoctor(doctorAddRequest);
            });
        }

        [Fact]
        public async Task AddDoctor_nullPhoneNumber()
        {
            //Arrange
            DoctorAddRequest doctorAddRequest = new DoctorAddRequest()
            {
                DoctorName = "Hassan",
                CityId = Guid.NewGuid(),
                Specialization = "Childern",
                ExaminationPrice = 150,
                Address = "Elwakf bejuar elajoz",
                PhoneNumber = null
            };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await _doctorsService.AddDoctor(doctorAddRequest);
            });
        }

        [Fact]
        public async Task AddDoctor_DuplicateDoctor()
        {
            //Arrange
            DoctorAddRequest doctorAddRequest1 = new DoctorAddRequest()
            {
                DoctorName = "Hassan",
                CityId = Guid.NewGuid(),
                Specialization = "Childern",
                ExaminationPrice = 150,
                Address = "Elwakf bejuar elajoz",
                PhoneNumber = "01067818771"
            };
            DoctorAddRequest doctorAddRequest2 = new DoctorAddRequest()
            {
                DoctorName = "Hassan",
                CityId = Guid.NewGuid(),
                Specialization = "Childern",
                ExaminationPrice = 150,
                Address = "Elwakf bejuar elajoz",
                PhoneNumber = "01067818771"
            };

           await _doctorsService.AddDoctor(doctorAddRequest1);
            //Assert
           /* await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //Act
                await _doctorsService.AddDoctor(doctorAddRequest2);
            });*/
            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await _doctorsService.AddDoctor(doctorAddRequest2);
            });

        }

        [Fact]
        public async Task AddDoctor_ProperDetails()
        {
            DoctorAddRequest doctorAddRequest2 = new DoctorAddRequest()
            {
                DoctorName = "Hassan mohamed",
                CityId = Guid.Parse("d5a458f1-0c2a-4979-8369-79e5cb1eaf8e"),
                Specialization = "Childern",
                ExaminationPrice = 150,
                Address = "Elwakf bejuar elajoz",
                PhoneNumber = "01067818771"
            };
            DoctorResponse doctorResponse = await _doctorsService.AddDoctor(doctorAddRequest2);
            Assert.True(doctorResponse.DoctorId != Guid.Empty);

        }

        #endregion

    }
}