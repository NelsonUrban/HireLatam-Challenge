using HireLatam.Domain.Shared;
using HireLatam.Domain.Todos;
using MediatR;

namespace HireLatam.Application.Features.Todos;

public class GetTodoByIdQuery : IRequest<Result<Todo>>
{
    public GetTodoByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; }
}

internal sealed class TodoQueryHandler : IRequestHandler<GetTodoByIdQuery, Result<Todo>>
{
    private readonly ITodoRepository _repository;

    public TodoQueryHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Todo>> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
    {
        if (request is null || request.Id <= 0)
        {
            return Result<Todo>.Error("The request cannot be empty.");
        }

        var result = await _repository.GetByAsync(t => t.Id == request.Id);
        if (result == null)
        {
            return Result<Todo>.Error("Record not found.");
        }

        return Result<Todo>.Success(result);
    }
}
