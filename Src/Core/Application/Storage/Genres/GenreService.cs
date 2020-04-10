﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Domain.Entities;
using System.Linq;
using System.Threading;

namespace TeamProject.Application.Storage.Genres
{
    public class GenreService:BaseDataService<Genre>
    {
        public GenreService(IFilmsDbContext context):base(context, context.Genres)
        {

        }

        public override async Task<Genre> UpdateAsync(Expression<Func<Genre, bool>> expressionToFindOld, Genre entity)
        {
            var genre = Find(expressionToFindOld).FirstOrDefault();
            genre.Title = entity.Title;
            Entities.Update(genre);
            await CommitAsync(CancellationToken.None);

            return genre;
        }
    }
}