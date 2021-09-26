using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raymon.Domain
{
    public class CityWeather
    {
        public int Id { get; set; }
        public string City { get; set; }
        public decimal Temperature { get; set; }
    }
}
