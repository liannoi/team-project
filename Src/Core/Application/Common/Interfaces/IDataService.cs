using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace TeamProject.Application.Common.Interfaces
{
    public interface IDataService<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> Select();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> expressionToFindOld, TEntity entity);
        Task<TEntity> RemoveAsync(TEntity entity);
    }
}