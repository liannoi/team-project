using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TeamProject.Clients.WebUI.Common.Pagination.Models.ViewModels
{
    public abstract class GenericViewModel<TEntity>
    {
        protected IQueryable<TEntity> _collection;

        public GenericViewModel()
        {
            PagingInfo = new PagingInfo
            {
                CurrentPage = 1,
                ItemsPerPage = 10
            };
        }

        public PagingInfo PagingInfo { get; set; }

        public IQueryable<TEntity> Collection
        {
            get => _collection;
            set
            {
                _collection = value;
                PagingInfo.TotalItems = _collection == null ? 0 : _collection.Count();
            }
        }

        public int EntityId { get; set; }
        public abstract Expression<Func<TEntity, bool>> Predicate { get; }
        public abstract IEnumerable<TEntity> EntitiesPerPage { get; }
    }
}