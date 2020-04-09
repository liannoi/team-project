﻿using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TeamProject.Application.Common.Behaviour;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Application.Storage.Actors;
using TeamProject.Domain.Entities;

namespace TeamProject.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection self)
        {
            self.AddAutoMapper(Assembly.GetExecutingAssembly());
            self.AddMediatR(Assembly.GetExecutingAssembly());
            self.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            self.AddScoped<IDataService<Actor>, ActorService>();
            self.AddScoped<IBusinessService<ActorLookupDto>, ActorRepository>();

            return self;
        }
    }
}