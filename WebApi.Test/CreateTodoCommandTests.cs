using WebApi.Application.UseCases.Todo.Commands;

namespace WebApi.Test
{
    
    public class CreateTodoCommandTests : BuilderBaseTest
    {
        public CreateTodoCommandTests() : base() { }

        [Fact]
        public async Task validate_command_with_result_successfully()
        { 
            // Arrange
            var request = new CreateTodoCommand { Name = "Test Todo" };

            // Act
            var response = await _mediator.SendAsync(request);

            // Assert response or perform further actions
            Assert.NotNull(response);
            Assert.Equal("Test Todo", response.Name);
            Assert.NotEqual(Guid.Empty, response.Id);
            Assert.True(response.CreatedAt < DateTime.UtcNow); //was created a while ago
        }

        [Fact]
        public async Task validate_command_with_cancelled_execution()
        {
            // Arrange
            var request = new CreateTodoCommand { Name = "Test Todo" };
            var cts = new CancellationTokenSource(TimeSpan.FromTicks(0)); //cancell immediately

            await Assert.ThrowsAsync<TaskCanceledException>(() => _mediator.SendAsync(request, cts.Token));

        }
    }
}