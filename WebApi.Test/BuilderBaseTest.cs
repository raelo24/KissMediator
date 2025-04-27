using Microsoft.Extensions.DependencyInjection;
using KissMediator.Extensions;
using KissMediator.Interfaces;

namespace WebApi.Test
{

    public class BuilderBaseTest
    {
        internal readonly IMediator _mediator;
        public BuilderBaseTest()
        {
            _mediator = new ServiceCollection()
                    .AddKissMediator()
                    .BuildServiceProvider()
                    .GetRequiredService<IMediator>();
        }

    }
}
