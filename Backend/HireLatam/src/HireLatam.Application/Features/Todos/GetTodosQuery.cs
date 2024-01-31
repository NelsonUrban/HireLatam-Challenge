using HireLatam.Domain.Shared;
using HireLatam.Domain.Todos;
using MediatR;

namespace HireLatam.Application.Features.Todos
{
    public class GetTodosQuery : IRequest<Result<List<Todo>>>
    {

    }

    internal sealed class TodosQueryHandler : IRequestHandler<GetTodosQuery, Result<List<Todo>>>
    {
        private readonly ITodoRepository _repository;

        public TodosQueryHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<Todo>>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                return Result<List<Todo>>.Error("The requested todo cannot be empty.");
            }

            var todos = await _repository.GetAllAsync();
            if (!todos.Any())
            {
                return Result<List<Todo>>.Error("Not records found.");
            }

            return Result<List<Todo>>.Success(todos);
        }
    }
}
