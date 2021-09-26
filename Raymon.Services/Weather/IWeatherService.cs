using Raymon.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raymon.Services.Weather
{
    public interface IWeatherService
    {
        Task<int> CreateCityWeather(CreateCityWeatherDto createCityWeatherDto);
    }
}
