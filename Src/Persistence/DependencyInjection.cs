using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeamProject.Application.Common.Interfaces.Persistence;
using TeamProject.Domain.Entities.Identity;
using TeamProject.Persistence.Common.Describers;
using TeamProject.Persistence.Contexts.Core;
using TeamProject.Persistence.Contexts.Identity;

namespace TeamProject.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection self, IConfiguration configuration)
        {
            self.AddDbContext<FilmsDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString(PersistenceDefaults.DatabaseNameInConnectionString)));

            self.AddScoped<IFilmsDbContext>(provider => provider.GetService<FilmsDbContext>());

            self.AddDbContext<FilmsIdentityContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString(PersistenceDefaults.IdentityDatabaseNameInConnectionString)));

            self.AddScoped<IdentityDbContext<AppUser>>(provider => provider.GetService<FilmsIdentityContext>());

            self.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<FilmsIdentityContext>()
                .AddErrorDescriber<AbstractErrorDescriber>();

            return self;
        }
    }
}