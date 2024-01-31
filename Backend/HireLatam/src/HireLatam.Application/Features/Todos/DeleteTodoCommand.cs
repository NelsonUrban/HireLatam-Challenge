using HireLatam.Domain.Shared;
using HireLatam.Domain.Todos;
using MediatR;

namespace HireLatam.Application.Features.Todos;

public class DeleteTodoCommand : IRequest<Result<Todo>>
{
    public DeleteTodoCommand(int id)
    {
        Id = id;
    }
    public int Id { get; }
}

internal sealed class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, Result<Todo>>
{
    private readonly ITodoRepository _repository;

    public DeleteTodoCommandHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Todo>> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        if (request is null || request.Id <= 0)
        {
            return Result<Todo>.Error("The request cannot be empty.");
        }

        var todo = await _repository.GetByAsync(t => t.Id == request.Id);
        if (todo == null)
        {
            return Result<Todo>.Error("The todo cannot be null.");
        }

        var result = await _repository.DeleteAsync(todo);

        return Result<Todo>.Success(result);
    }
}
