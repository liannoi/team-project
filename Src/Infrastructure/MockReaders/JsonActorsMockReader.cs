using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TeamProject.Domain.Entities.Actor;

namespace TeamProject.Infrastructure.MockReaders
{
    public class JsonActorsMockReader : JsonMockReader<Actor>
    {
        public override async Task<IEnumerable<Actor>> ReadAsync(string filePath, CancellationToken cancellationToken)
        {
            return await DeserializeAsync(filePath, cancellationToken);
        }
    }
}