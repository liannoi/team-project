using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TeamProject.Application.Common.Interfaces.Storage
{
    public interface IBusinessService<TBEntity> where TBEntity : class, new()
    {
        IEnumerable<TBEntity> Select();
        IEnumerable<TBEntity> Find(Expression<Func<TBEntity, bool>> expression);
        Task<TBEntity> AddAsync(TBEntity entity);
        Task<TBEntity> UpdateAsync(Expression<Func<TBEntity, bool>> expressionToFindOld, TBEntity entity);
        Task<TBEntity> RemoveAsync(TBEntity entity);
    }
}