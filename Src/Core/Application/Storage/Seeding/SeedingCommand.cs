using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Domain.Entities;

namespace TeamProject.Application.Storage.Seeding
{
    public class SeedingCommand : IRequest
    {
        // ReSharper disable once UnusedType.Global
        public class SeedingCommandHandler : IRequestHandler<SeedingCommand>
        {
            private readonly IFilmsDbContext _context;
            private readonly IJsonMocksReader<Actor> _mockActors;
            private readonly IJsonMocksReader<Film> _mockFilms;
            private readonly IJsonMocksReader<Genre> _mockGenres;

            public SeedingCommandHandler(IFilmsDbContext context, IJsonMocksReader<Film> mockFilms,
                IJsonMocksReader<Actor> mockActors, IJsonMocksReader<Genre> mockGenres)
            {
                _context = context;
                _mockFilms = mockFilms;
                _mockActors = mockActors;
                _mockGenres = mockGenres;
            }

            public async Task<Unit> Handle(SeedingCommand request, CancellationToken cancellationToken)
            {
                await new JsonMocksSeeder(_context, _mockFilms, _mockActors, _mockGenres)
                    .SeedAllAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}