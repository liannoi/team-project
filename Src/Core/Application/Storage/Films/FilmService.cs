using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using TeamProject.Application.Common.Interfaces.Persistence;
using TeamProject.Domain.Entities.Film;

namespace TeamProject.Application.Storage.Films
{
    public class FilmService : BaseDataService<Film>
    {
        public FilmService(IFilmsDbContext context) : base(context, context.Films)
        {
        }

        public override async Task<Film> UpdateAsync(Expression<Func<Film, bool>> expressionToFindOld, Film entity)
        {
            var film = Find(expressionToFindOld).FirstOrDefault();
            film.Title = entity.Title;
            film.PublishYear = entity.PublishYear;
            await CommitAsync(CancellationToken.None);

            return film;
        }
    }
}