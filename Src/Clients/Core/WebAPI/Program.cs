using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TeamProject.Application.Storage.Seeding;
using TeamProject.Persistence.Contexts.Core;
using TeamProject.Persistence.Contexts.Identity;

namespace TeamProject.Clients.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    services.GetRequiredService<FilmsDbContext>().Database.Migrate();
                    await services.GetRequiredService<IMediator>().Send(new SeedingCommand(), CancellationToken.None);

                    services.GetRequiredService<FilmsIdentityContext>().Database.Migrate();
                    await services.GetRequiredService<IMediator>()
                        .Send(new SeedingIdentityCommand(), CancellationToken.None);
                }
                catch (Exception ex)
                {
                    scope.ServiceProvider
                        .GetRequiredService<ILogger<Program>>()
                        .LogError(ex, "An error occurred while migrating or initializing the database.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json",
                            true, true)
                        .AddJsonFile("appsettings.Local.json", true, true);

                    config.AddEnvironmentVariables();
                }).UseStartup<Startup>();
        }
    }
}