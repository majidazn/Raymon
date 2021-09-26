using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raymon.Common.Dtos
{
    public class SendWeatherDto
    {
        public string CityName { get; set; }
        public int AfterMinutes { get; set; }
    }
}
