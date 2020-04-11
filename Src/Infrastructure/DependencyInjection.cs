using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TeamProject.Application;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Domain.Entities;
using TeamProject.Domain.Entities.Actor;
using TeamProject.Domain.Entities.Film;
using TeamProject.Infrastructure.Core;
using TeamProject.Infrastructure.Readers.Mock;

namespace TeamProject.Infrastructure
{
    public static class DependencyInjection
    {
        // ReSharper disable once UnusedMethodReturnValue.Global
        public static IServiceCollection AddInfrastructure(this IServiceCollection self)
        {
            self.AddTransient<IJsonMocksReader<Film>, JsonFilmsMockReader>();
            self.AddTransient<IJsonMocksReader<Actor>, JsonActorsMockReader>();
            self.AddTransient<IJsonMocksReader<Genre>, JsonGenresMockReader>();

            self.AddTransient<IIdentityService, IdentityService>();

            return self;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection self,
            IConfiguration configuration)
        {
            var section = configuration.GetSection(Consts.JwtSectionName);
            self.Configure<IdentitySettings>(section);
            var appSettings = section.Get<IdentitySettings>();

            self.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = appSettings.Issuer,
                        ValidAudience = appSettings.Issuer,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.Secret))
                    };
                });

            return self;
        }
    }
}