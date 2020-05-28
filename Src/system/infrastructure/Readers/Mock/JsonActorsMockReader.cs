using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TeamProject.Domain.Entities.Actor;
using TeamProject.Infrastructure.Common.Readers;

namespace TeamProject.Infrastructure.Readers.Mock
{
    public class JsonActorsMockReader : JsonMockReader<Actor>
    {
        public override async Task<IEnumerable<Actor>> ReadAsync(string filePath, CancellationToken cancellationToken)
        {
            return await DeserializeAsync(filePath, cancellationToken);
        }
    }
}