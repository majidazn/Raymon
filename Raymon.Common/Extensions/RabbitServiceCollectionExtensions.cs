using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raymon.Common.Extensions
{
    public static class RabbitServiceCollectionExtensions
    {
        //public static IServiceCollection AddRabbit(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var rabbitConfig = configuration.GetSection("rabbit");
        //    services.Configure<RabbitOptions>(rabbitConfig);

        //    services.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
        //    services.AddSingleton<IPooledObjectPolicy<IModel>, RabbitModelPooledObjectPolicy>();

        //    services.AddSingleton<IRabbitManager, RabbitManager>();

        //    return services;
        //}
    }
}
