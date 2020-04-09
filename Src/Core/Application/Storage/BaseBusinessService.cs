﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
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

        public async Task<TBEntity> AddAsync(TBEntity entity)
        {
            return Map(await _dataService.AddAsync(Map(entity)));
        }

        public async Task<TBEntity> UpdateAsync(Expression<Func<TBEntity, bool>> expressionToFindOld, TBEntity entity)
        {
            return Map(await _dataService.UpdateAsync(Map(expressionToFindOld), Map(entity)));
        }

        public async Task<TBEntity> RemoveAsync(TBEntity entity)
        {
            try
            {
                return Map(await _dataService.RemoveAsync(Map(entity)));
            }
            catch
            {
                throw;
            }                        
        }

        #region Helpers

        protected Expression<Func<TEntity, bool>> Map(Expression<Func<TBEntity, bool>> expression)
        {
            return _mapper.MapExpression<Expression<Func<TEntity, bool>>>(expression);
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