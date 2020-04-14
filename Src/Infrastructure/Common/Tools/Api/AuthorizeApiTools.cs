using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TeamProject.Application.Common.Interfaces.Infrastructure;

namespace TeamProject.Infrastructure.Common.Tools.Api
{
    public class AuthorizeApiTools : ApiTools, IAuthorizeApiTools
    {
        public async Task<TEntity> FetchAsync<TEntity>(string uri, string token) where TEntity : class, new()
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await ContinueWithDeserializeAsync<TEntity>(client.GetAsync(uri));
        }

        public Task<TEntity> PostAsync<TEntity>(string uri, ByteArrayContent content, string token)
            where TEntity : class, new()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> PostAsync<TEntity>(string uri, object value, string token) where TEntity : class, new()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string uri, string token)
        {
            throw new NotImplementedException();
        }
    }
}