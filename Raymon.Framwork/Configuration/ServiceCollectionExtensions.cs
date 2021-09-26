using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Raymon.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

using Raymon.Domain.Identity;

namespace Raymon.Framwork.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbContextCustom(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RaymonContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
              
             
            });

            services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<RaymonContext>();
        }
    }
}
