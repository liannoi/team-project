using Microsoft.Extensions.DependencyInjection;
using TeamProject.Clients.Common.Tools;

namespace TeamProject.Clients.Common
{
    public static class DependencyInjection
    {
        // ReSharper disable once UnusedMethodReturnValue.Global
        public static IServiceCollection AddCommonForClients(this IServiceCollection self)
        {
            self.AddTransient<IApiTools, ApiTools>();

            return self;
        }
    }
}