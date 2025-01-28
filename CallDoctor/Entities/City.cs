using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class City
    {
        [Key]
        public Guid CityId { get; set; }
        public string? CityName { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
