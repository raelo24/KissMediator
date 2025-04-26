using KissMediator.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KissMediator.Impl
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));

            var handler = _serviceProvider.GetService(handlerType)
                ?? throw new InvalidOperationException($"No Handler for {request.GetType().Name} was found.");

            // Use dynamic dispatch 
            dynamic dynamicHandler = handler;
            return await dynamicHandler.HandleAsync((dynamic)request, cancellationToken);
        }

        public async Task PublishAsync<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
        {
            var handlerType = typeof(INotificationHandler<>).MakeGenericType(notification.GetType());
            var handlers = _serviceProvider.GetServices(handlerType);

            foreach (var handler in handlers)
            {
                // Use dynamic dispatch
                dynamic dynamicHandler = handler!;
                await dynamicHandler.HandleAsync((dynamic)notification, cancellationToken);
            }

        }
    }
}
