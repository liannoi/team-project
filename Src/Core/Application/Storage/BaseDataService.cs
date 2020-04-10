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

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            Entities.Add(entity);
            await CommitAsync(CancellationToken.None);
            return entity;
        }

        public abstract Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> expressionToFindOld, TEntity entity);

        public async Task<TEntity> RemoveAsync(TEntity entity)
        {
            Entities.Remove(entity);
            await CommitAsync(CancellationToken.None);
            return entity;
        }

        protected async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}