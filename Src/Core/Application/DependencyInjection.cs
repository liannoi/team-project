using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TeamProject.Application.Common.Interfaces.Storage;
using TeamProject.Application.Storage.Actors;
using TeamProject.Application.Storage.ActorsPhotos;
using TeamProject.Application.Storage.Films;
using TeamProject.Application.Storage.Genres;
using TeamProject.Domain.Entities;
using TeamProject.Domain.Entities.Actor;
using TeamProject.Domain.Entities.Film;
using TeamProject.Domain.Entities.ManyToMany;

namespace TeamProject.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection self)
        {
            self.AddAutoMapper(Assembly.GetExecutingAssembly());
            self.AddMediatR(Assembly.GetExecutingAssembly());

            self.AddTransient<IDataService<Actor>, ActorService>();
            self.AddTransient<IBusinessService<ActorLookupDto>, ActorRepository>();

            self.AddTransient<IDataService<ActorPhoto>, ActorPhotoService>();
            self.AddTransient<IBusinessService<ActorPhotoLookupDto>, ActorPhotoRepository>();

            self.AddTransient<IDataService<ActorsFilms>, ActorFilmService>();
            self.AddTransient<IBusinessService<ActorFilmLookupDto>, ActorFilmRepository>();

            self.AddTransient<IDataService<Genre>, GenreService>();
            self.AddTransient<IBusinessService<GenreLookupDto>, GenreRepository>();

            self.AddTransient<IDataService<Film>, FilmService>();
            self.AddTransient<IBusinessService<FilmLookupDto>, FilmRepository>();

            return self;
        }
    }
}