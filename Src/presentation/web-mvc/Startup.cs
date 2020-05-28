using System.IO;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using TeamProject.Clients.Common.Models.Identity.ViewModels;
using TeamProject.Clients.WebUI.Models;
using TeamProject.Infrastructure;

namespace TeamProject.Clients.WebUI
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
            services.AddInfrastructureForJwtAuthentication(Configuration);
            services.AddInfrastructure();

            services.AddMvc()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<RegisterViewModel>();
                    fv.RegisterValidatorsFromAssemblyContaining<LoginViewModel>();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider =
                    new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "actorsPhotosDir")),
                RequestPath = new PathString("/Images")
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // TODO: Remove.
            //app.Use((context, next) =>
            //{
            //    var token = context.Request.Cookies[Consts.InCookiesJwtTokenName];
            //    if (!string.IsNullOrEmpty(token)) context.Request.Headers.Add("Authorization", $"Bearer {token}");

            //    return next();
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}