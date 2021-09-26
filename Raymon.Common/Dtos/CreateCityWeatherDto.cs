using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raymon.Common.Dtos
{
    public class CreateCityWeatherDto
    {
        public string City { get; set; }
        public decimal Temperature { get; set; }
    }
}
