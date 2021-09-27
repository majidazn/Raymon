using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Raymon.Common.Dtos;
using Raymon.Framwork.Configuration;
using Raymon.Framwork.Dtos;
using Raymon.Services.Weather;
using System;
using System.IO;
using System.Text;

namespace Raymon.WeatherMessageReceiver
{
    class Program
    {
        public static IConfigurationRoot configuration;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "CreateWeatherDto",
                durable: false, exclusive: false, autoDelete: false, arguments: null
                );


            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;

            channel.BasicConsume(queue: "CreateWeatherDto", autoAck: true, consumer: consumer);

            Console.ReadLine();

        }
        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body.ToArray());

            var output = JsonConvert.DeserializeObject<CreateWeatherDto>(message);
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var services = new ServiceCollection();
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddDbContextCustom(configuration);

            var serviceProvider = services.BuildServiceProvider();

            var userAppService = serviceProvider.GetService<IWeatherService>();


            if (output.Temp > 14)
            {
                var createCityWeatherDto = new CreateCityWeatherDto
                {
                    City = output.CityName,
                    Temperature = output.Temp
                };

                userAppService.CreateCityWeather(createCityWeatherDto);

            }



        }
        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
           

            serviceCollection.AddLogging();

            // Build configuration
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);

        }


    }
}
