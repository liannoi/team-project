using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TeamProject.Application.Common.Interfaces
{
    public interface IBusinessService<TBEntity> where TBEntity : class, new()
    {
        IList<TBEntity> Select();
        IList<TBEntity> Find(Expression<Func<TBEntity, bool>> expression);
        TBEntity Add(TBEntity entity);
        TBEntity Update(Expression<Func<TBEntity, bool>> expressionToFindOld, TBEntity entity);
        TBEntity Remove(TBEntity entity);
    }
}