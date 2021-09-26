using Newtonsoft.Json;
using Raymon.Common.Dtos;
using System.Net.Http;
using System.Threading.Tasks;

namespace Raymon.Services.CommonServices
{
    public static class WeatherApiService
    {
 



        public static async Task<WeatherDto> GetWeatherDataAsync( IHttpClientFactory clientFactory ,string cityName)
        {
            using (var client = clientFactory.CreateClient())
            {
                var request = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid=4a0e56d3f84d11bcfcd14a839402c47c&units=metric";

                var response = await client.GetAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    // var output = (WeatherDto)Convert.ChangeType(data, typeof(WeatherDto));
                    var output = JsonConvert.DeserializeObject<WeatherDto>(data);
                    return output;
                }
                return null;

            }



        }

    }
}
