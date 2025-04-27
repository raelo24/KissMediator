using KissMediator.Interfaces;

namespace WebApi.Application.UseCases.Todo.Commands
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, CreatedTodoResponse>
    {
        public async Task<CreatedTodoResponse> HandleAsync(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            //just to perform an async operation
            await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken); 

            return new CreatedTodoResponse
            {
                Id = Guid.NewGuid(), 
                Name = request.Name,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
