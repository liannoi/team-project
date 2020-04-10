using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TeamProject.Application.Common.Behaviour;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Application.Storage.Actors;
using TeamProject.Application.Storage.Genres;
using TeamProject.Domain.Entities;
using TeamProject.Domain.Entities.Actor;

namespace TeamProject.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection self)
        {
            self.AddAutoMapper(Assembly.GetExecutingAssembly());
            self.AddMediatR(Assembly.GetExecutingAssembly());
            self.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            self.AddTransient<IDataService<Actor>, ActorService>();
            self.AddTransient<IBusinessService<ActorLookupDto>, ActorRepository>();

            self.AddTransient<IDataService<Genre>, GenreService>();
            self.AddTransient<IBusinessService<GenreLookupDto>, GenreRepository>();

            return self;
        }
    }
}