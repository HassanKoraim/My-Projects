using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceConstracts.DTO
{
    public class CityResponse
    {
        public Guid CityId { get; set; }
        public string CityName { get; set; }
    }
    public static class CityExtension
    {
        public static CityResponse ToCityResponse(this CityAddRequest cityAddRequset)
        {
            return new CityResponse
            {
                CityName = cityAddRequset.CityName
            };
        }
    }
}
