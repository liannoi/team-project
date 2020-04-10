using Microsoft.Extensions.DependencyInjection;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Domain.Entities;
using TeamProject.Domain.Entities.Actor;
using TeamProject.Domain.Entities.Film;
using TeamProject.Infrastructure.MockReaders;

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

            return self;
        }
    }
}