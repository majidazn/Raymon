using Raymon.Framwork.Microservice.Events;


namespace Raymon.Framwork.Dtos
{
    public class CreateWeatherDto: Event
    {
        public string CityName { get; set; }
        public decimal Temp { get; set; }
    }
}
