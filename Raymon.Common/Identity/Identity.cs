using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Raymon.Common.Identity
{
    //public static class Identity
    //{
    //    public static void IdentitySetup(this IServiceCollection services)
    //    {
    //        services.AddAuthentication(options =>
    //        {
    //            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //            options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    //            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //        })
    //           .AddJwtBearer(cfg =>
    //           {
    //               var tokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mbPeShVm6v9y_RaymonTokenKey125"));
    //               cfg.RequireHttpsMetadata = false;
    //               cfg.SaveToken = true;

    //               cfg.TokenValidationParameters = new TokenValidationParameters
    //               {
    //                   ValidIssuer = "http://localhost:7740/",
    //                   ValidAudience = "http://localhost:2658/",

    //                   IssuerSigningKey = tokenKey,
    //                   ValidateIssuer = true,
    //                   ValidateAudience = true,
    //                   ValidateLifetime = true,
    //                   ValidateIssuerSigningKey = true,
    //                   ClockSkew = TimeSpan.Zero
    //                   //   TokenDecryptionKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Encryption.PasswordKey))
    //               };

    //               cfg.Events = new JwtBearerEvents
    //               {
    //                   OnAuthenticationFailed = context =>
    //                   {
    //                       return Task.CompletedTask;
    //                   },
    //                   OnTokenValidated = context =>
    //                   {
    //                       return Task.CompletedTask;
    //                   },
    //                   OnMessageReceived = context =>
    //                   {
                         
    //                       return Task.CompletedTask;
    //                   },
    //                   OnChallenge = context =>
    //                   {
    //                       return Task.CompletedTask;
    //                   }
    //               };
    //           });


    //    }

    //}

}
