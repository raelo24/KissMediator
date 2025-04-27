using KissMediator.Impl;
using KissMediator.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.UseCases.Todo.Queries;

namespace WebApi.Test
{
    public class TodoQueryHanderTests : BuilderBaseTest
    {
        public TodoQueryHanderTests() : base() { }

        [Fact]
        public async Task validate_query_with_result_successfully()
        {
            // Arrange
            var request = new TodoQuery { Id = Guid.NewGuid() };

            // Act
            var response = await _mediator.SendAsync(request);

            // Assert 
           Assert.NotNull(response);
           Assert.Equal(request.Id, response.Id);
           Assert.Equal("Write essay", response.Name);
        }

        [Fact]
        public async Task validate_query_with_cancelled_execution()
        {
            // Arrange
            var query = new TodoQuery{Id = Guid.NewGuid()}; 
            var cts = new CancellationTokenSource(TimeSpan.FromTicks(0)); //cancell immediately
;
            // Act and Assert
            await Assert.ThrowsAsync<TaskCanceledException>(() => _mediator.SendAsync(query, cts.Token));
        }
    }
}
