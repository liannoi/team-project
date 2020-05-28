using Microsoft.EntityFrameworkCore;
using TeamProject.Application.Common.Interfaces.Persistence;
using TeamProject.Domain.Entities;
using TeamProject.Domain.Entities.Actor;
using TeamProject.Domain.Entities.Film;
using TeamProject.Domain.Entities.ManyToMany;
using TeamProject.Domain.Entities.Voting;

namespace TeamProject.Persistence.Contexts.Core
{
    public class FilmsDbContext : DbContext, IFilmsDbContext
    {
        public FilmsDbContext(DbContextOptions<FilmsDbContext> options) : base(options)
        {
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorsFilms> ActorsFilms { get; set; }
        public DbSet<ActorPhoto> ActorPhotos { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmsGenres> FilmsGenres { get; set; }
        public DbSet<FilmPhoto> FilmPhotos { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Voting> Voting { get; set; }
        public DbSet<VotingAnswer> VotingAnswers { get; set; }
        public DbSet<VotingPolle> VotingPolle { get; set; }
        public DbSet<VotingPolleRelation> VotingPolles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FilmsDbContext).Assembly);
        }
    }
}