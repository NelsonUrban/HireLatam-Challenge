using HireLatam.Domain.Shared;
using HireLatam.Domain.Todos;
using MediatR;

namespace HireLatam.Application.Features.Todos;

public class CreateTodoCommand : IRequest<Result<Todo>>
{
    public CreateTodoCommand(TodoRequest request)
    {
        Request = request;
    }

    public TodoRequest Request { get; }
}
internal sealed class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, Result<Todo>>
{
    private ITodoRepository _repository;
    public CreateTodoCommandHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Todo>> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            return Result<Todo>.Error("The request todo cannot be null.");
        }

        Todo todo = request.Request.FromRequestToTodo();
        var result = await _repository.AddAsync(todo);

        return Result<Todo>.Success(result);
    }
}
