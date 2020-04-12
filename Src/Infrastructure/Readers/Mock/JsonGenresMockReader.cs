using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TeamProject.Domain.Entities;
using TeamProject.Infrastructure.Common.Readers;

namespace TeamProject.Infrastructure.Readers.Mock
{
    public class JsonGenresMockReader : JsonMockReader<Genre>
    {
        public override async Task<IEnumerable<Genre>> ReadAsync(string filePath, CancellationToken cancellationToken)
        {
            return await await Task.Factory.StartNew(
                async () => (await DeserializeAsync(filePath, cancellationToken))
                    .GroupBy(x => x.Title)
                    .Select(x =>
                    {
                        var item = x.FirstOrDefault();
                        if (item.Title.Length > 64) item.Title = item.Title.Substring(0, 64);

                        return item;
                    }), cancellationToken);
        }
    }
}