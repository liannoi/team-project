using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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

        public async Task<TEntity> PostAsync<TEntity>(string uri, ByteArrayContent content, string token)
            where TEntity : class, new()
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (content == null) throw new ArgumentNullException(nameof(content));

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await ContinueWithDeserializeAsync<TEntity>(client.PostAsync(uri, content));
        }

        public async Task<TEntity> PostAsync<TEntity>(string uri, object value, string token)
            where TEntity : class, new()
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (value == null) throw new ArgumentNullException(nameof(value));

            var byteContent = new ByteArrayContent(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value)));
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await ContinueWithDeserializeAsync<TEntity>(client.PostAsync(uri, byteContent));
        }

        public async Task DeleteAsync(string uri, string token)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            await client.DeleteAsync(uri);
        }
    }
}