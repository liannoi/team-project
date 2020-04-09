using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TeamProject.Application.Common.Interfaces;

namespace TeamProject.Application.Storage
{
    public class BaseBusinessService<TEntity, TBEntity> : IBusinessService<TBEntity>
        where TBEntity : class, new() where TEntity : class, new()
    {
        private readonly IDataService<TEntity> _dataService;
        private readonly IMapper _mapper;

        protected BaseBusinessService(IDataService<TEntity> dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        public IList<TBEntity> Select()
        {
            return Map(_dataService.Select());
        }

        public IList<TBEntity> Find(Expression<Func<TBEntity, bool>> expression)
        {
            return Map(_dataService.Find(Map(expression)));
        }

        public TBEntity Add(TBEntity entity)
        {
            var added = _dataService.Add(Map(entity));
            _dataService.CommitAsync(CancellationToken.None);

            return Map(added);
        }

        public TBEntity Update(Expression<Func<TBEntity, bool>> expressionToFindOld, TBEntity entity)
        {
            var updated = _dataService.Update(Map(expressionToFindOld), Map(entity));
            _dataService.CommitAsync(CancellationToken.None);

            return Map(updated);
        }

        public TBEntity Remove(TBEntity entity)
        {
            var deleted = _dataService.Remove(Map(entity));
            _dataService.CommitAsync(CancellationToken.None);

            return Map(deleted);
        }

        #region Helpers

        protected Expression<Func<TEntity, bool>> Map(Expression<Func<TBEntity, bool>> expression)
        {
            return _mapper.Map<Expression<Func<TEntity, bool>>>(expression);
        }

        protected TEntity Map(TBEntity entity)
        {
            return _mapper.Map<TEntity>(entity);
        }

        protected TBEntity Map(TEntity entity)
        {
            return _mapper.Map<TBEntity>(entity);
        }

        protected IList<TBEntity> Map(IQueryable<TEntity> queryable)
        {
            return queryable.ProjectTo<TBEntity>(_mapper.ConfigurationProvider).ToList();
        }

        #endregion
    }
}