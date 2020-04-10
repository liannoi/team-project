using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Domain.Entities;
using TeamProject.Persistence.Context;

namespace TeamProject.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection self, IConfiguration configuration)
        {
            self.AddDbContext<FilmsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(Consts.DatabaseNameInConnectionString)));

            self.AddScoped<IFilmsDbContext>(provider => provider.GetService<FilmsDbContext>());

            self.AddDbContext<FilmsIdentityContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(Consts.IdentityDatabaseNameInConnectionString)));

            self.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<FilmsIdentityContext>();

            return self;
        }
    }
}