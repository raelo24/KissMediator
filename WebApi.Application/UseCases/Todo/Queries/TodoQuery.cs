using KissMediator.Interfaces;

namespace WebApi.Application.UseCases.Todo.Queries
{
    public class TodoQuery : IRequest<TodoResponse>
    {
        public Guid Id { get; set; }
    }

    public class TodoResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
