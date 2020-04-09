using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Domain.Entities;

namespace TeamProject.Application.Storage.Actors
{
    /// <summary>
    ///     Actor Data Service (Entity Type).
    /// </summary>
    public class ActorService : IDataService<Actor>
    {
        private readonly IFilmsDbContext _context;
        private readonly DbSet<Actor> _entities;

        public ActorService(IFilmsDbContext context)
        {
            _context = context;
            _entities = _context.Actors;
        }

        public IQueryable<Actor> Select()
        {
            return _entities;
        }

        public Actor Add(Actor entity)
        {
            return _entities.Add(entity).Entity;
        }

        public Actor Update(Expression<Func<Actor, bool>> expressionToFindOld, Actor entity)
        {
            var fined = Find(expressionToFindOld).FirstOrDefault();
            fined.Birthday = entity.Birthday;
            fined.LastName = entity.LastName;
            fined.FirstName = entity.FirstName;
            _entities.Update(fined);

            return fined;
        }

        public Actor Remove(Actor entity)
        {
            return _entities.Remove(entity).Entity;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<Actor> Find(Expression<Func<Actor, bool>> expression)
        {
            return _entities.Where(expression);
        }
    }
}