using LinguaFluency.Domain.Models;
using LinguaFluency.Domain.ServiceIntefraces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinguaFluency.Infrastructure.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserService, UserService>();

            var authOptions = configuration.GetSection("Auth");
            services.Configure<AuthJwtService>(authOptions);

            var authOption = configuration.GetSection("Auth").Get<AuthJwtService>();
            authJwtOptions.Issuer = authOption.Issuer;
            authJwtOptions.Audience = authOption.Audience;
            authJwtOptions.TokenLifeTime = authOption.TokenLifeTime;
            authJwtOptions.SecretKey = authOption.GetSymmetricSecurityKey();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = authOption.Issuer,

                            ValidateAudience = true,
                            ValidAudience = authOption.Audience,
                            ValidateLifetime = true,

                            IssuerSigningKey = authOption.GetSymmetricSecurityKey(),
                            ValidateIssuerSigningKey = true,
                        };
                    });


            return services;
        }
    }
}
