using Raymon.Common.Dtos;
using Raymon.Framwork.Dtos;
using Raymon.Framwork.Microservice.Bus;
using Raymon.Framwork.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raymon.Framwork.Extensions
{
  public static  class RabbitMq
    {
        public static void PublishWeather(IEventBus _manager, CreateWeatherDto createWeatherDto)
        {
            _manager.Publish(createWeatherDto, null);
        }
    }
}
