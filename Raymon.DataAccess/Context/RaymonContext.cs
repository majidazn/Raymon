using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Raymon.Domain;
using Raymon.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raymon.DataAccess.Context
{
    public class RaymonContext :IdentityDbContext<User>
    {
   
        public RaymonContext(DbContextOptions<RaymonContext> options)
      : base(options)
        {
        }


        public DbSet<CityWeather> CityWeathers { get; set; }
        
  
    }
}
