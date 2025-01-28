using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entities;

namespace ServicesConstract.DTO
{
    public class CityAddRequest
    {
        [Required(ErrorMessage = "City Name Can't be blank")]
        [StringLength(50)]
        public string CityName { get; set; }

        public City ToCity()
        {
            return new City { CityName = CityName };
        }
    }
}
