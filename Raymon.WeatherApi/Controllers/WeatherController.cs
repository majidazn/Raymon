using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raymon.Common.Dtos;
using Raymon.Framwork.Dtos;
using Raymon.Framwork.Extensions;
using Raymon.Framwork.Microservice.Bus;
using Raymon.Framwork.RabbitMq;
using Raymon.Services.CommonServices;
using Raymon.Services.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Raymon.WeatherApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
   
   [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class WeatherController : ControllerBase
    {

        private readonly IWeatherService _weatherService;
        private  readonly IHttpClientFactory _httpClientFactory;
        private IEventBus _manager;
        public WeatherController(IWeatherService weatherService, IEventBus manager, IHttpClientFactory httpClientFactory)
        {
            _weatherService = weatherService;
            _manager = manager;
            _httpClientFactory = httpClientFactory;
        }


        [HttpPost]
       
        public async Task<IActionResult> SendWeather([FromBody] SendWeatherDto sendWeatherDto)
        {

          var weatherData= await WeatherApiService.GetWeatherDataAsync(_httpClientFactory, sendWeatherDto.CityName);

            if(weatherData!= null) {

                var createWeatherDto = new CreateWeatherDto
                {
                    CityName= weatherData.name,
                    Temp=weatherData.main.temp
                };


            var jobId = BackgroundJob.Schedule(() => RabbitMq.PublishWeather(_manager, createWeatherDto), TimeSpan.FromMinutes(sendWeatherDto.AfterMinutes));
            }

            return Ok();
          
        }

  

    }
}
