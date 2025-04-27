using KissMediator.Impl;
using KissMediator.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KissMediator.Extensions
{
    public static class ServiceCollections
    {
        public static IServiceCollection AddKissMediator(this IServiceCollection services, params Assembly[] assemblies)
        {
            if (assemblies.Length == 0)
                assemblies = AppDomain.CurrentDomain
                         .GetAssemblies();

            services.AddSingleton<IMediator, Mediator>();
            RegisterHandlers(services, assemblies);
            return services;
        }
        
        private static void RegisterHandlers(IServiceCollection services, Assembly[] assemblies)
        {
            //get all the types in each of the assembly
            var types = assemblies
                .SelectMany(m => m.GetTypes());

            foreach (var type in types)
            {
                var interfaces = type.GetInterfaces()
                    .Where(i => i.IsGenericType &&
                                (i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) ||
                                 i.GetGenericTypeDefinition() == typeof(INotificationHandler<>))).ToList();

                interfaces.ForEach(i => services.AddTransient(i, type));
            }
        }
    }
}
