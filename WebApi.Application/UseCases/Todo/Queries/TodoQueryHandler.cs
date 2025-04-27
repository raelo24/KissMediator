using KissMediator.Interfaces;

namespace WebApi.Application.UseCases.Todo.Queries
{
    public class TodoQueryHandler : IRequestHandler<TodoQuery, TodoResponse>
    {
        public async Task<TodoResponse> HandleAsync(TodoQuery request, CancellationToken token)
        {
            //simulate async operation
            await Task.Delay(TimeSpan.FromSeconds(1), token);

            var response = new TodoResponse
            {
                Id = request.Id,
                Name = "Write essay",
                CreatedAt = DateTime.UtcNow
            };

            return response;
        }
    }
}
