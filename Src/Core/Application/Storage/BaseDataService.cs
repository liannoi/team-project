using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamProject.Application.Common.Interfaces;

namespace TeamProject.Application.Storage
{
    public abstract class BaseDataService<TEntity> : IDataService<TEntity> where TEntity : class, new()
    {
        private readonly IFilmsDbContext _context;
        protected readonly DbSet<TEntity> Entities;

        protected BaseDataService(IFilmsDbContext context, DbSet<TEntity> entities)
        {
            _context = context;
            Entities = entities;
        }

        public IQueryable<TEntity> Select()
        {
            return Entities;
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return Entities.Where(expression);
        }

        public TEntity Add(TEntity entity)
        {
            return Entities.Add(entity).Entity;
        }

        public abstract TEntity Update(Expression<Func<TEntity, bool>> expressionToFindOld, TEntity entity);

        public TEntity Remove(TEntity entity)
        {
            return Entities.Remove(entity).Entity;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}