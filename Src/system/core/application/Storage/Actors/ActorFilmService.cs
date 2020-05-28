using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TeamProject.Application.Common.Interfaces.Persistence;
using TeamProject.Domain.Entities.ManyToMany;

namespace TeamProject.Application.Storage.Actors
{
    public class ActorFilmService : BaseDataService<ActorsFilms>
    {
        public ActorFilmService(IFilmsDbContext context) : base(context, context.ActorsFilms)
        {
        }

        public override Task<ActorsFilms> UpdateAsync(Expression<Func<ActorsFilms, bool>> expressionToFindOld,
            ActorsFilms entity)
        {
            throw new NotImplementedException();
        }
    }
}