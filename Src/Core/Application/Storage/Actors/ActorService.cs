
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Domain.Entities;

namespace TeamProject.Application.Storage.Actors
{
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