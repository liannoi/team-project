﻿using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeamProject.Application.Common.Interfaces;

namespace TeamProject.Infrastructure.MockReaders
{
    public abstract class JsonMockReader<TEntity> : IJsonMocksReader<TEntity> where TEntity : class, new()
    {
        public abstract Task<IEnumerable<TEntity>> ReadAsync(string filePath, CancellationToken cancellationToken);

        protected async Task<IEnumerable<TEntity>> DeserializeAsync(string filePath,
            CancellationToken cancellationToken)
        {
            return await await Task.Factory.StartNew(
                async () => JsonConvert.DeserializeObject<IEnumerable<TEntity>>(
                    await File.ReadAllTextAsync(filePath, cancellationToken)), cancellationToken);
        }
    }
}