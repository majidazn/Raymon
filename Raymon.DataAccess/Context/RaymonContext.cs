using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}
    }
}
