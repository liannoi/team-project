using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TeamProject.Application.Common.Behaviour;

namespace TeamProject.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection self)
        {
            self.AddAutoMapper(Assembly.GetExecutingAssembly());
            self.AddMediatR(Assembly.GetExecutingAssembly());
            self.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return self;
        }
    }
}