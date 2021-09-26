using Raymon.Common.Dtos;
using Raymon.DataAccess.Context;
using Raymon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raymon.Services.Weather
{
    public class WeatherService : IWeatherService
    {
        RaymonContext _dbContext;
        public WeatherService(RaymonContext dbContext) : base()
        {
            _dbContext = dbContext;
        }


        public async Task<int> CreateCityWeather(CreateCityWeatherDto createCityWeatherDto)
        {

            var cityWeather = new CityWeather
            {
                City = createCityWeatherDto.City,
                Temperature = createCityWeatherDto.Temperature
            };

            var result = await _dbContext.AddAsync(cityWeather);
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;

        }


    }
}
