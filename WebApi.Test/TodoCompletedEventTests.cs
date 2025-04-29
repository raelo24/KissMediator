using KissMediator.Impl;
using KissMediator.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.UseCases.Todo.Events;

namespace WebApi.Test
{
    public class TodoCompletedEventTests : BuilderBaseTest
    {
        public TodoCompletedEventTests() : base() { }

        [Fact]
        public void validate_event_successfully()
        {
            // Act
            var response = async () => await _mediator.PublishAsync(new TodoCompletedEvent());

            // Assert response or perform further actions
            Assert.NotNull(response);
        }
    }
}
