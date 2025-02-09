using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace Entities
{
    public class Doctor
    {
        [Required (ErrorMessage ="Doctor Id can't be blank")]
        [Key]
        public Guid DoctorId { get; set; }
        [Required (ErrorMessage ="Doctor Name can't be blank")]
        [StringLength (40)]
        public string DoctorName { get; set; }

/*        [StringLength(100)]
        public string? CityName { get; set; }*/
        public Guid? CityId { get; set; }
        [StringLength(100)]
        public string? Specialization { get; set; }
        public int? ExaminationPrice { get; set; }   
        public string? Address { get; set; }
        [Required(ErrorMessage ="Doctor Number can't be blank")]
        public string? PhoneNumber { get; set; }

        [ForeignKey(nameof(CityId))]
        public virtual City? City { get; set; }



    }
}
