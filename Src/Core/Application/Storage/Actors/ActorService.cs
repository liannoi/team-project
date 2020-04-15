using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TeamProject.Application.Common.Interfaces.Persistence;
using TeamProject.Application.Common.Interfaces.Storage;
using TeamProject.Domain.Entities.Actor;
using TeamProject.Domain.Entities.ManyToMany;

namespace TeamProject.Application.Storage.Actors
{
    public class ActorFilmService : BaseDataService<ActorsFilms>
    {
        public ActorFilmService(IFilmsDbContext context) : base(context, context.ActorsFilms)
        {
        }

        public override Task<ActorsFilms> UpdateAsync(Expression<Func<ActorsFilms, bool>> expressionToFindOld, ActorsFilms entity)
        {
            throw new NotImplementedException();
        }
    }

    public class ActorFilmRepository : BaseBusinessService<ActorsFilms, ActorFilmLookupDto>
    {
        public ActorFilmRepository(IDataService<ActorsFilms> dataService, IMapper mapper) : base(dataService, mapper)
        {
        }
    }

    /// <summary>
    ///     Actor Data Service (Entity Type).
    /// </summary>
    public class ActorService : BaseDataService<Actor>
    {
        public ActorService(IFilmsDbContext context) : base(context, context.Actors)
        {
        }

        public override async Task<Actor> UpdateAsync(Expression<Func<Actor, bool>> expressionToFindOld, Actor entity)
        {
            var fined = Find(expressionToFindOld).FirstOrDefault();
            fined.Birthday = entity.Birthday;
            fined.LastName = entity.LastName;
            fined.FirstName = entity.FirstName;
            Entities.Update(fined);
            await CommitAsync(CancellationToken.None);

            return fined;
        }
    }
}