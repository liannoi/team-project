using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TeamProject.Application;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Infrastructure;
using TeamProject.Persistence;
using TeamProject.Persistence.Context;

namespace TeamProject.Clients.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: CORS.

            services.AddInfrastructure();
            services.AddPersistence(Configuration);
            services.AddApplication();

            services.AddHttpContextAccessor();

            services.AddHealthChecks().AddDbContextCheck<FilmsDbContext>();

            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IFilmsDbContext>());

            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();

            app.UseRouting();

            // TODO: CORS.

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}