using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Raymon.Framwork.Extensions;
using Microsoft.OpenApi.Models;
using Raymon.Services.Weather;
using Raymon.Framwork.Microservice.Bus;
using Raymon.Framwork.RabbitMq;
using MediatR;
using Raymon.Framwork.Configuration;

namespace Raymon.WeatherApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Raymon.WeatherApi", Version = "v1" });
            });
            var rabbitConfig = Configuration.GetSection("Rabbit").GetChildren();
            var test = Configuration.GetConnectionString("DefaultConnection");
            //services.AddRabbit(Configuration);
            services.HangfireSetup(Configuration);
            services.AddHangfireServer();
            services.IdentitySetup();
            services.AddHttpClient();

            services.AddDbContextCustom(Configuration);

            services.AddScoped<IWeatherService, WeatherService>();

            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Raymon.WeatherApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseHangfireDashboard();

        }
    }
}
