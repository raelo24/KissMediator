using KissMediator.Interfaces;

namespace WebApi.Application.UseCases.Todo.Commands
{
    public class CreateTodoCommand : IRequest<CreatedTodoResponse>
    {
        public string? Name { get; set; }
    }

    public class CreatedTodoResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
