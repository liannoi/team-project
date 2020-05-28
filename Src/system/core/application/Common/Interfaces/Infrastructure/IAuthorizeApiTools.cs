using System.Net.Http;
using System.Threading.Tasks;

namespace TeamProject.Application.Common.Interfaces.Infrastructure
{
    public interface IAuthorizeApiTools
    {
        Task<TEntity> FetchAsync<TEntity>(string uri, string token) where TEntity : class, new();

        Task<TEntity> PostAsync<TEntity>(string uri, ByteArrayContent content, string token)
            where TEntity : class, new();

        Task<TEntity> PostAsync<TEntity>(string uri, object value, string token) where TEntity : class, new();
        Task DeleteAsync(string uri, string token);
    }
}